import { Component, OnDestroy, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { SubSink } from 'subsink';
import { ScheduleService } from '../Services/schedule.service';
import { ScheduleForEditDto } from '../Model/ScheduleForEditDto';
import { DayOfWeek } from '../../../@core/data/DayOfWeek';

@Component({
  selector: 'ngx-schedule-table',
  templateUrl: './schedule-table.component.html',
  styleUrls: ['./schedule-table.component.scss']
})
export class ScheduleTableComponent implements OnInit, OnDestroy {
  private subs = new SubSink();
  source: LocalDataSource = new LocalDataSource();
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
        title: 'Day',
        editor: {
          type: 'list',
          config: {
            list: [
              { value: DayOfWeek.Sunday, title: 'Sunday' },
              { value: DayOfWeek.Monday, title: 'Monday' },
              { value: DayOfWeek.Tuesday, title: 'Tuesday' },
              { value: DayOfWeek.Wednesday, title: 'Wednesday' },
              { value: DayOfWeek.Thursday, title: 'Thursday' },
              { value: DayOfWeek.Friday, title: 'Friday' },
              { value: DayOfWeek.Saturday, title: 'Saturday' }
            ]
          }
        },
      },
      clinic: {
        title: 'clinic',
        editor: {
          type: 'list',
          config: {
            list: [],
            filter: true
          }
        },
      },
      doctor: {
        title: 'Doctor',
        editor: {
          type: 'list',
          config: {
            list: [],
            filter: true
          }
        },
      }
    },
    actions: {
      columnTitle: '',
      add: true,
      edit: true,
      position: 'left'
    },
  };

  constructor(private scheduleService: ScheduleService) { }

  ngOnInit(): void {
    this.subs.sink = this.scheduleService.getSchedulesForEdit().subscribe({
      next: (data) => {
        const obj: ScheduleForEditDto = data.body;
        this.source.load(obj.schedules);
        this.settings = {
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
              title: 'Day',
              editor: {
                type: 'list',
                config: {
                  list: [
                    { value: DayOfWeek.Sunday, title: 'Sunday' },
                    { value: DayOfWeek.Monday, title: 'Monday' },
                    { value: DayOfWeek.Tuesday, title: 'Tuesday' },
                    { value: DayOfWeek.Wednesday, title: 'Wednesday' },
                    { value: DayOfWeek.Thursday, title: 'Thursday' },
                    { value: DayOfWeek.Friday, title: 'Friday' },
                    { value: DayOfWeek.Saturday, title: 'Saturday' }
                  ]
                }
              },
            },
            clinic: {
              title: 'clinic',
              editor: {
                type: 'list',
                config: {
                  list: obj.clinics
                  , filter: true
                }

              },
            },
            doctor: {
              title: 'Doctor',
              editor: {
                type: 'list',
                config: {
                  list: obj.doctors
                  , filter: true
                }
              },
            }
          },
          actions: {
            columnTitle: '',
            add: true,
            edit: true,
            position: 'left'
          },
        };
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  onDeleteConfirm(event): void {
    if (window.confirm("Are you sure you want to delete?")) {
      this.subs.sink = this.scheduleService.deleteSchedule(event.data.scheduleId).subscribe({
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
        const currentPage = this.source.getPaging().page;
        this.reloadTableData(currentPage);
      },
      error: (error) => {
        console.log('Error occurred:', error);
      },
    });
  }

  onSaveConfirm(event): void {
    this.subs.sink = this.scheduleService.updateSchedule(event.newData).subscribe({
      next: () => {
        event.confirm.resolve();
        const currentPage = this.source.getPaging().page;
        this.reloadTableData(currentPage);
      },
      error: (error) => {
        console.log(error);
        event.confirm.reject();
      },
    });
  }

  private reloadTableData(currentPage: number): void {
    this.subs.sink = this.scheduleService.getSchedulesForEdit().subscribe({
      next: (data) => {
        this.source.load(data.body.schedules);
        this.source.setPaging(currentPage, this.source.getPaging().perPage);
      },
      error: (error) => {
        console.log(error);
      },
    })
  }
}
