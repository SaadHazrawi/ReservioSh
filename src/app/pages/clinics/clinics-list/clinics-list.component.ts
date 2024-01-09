import { Component, OnDestroy, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { SmartTableData } from '../../../@core/data/smart-table';
import { ClinicService } from '../services/clinic.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { SubSink } from 'subsink';

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
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    columns: {
      clinicId: {
      title: 'ID',
      type: 'number',
      },
      name: {
      title: 'Name',
      type: 'string',
      },
      countPatientAccepted: {
      title: 'Accepted Patients',
      type: 'number',
      },
      isDeleted: {
      title: 'Deleted',
      type: 'boolean',
      },
      },
  };

  source: LocalDataSource = new LocalDataSource();

  constructor(private clinicService: ClinicService) { }

  ngOnInit(): void {
    this.clinicService.getClinics(1, 100).subscribe({
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
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

}
