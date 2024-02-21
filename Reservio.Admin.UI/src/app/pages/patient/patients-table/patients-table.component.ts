import { Component, OnDestroy, OnInit } from '@angular/core';
import { SubSink } from 'subsink';
import { PatientService } from '../service/patient.service';
import { LocalDataSource } from 'ng2-smart-table';
import { FormGroup } from '@angular/forms';
import { PatientFilter } from '../Model/PatientFilter';
import { GenderPatient } from '../Model/GenderPatient';

@Component({
  selector: 'ngx-patients-table',
  templateUrl: './patients-table.component.html',
  styleUrls: ['./patients-table.component.scss']
})
export class PatientsTableComponent implements OnInit, OnDestroy {
  private subs = new SubSink();
  searchForm!: FormGroup;
  totalPages!: number;
  currentPage: number = 1;
  PageSize: number = 50;
  totalItems!: number;

  settings = {
    delete: {
      deleteButtonContent: '<i class="fas fa-check"></i>',
      confirmDelete: true,
    },
    columns: {
      firstName: {
        title: "First Name",
        type: "string",
      },
      lastName: {
        title: "Last Name",
        type: "string",
      },
      dateOfBirth: {
        title: "Date of Birth",
        type: "html",
        valuePrepareFunction: (date) => {
          const formattedDate = new Date(date).toDateString();
          return `<span style="width: 50px; display: inline-block;">${formattedDate}</span>`
        }
      },
      gender: {
        title: "Gender",
        type: "string",
      },
      region: {
        title: "Region",
        type: "string",
      },
      phoneNumber: {
        title: "Phone Number",
        type: "string",
      },
      date: {
        title: "Date",
        type: "html",
        valuePrepareFunction: (date) => {
          const formattedDate = new Date(date).toDateString();
          return `<span style="width: 50px; display: inline-block;">${formattedDate}</span>`
        }
      },
      bookFor: {
        title: "Book For",
        type: "html",
        valuePrepareFunction: (date) => {
          const formattedDate = new Date(date).toDateString();
          return `<span style="width: 50px; display: inline-block;">${formattedDate}</span>`
        },
        clinic: {
          title: "Clinic",
          type: "string",
        },
      },
    },
    actions: {
      columnTitle: '',
      add: false,
      edit: false,
      position: 'left'
    },
  };
  source: LocalDataSource = new LocalDataSource();

  constructor(private patientService: PatientService) {
  }

  ngOnInit(): void {
    const patientFilter: PatientFilter = {
      firstName: '',
      lastName: '',
      region: '',
      gender: GenderPatient.Unknown,
      dateOfBirth: '',
      pageNumber: 1,
      pageSize: 50
    };
    this.subs.sink = this.patientService.getPatients(patientFilter)
      .subscribe({
        next: (data) => {
          this.source.load(data.body);
        },
        error: (error) => {
          console.log(error);
        },
      });
  }



  search(filters: PatientFilter) {
    this.currentPage = 1;
    this.searchForm.patchValue(filters);
    //this.loadPatients();
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}