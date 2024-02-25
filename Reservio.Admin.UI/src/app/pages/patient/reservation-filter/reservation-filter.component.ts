import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
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
  searchForm: FormGroup;
  range: NbCalendarRange<Date>;
  toggleBtnForState: boolean = false;
  selectedOption;
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
  ShowHideSelect(): void {
    this.toggleBtnForState = !this.toggleBtnForState;
  }
}