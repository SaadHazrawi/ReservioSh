import { Component } from '@angular/core';
import { ScheduleService } from '../services/schedule.service';

@Component({
  selector: 'app-patients-table',
  templateUrl: './patients-table.component.html',
  styleUrls: ['./patients-table.component.css'],
})
export class PatientsTableComponent {
  patients: any;
  clinics: any;
  constructor(private scheduleService: ScheduleService) {}
  ngOnInit() {
    this.getClinics();
  }

  getClinics() {
    this.scheduleService.getClinics().subscribe((data) => {
      this.clinics = data;
    });
  }

  selectedClinic(event: Event) {
    const clinicId = Number((event.target as HTMLSelectElement).value);
    if (clinicId) {
      this.scheduleService.GetPatientsForDoctor(clinicId).subscribe({
        next: (data) => {
          this.patients = data;
        },
        error: (error) => {
          console.log('An error occurred while fetching the patients.', error);
        }
      });
    }
  }
}