import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { NbCalendarRange, NbDateService } from '@nebular/theme';
import { ReservationFilter } from '../Model/reservationFilter';
import { ClinicService } from '../../clinics/services/clinic.service';

@Component({
  selector: 'ngx-reservation-filter',
  templateUrl: './reservation-filter.component.html',
  styleUrls: ['./reservation-filter.component.scss']
})
export class ReservationFilterComponent implements OnInit {
  @Input() clinics: any[];
  @Output() searchFilters = new EventEmitter<ReservationFilter>();
  clinicId!: any;
  searchForm: FormGroup;
  range: NbCalendarRange<Date>;
  toggleBtnForState: boolean = false;
  selectedOption;
  isApplayFilter: boolean = false;
  constructor(private fb: FormBuilder, protected dateService: NbDateService<Date>, private clinicServices: ClinicService) {
    this.initForm();
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
      this.searchFilters.emit(filters);
    }
  }
  selectedClinic(clinic: any): void {
    this.searchForm.patchValue({ clinicId: clinic.clinicId });
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


