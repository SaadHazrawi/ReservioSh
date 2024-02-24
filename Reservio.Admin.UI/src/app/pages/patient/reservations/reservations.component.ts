import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { SubSink } from 'subsink';
import { ReservationService } from '../service/reservation.service';
import { LocalDataSource } from 'ng2-smart-table';
import { FormGroup } from '@angular/forms';
import { ReservationFilter } from '../Model/reservationFilter';
import { GenderPatient } from '../Model/genderPatient';
import { ReservationFilterComponent } from '../reservation-filter/reservation-filter.component';
@Component({
  selector: 'ngx-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.scss']
})
export class ReservationsComponent implements OnInit, OnDestroy {
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


  constructor(private reservationService: ReservationService) {
  }

  ngOnInit(): void {
    const reservationFilter: ReservationFilter = {
      reservationStart: '2022-02-19 00:00:00.0000000',
      reservationEnd: '2025-02-19 00:00:00.0000000',
      clinicId: 0,
      firstName: '',
      lastName: '',
      gender: GenderPatient.Unknown,
      region: '',
      phoneNumber: '',
      pageNumber: 1,
      pageSize: 10
    };
    this.subs.sink = this.reservationService.getReservations(reservationFilter)
      .subscribe({
        next: (data) => {
          this.source.load(data.body);
        },
        error: (error) => {
          console.log(error);
        },
      });
  }


  onCheckConfirm(event): void {
    if (window.confirm("Are you sure?")) {
      this.subs.sink = this.reservationService.MarkReservationAsPatientVisitReviewed(event.data.reservationId).subscribe({
        next: () => {
          event.confirm.resolve();
        },
        error: (error) => {
          console.log(error);
        },
      });
    }
  }

  search(filters: ReservationFilter) {
    this.currentPage = 1;
    this.searchForm.patchValue(filters);
    //this.loadPatients();
  }


  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}