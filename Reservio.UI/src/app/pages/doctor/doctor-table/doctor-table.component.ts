import { Component, OnDestroy, OnInit } from "@angular/core";
import { DoctorService } from "../Services/doctor.service";
import { LocalDataSource } from "ng2-smart-table";
import { SubSink } from "subsink";

@Component({
  selector: "ngx-doctor-table",
  templateUrl: "./doctor-table.component.html",
  styleUrls: ["./doctor-table.component.scss"],
})
export class DoctorTableComponent implements OnInit, OnDestroy {
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
      fullName: {
        title: "Full Name",
        type: "string",
      },
      specialist: {
        title: "Specialist",
        type: "string",
      },
    },
  };

  source: LocalDataSource = new LocalDataSource();

  constructor(private doctorService: DoctorService) {}

  ngOnInit(): void {
    this.subs.sink = this.doctorService.getDoctors(1, 100).subscribe({
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
      this.subs.sink = this.doctorService
        .deleteDoctor(event.data.doctorId)
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
    this.subs.sink = this.doctorService.addDoctor(event.newData).subscribe({
      next: () => {
        event.confirm.resolve();
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  onSaveConfirm(event): void {
    this.subs.sink = this.doctorService.updateDoctor(event.newData).subscribe({
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
