import { Component, OnDestroy, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { ClinicService } from '../services/clinic.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { SubSink } from 'subsink';
import { ClinicForUpdateDTO } from '../Model/ClinicForUpdateDTO';

@Component({
  selector: 'ngx-clinics-list',
  templateUrl: './clinics-list.component.html',
  styleUrls: ['./clinics-list.component.scss']
})
export class ClinicsListComponent implements OnInit, OnDestroy {

  private subs = new SubSink();

  settings = {
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
      confirmCreate: true
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
      confirmSave: true
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    columns: {
      name: {
        title: 'Name',
        type: 'string',
      },
      acceptedPatientsCount: {
        title: 'Accepted Patients',
        type: 'number',
      },
    },
  };

  source: LocalDataSource = new LocalDataSource();

  constructor(private clinicService: ClinicService) { }

  ngOnInit(): void {
    this.subs.sink = this.clinicService.getClinics(1, 100).subscribe({
      next: (data) => {
        this.source.load(data.body);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this.subs.sink = this.clinicService.deleteClinic(event.data.clinicId).subscribe({
        next: () => {
          event.confirm.resolve();
        },
        error: (error) => {
          console.log(error);
        }
      });
    } else {
      event.confirm.reject();
    }
  }

  onCreateConfirm(event): void {
    this.subs.sink = this.clinicService.addClinic(event.newData).subscribe({
      next: () => {
        event.confirm.resolve();
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  onSaveConfirm(event): void {
    this.subs.sink = this.clinicService.updateClinic(event.newData).subscribe({
      next: () => {
        event.confirm.resolve();
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

}