import { Component, OnInit } from '@angular/core';
import { ScheduleForView } from '../Model/ScheduleForView';
import { BookingService } from '../services/booking.service';
import { Schedule } from '../Model/Schedule';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {


  days!: ScheduleForView[];

  constructor(private bookingService: BookingService) {}

  ngOnInit() {
    this.bookingService.getSchedule().subscribe((schedule: Schedule[]) => {
      const uniqueDays = [...new Set(schedule.map(item => item.day))];
      this.days = uniqueDays.map(day => ({
        name: day,
        clinics: schedule.filter(item => item.day === day).map(item => ({ name: item.clinic }))
      }));
    });
  }
}
