import { Component, OnDestroy, OnInit } from '@angular/core';
import { SubSink } from 'subsink';
import { ReservationService } from '../service/reservation.service';
import { LocalDataSource } from 'ng2-smart-table';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ReservationFilter } from '../Model/reservationFilter';
import { GenderPatient } from '../Model/genderPatient';
import * as XLSX from 'xlsx';
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
  reservationFilter!: ReservationFilter;
  reservations: ReservationFilter[] = [];
  toggleBtnForState: boolean = false;
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


  constructor(private reservationService: ReservationService,
    private formBuilder: FormBuilder) { }
  ngOnInit(): void {
    this.initializeForm();
    this.loadReservations();
  }
  initializeForm(): void {
    this.searchForm = this.formBuilder.group({
      reservationStart: [''],
      reservationEnd: [''],
      clinicId: [0],
      firstName: [""],
      lastName: [""],
      dateOfBirth: [''],
      gender: [GenderPatient.Unknown],
      region: [""],
      phoneNumber: [""],
      date: [''],
      bookFor: [''],
      pageNumber: [1],
      pageSize: [50],
    });
  }

  loadReservations() {
    const filters: ReservationFilter = {
      //'2022-02-19 00:00:00.0000000'
      reservationStart: this.searchForm.value.reservationEnd,
      //'2025-02-19 00:00:00.0000000'
      reservationEnd: this.searchForm.value.reservationStart,
      clinicId: this.searchForm.value.clinicId,
      firstName: '',
      lastName: '',
      gender: GenderPatient.Unknown,
      region: '',
      phoneNumber: '',
      pageNumber: 1,
      pageSize: 10
    };
    console.table(filters);
    this.subs.sink = this.reservationService.getReservations(filters)
      .subscribe({
        next: (result) => {
          this.reservations = result.body;
          const reservationData = JSON.parse(
            result.headers.get('x-pagination')!
          );
          this.totalItems = reservationData.TotalItemCount;
          this.currentPage = reservationData.CurrentPage;
          console.log(this.reservations);
          this.source.load(this.reservations);
        },
        error: (error) => {
          console.log(error);
          // Handle error appropriately, e.g., display an error message to the user
        }
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
    const filter = {
      reservationStart: filters.reservationStart,
      reservationEnd: filters.reservationEnd,
      clinicId: filters.clinicId,
      firstName: '',
      lastName: '',
      dateOfBirth: '',
      gender: '',
      region: '',
      phoneNumber: '',
      date: '',
      bookFor: '',
      pageNumber: filters.pageNumber,
      pageSize: filters.pageSize,
    }
    console.log("Print Filter: ");
    console.table(filter);
    this.searchForm.patchValue(filter);
    console.log("Print searchForm: ");
    console.table(this.searchForm.value);
    this.loadReservations();
  }
  ShowHideSelect(): void {
    this.toggleBtnForState = !this.toggleBtnForState;
  }
  /**Default name for excel file when download**/
  fileName = 'ExcelSheet.xlsx';

  exportexcel() {
    /**passing table id**/
    let data = document.getElementById('table-data');
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(data);

    /**Generate workbook and add the worksheet**/
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

    /*save to file*/
    XLSX.writeFile(wb, this.fileName);
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

}