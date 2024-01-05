import { Component, OnInit } from '@angular/core';
import { ScheduleService } from '../services/schedule.service';
import { IScheduleForView } from '../Model/IScheduleForView';
import { ISchedule } from '../Model/ISchedule';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})

export class ScheduleComponent implements OnInit {


  days!: IScheduleForView[];

  constructor(private scheduleService: ScheduleService) {}

  ngOnInit() {
    this.scheduleService.getSchedule().subscribe((schedule: ISchedule[]) => {
      const uniqueDays = [...new Set(schedule.map(item => item.day))];
      this.days = uniqueDays.map(day => ({
        name: day,
        clinics: schedule.filter(item => item.day === day).map(item => ({ name: item.clinicName }))
      }));
    });
  }
}


