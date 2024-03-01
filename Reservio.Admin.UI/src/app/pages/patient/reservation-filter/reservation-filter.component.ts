import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { NbCalendarRange, NbDateService } from '@nebular/theme';
import { ReservationFilter } from '../Model/reservationFilter';
import { ClinicService } from '../../clinics/services/clinic.service';
import { ClinicForUpdateDTO } from '../../clinics/Model/ClinicForUpdateDTO';

@Component({
  selector: 'ngx-reservation-filter',
  templateUrl: './reservation-filter.component.html',
  styleUrls: ['./reservation-filter.component.scss']
})
export class ReservationFilterComponent implements OnInit {
  @Input() clinics: any[];
  @Output() searchFilters = new EventEmitter<ReservationFilter>();
<<<<<<< HEAD
  clinicId!: any;
=======
>>>>>>> 116813ad69166bc84d919c8e6a7055b494f99737
  searchForm: FormGroup;
  range: NbCalendarRange<Date>;
  toggleBtnForState: boolean = false;
  selectedOption;
<<<<<<< HEAD
  isApplayFilter: boolean = false;
  constructor(private fb: FormBuilder, protected dateService: NbDateService<Date>, private clinicServices: ClinicService) {
    this.initForm();
=======
  constructor(private fb: FormBuilder, protected dateService: NbDateService<Date>, private clinicServices: ClinicService) {

    this.searchForm = this.fb.group({
      clinicId: [0],
      startDate: [null],
      endDate: [null]
    });
    this.range = {
      start: this.dateService.addDay(this.monthStart, 3),
      end: this.dateService.addDay(this.monthEnd, -3),
    };
    this.selectedOption = {
      value: 0,
      name: '0'
    };
>>>>>>> 116813ad69166bc84d919c8e6a7055b494f99737
  }
  ngOnInit(): void {
    this.clinicServices.getClinics().subscribe({
      next: (data) => {
        this.clinics = data.body;

      },
      error: (error) => {
        console.log(error);
      }
    });
  }
  get monthStart(): Date {
    return this.dateService.getMonthStart(new Date());
  }

  get monthEnd(): Date {
    return this.dateService.getMonthEnd(new Date());
  }
  search() {
    if (this.searchForm.valid) {
      const filters: ReservationFilter = this.searchForm.value;
      console.log(filters);

      this.searchFilters.emit(filters);
    }
  }
<<<<<<< HEAD
  selectedClinic(clinic: any): void {
    this.searchForm.patchValue({ clinicId: clinic.clinicId });
=======
  ShowHideSelect(): void {
    this.toggleBtnForState = !this.toggleBtnForState;
>>>>>>> 116813ad69166bc84d919c8e6a7055b494f99737
  }

  onEventStartEndRange(rangeDate: any): void {
    this.searchForm.patchValue({ reservationStart: rangeDate.end, reservationEnd: rangeDate.start });
  }

  ShowHideSelect(): void {
    this.toggleBtnForState = !this.toggleBtnForState;
  }
  ApplayFliter(): void {
    this.isApplayFilter = true;
  }
  clearfilter(): void {
    this.initForm();
    this.isApplayFilter = false;
    this.search();
  }
  initForm(): void {
    this.searchForm = this.fb.group({
      clinicId: [0],
      reservationStart: [null],
      reservationEnd: [null]
    });
    this.range = {
      start: this.dateService.addDay(this.monthStart, 3),
      end: this.dateService.addDay(this.monthEnd, -3),
    };
    this.selectedOption = {
      value: 0,
      name: '0'
    };
  }
}


