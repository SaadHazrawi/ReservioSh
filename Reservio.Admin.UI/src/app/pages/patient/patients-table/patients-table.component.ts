import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { SubSink } from 'subsink'; // Assuming you are using SubSink for managing subscriptions
import { PatientDto } from '../Model/patientDto';
import { PatientService } from '../service/patient.service';
import { GenderPatient } from '../Model/genderPatient';
import { PatientFilter } from '../Model/patientFilter';
import { LocalDataSource } from 'ng2-smart-table';
import { log } from 'console';

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
  totalPages!: number;
 


  constructor(
    private patientService: PatientService,
    private router: Router,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.initializeForm();
    this.loadPatients();

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
        next: (data) => {
          this.patients=data.body
        },
        error: (error) => {
          console.log(error);
          // Handle error appropriately, e.g., display an error message to the user
        }
      });
  }

  deletePatient(patientId: number) {
    console.log(patientId);
      this.subs.sink = this.patientService.deletePatient(patientId)
        .subscribe({
          next: () => {
          },
          error: (error) => {
            console.log(error);
          }
        });
    
  }


  onCreateConfirm(event): void {
    console.log(event);
    // this.subs.sink = this.patientService.addPatient(event.newData).subscribe({
    //   next: () => {
    //     event.confirm.resolve();
    //   },
    //   error: (error) => {
    //     console.log(error);
    //   },
    // });
  }

  onSaveConfirm(event): void {
    // this.subs.sink = this.doctorService.updateDoctor(event.newData).subscribe({
    //   next: () => {
    //     event.confirm.resolve();
    //   },
    //   error: (error) => {
    //     console.log(error);
    //   },
    // });
  }

  pageChanged(page: number): void {
    this.currentPage = page;
    this.loadPatients();
  }

  // openModal(): void {
  //   this.isModalOpen = true;
  // }

  // closeModal(): void {
  //   this.router.navigate([]);
  //   this.isModalOpen = false;
  // }

  search(filters: PatientFilter): void {
    this.currentPage = 1;
    this.searchForm.patchValue(filters);
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
