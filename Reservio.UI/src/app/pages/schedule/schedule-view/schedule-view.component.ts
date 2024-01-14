import { Component, OnInit } from '@angular/core';
import { ScheduleService } from '../Services/schedule.service';
import { ScheduleDto } from '../Model/ScheduleDto';
import { ScheduleForView } from '../Model/ScheduleForView';

@Component({
  selector: 'ngx-schedule-view',
  templateUrl: './schedule-view.component.html',
  styleUrls: ['./schedule-view.component.scss']
})
export class ScheduleViewComponent implements OnInit {


  days!: ScheduleForView[];

  constructor(private scheduleService: ScheduleService) {}

  ngOnInit() {
    this.scheduleService.getSchedule().subscribe((schedule: ScheduleDto[]) => {
      const uniqueDays = [...new Set(schedule.map(item => item.day))];
      this.days = uniqueDays.map(day => ({
        name: day,
        clinics: schedule.filter(item => item.day === day).map(item => ({ name: item.clinic }))
      }));
    });
  }
}
