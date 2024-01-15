import { Component, OnDestroy, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { SubSink } from 'subsink';
import { ScheduleService } from '../Services/schedule.service';

@Component({
  selector: 'ngx-schedule-table',
  templateUrl: './schedule-table.component.html',
  styleUrls: ['./schedule-table.component.scss']
})
export class ScheduleTableComponent implements OnInit, OnDestroy {
  private subs = new SubSink();

  settings = {
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
      confirmCreate: true,
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
      confirmSave: true,
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    columns: {
      day: {
        title: "Day",
        type: "string",
      },
      clinic: {
        title: "Clinic",
        type: "string",
      },
      doctor: {
        title: "Doctor",
        type: "string",
      },
    },
  
  };

  source: LocalDataSource = new LocalDataSource();

  constructor(private scheduleService: ScheduleService) {}

  ngOnInit(): void {
    this.subs.sink = this.scheduleService.getSchedulesForEdit().subscribe({
      next: (data) => {
        this.source.load(data.body);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm("Are you sure you want to delete?")) {
      this.subs.sink = this.scheduleService
        .deleteSchedule(event.data.scheduleId)
        .subscribe({
          next: () => {
            event.confirm.resolve();
          },
          error: (error) => {
            console.log(error);
          },
        });
    } else {
      event.confirm.reject();
    }
  }

  onCreateConfirm(event): void {
    this.subs.sink = this.scheduleService.addSchedule(event.newData).subscribe({
      next: () => {
        event.confirm.resolve();
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  onSaveConfirm(event): void {
    this.subs.sink = this.scheduleService.updateSchedule(event.newData).subscribe({
      next: () => {
        event.confirm.resolve();
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}