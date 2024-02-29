import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { SubSink } from 'subsink'; // Assuming you are using SubSink for managing subscriptions
import { PatientDto } from '../Model/patientDto';
import { PatientService } from '../service/patient.service';
import { GenderPatient } from '../Model/genderPatient';
import { PatientFilter } from '../Model/patientFilter';

@Component({
  selector: 'ngx-patients-table',
  templateUrl: './patients-table.component.html',
  styleUrls: ['./patients-table.component.scss']
})
export class PatientsTableComponent implements OnInit, OnDestroy {
  private subs = new SubSink();
  searchForm!: FormGroup;
  currentPage: number = 1;
  pageSize: number = 50;
  patients: PatientDto[] = [];
  isModalOpen = false;
  totalItems!: number;

  constructor(
    private patientService: PatientService,
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.initializeForm();
    this.loadPatients();
    this.route.queryParamMap.subscribe((queryParams) => {
      this.handleQueryParams(queryParams);
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  initializeForm(): void {
    this.searchForm = this.formBuilder.group({
      firstName: [''],
      lastName: [''],
      region: [''],
      gender: [GenderPatient.Unknown],
      dateOfBirth: [''],
    });
  }

  loadPatients(): void {
    const filters: PatientFilter = {
      ...this.searchForm.value,
      pageNumber: this.currentPage,
      pageSize: this.pageSize
    };
    this.subs.sink = this.patientService.getPatients(filters)
      .subscribe({
        next: (result) => {
          this.patients = result.body;
          const paginationData = JSON.parse(
            result.headers.get('x-pagination')!
          );
          this.totalItems = paginationData.TotalItemCount;
          this.currentPage = paginationData.CurrentPage;
        },
        error: (error) => {
          console.error('Error loading patients from server:', error);
        }
      });
  }


  // Function to handle query parameters
  private handleQueryParams(queryParams: ParamMap): void {
    const editId = queryParams.has('edit');
    if (editId) {
      this.openModal();
    }
    const shouldOpenModal = queryParams.has('add') && queryParams.get('add') === 'true';
    if (shouldOpenModal) {
      this.openModal();
    }
  }

  search(filters: PatientFilter): void {
    this.currentPage = 1;
    this.searchForm.patchValue(filters);
    this.loadPatients(); // Optionally, trigger loading patients after applying search filters
  }

  pageChanged(page: number): void {
    this.currentPage = page;
    this.loadPatients();
  }

  deletePatient(patientId: number): void {
    this.subs.sink = this.patientService.deletePatient(patientId)
      .subscribe({
        next: () => {
          // Decrement totalItems as one patient is deleted
          this.totalItems--;

          // Calculate the new total number of pages after deletion
          const totalPages = Math.ceil(this.totalItems / this.pageSize);

          // Adjust current page if it exceeds the new total number of pages
          if (this.currentPage > totalPages) {
            this.currentPage = totalPages;
            this.loadPatients(); // Reload patients with updated pagination
            // Update the URL to reflect the current page
            this.router.navigate([], {
              relativeTo: this.route,
              queryParams: { currentPage: this.currentPage },
              queryParamsHandling: 'merge' // Merge with existing query parameters
            });
          } else {
            // Remove the deleted patient locally
            this.patients = this.patients.filter(patient => patient.patientId !== patientId);
          }
        },
        error: (error) => {
          console.error('Error deleting patient:', error);
          // Handle error appropriately
        }
      });
  }


  openModal(): void {
    this.isModalOpen = true;
  }

  closeModal(): void {
    this.router.navigate([]);
    this.isModalOpen = false;
    this.loadPatients();
  }


}
