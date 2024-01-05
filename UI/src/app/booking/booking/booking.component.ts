import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ClinicService } from '../services/clinic.service';
import { IClinic } from '../Model/IClinic';
import { BookingService } from '../services/Booking.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css'],
})
export class BookingComponent implements OnInit {
  bookingForm!: FormGroup;
  ipAddress!: string;
  clinics: IClinic[] = [];
  reservationStatus:boolean=true;

  constructor(
    private clinicService: ClinicService,
    private bookingService: BookingService,
    private fb: FormBuilder,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.initForm();
    this.getIpAddress();
    this.getClinics();
    
  }

  initForm() {
    this.bookingForm = this.fb.group({
      fullName: ['', [Validators.required, Validators.maxLength(100)]],
      phoneNumber: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      dateOfBirth: ['', Validators.required],
      gender: [0, Validators.required],
      clinicId: [0, Validators.required],
      ipAddress: [null, [Validators.required, Validators.minLength(3)]],
    });
  }

  getIpAddress() {
    this.http.get<{ ip: string }>('https://api.ipify.org/?format=json').subscribe((data) => {
      this.ipAddress = data.ip;
      this.bookingForm.patchValue({ ipAddress: this.ipAddress });
      console.log(this.ipAddress);   
      this.checkReservationStatus();
    });
  }

  getClinics() {
    this.clinicService.getClinics().subscribe((data) => {
      this.clinics = data;
    });
  }

  checkReservationStatus(): void {
    this.bookingService.reservationStatus(this.ipAddress).subscribe((response) => {
      if (response.stopping) {
        this.reservationStatus=false;
        this.appendAlert(`${response.status}\n${response.stoppingTo}`, 'warning');
      }
    }, (error) => {
      console.log('Error: Could not connect to server.', error);
    });
  }

  onSubmit() {
    this.bookingService.submitBooking(this.bookingForm.value).subscribe((response) => {
      console.log('Booking successful.', 'success');
      this.bookingForm.reset();
      this.checkReservationStatus();
    }, (error) => {
      console.log(error, 'danger');
    });
  }

  appendAlert(message: string, type: string) {
    const alertPlaceholder = document.getElementById('div-message')!;
    const wrapper = document.createElement('div');
    wrapper.innerHTML = `
      <div class="alert alert-${type} alert-dismissible" role="alert">
        <div>${message}</div>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
      </div>
    `;
    alertPlaceholder.append(wrapper);
  }
  
}