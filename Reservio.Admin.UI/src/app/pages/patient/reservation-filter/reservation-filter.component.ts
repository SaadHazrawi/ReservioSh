import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ReservationSearchFilters } from '../Model/ReservationSearchFilters';
import { NbCalendarRange, NbDateService } from '@nebular/theme';

@Component({
  selector: 'ngx-reservation-filter',
  templateUrl: './reservation-filter.component.html',
  styleUrls: ['./reservation-filter.component.scss']
})
export class ReservationFilterComponent {
  @Input() clinic:any[];
  @Output() searchFilters = new EventEmitter<ReservationSearchFilters>(); 
  searchForm: FormGroup;
  range: NbCalendarRange<Date>;

  constructor(private fb: FormBuilder,protected dateService: NbDateService<Date>) {
    this.searchForm = this.fb.group({
      clinicId: [0],
      startDate: [null],
      endDate: [null] 
    });
    this.range = {
      start: this.dateService.addDay(this.monthStart, 3),
      end: this.dateService.addDay(this.monthEnd, -3),
    };
  }

  get monthStart(): Date {
    return this.dateService.getMonthStart(new Date());
  }

  get monthEnd(): Date {
    return this.dateService.getMonthEnd(new Date());
  }
  search() {
    if (this.searchForm.valid) {
      const filters: ReservationSearchFilters = this.searchForm.value;
      this.searchFilters.emit(filters);
    }
  }

}