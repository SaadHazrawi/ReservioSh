import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Clinic } from '../Model/Clinic';
import { BookingService } from '../services/booking.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-form-booking',
  templateUrl: './form-booking.component.html',
  styleUrls: ['./form-booking.component.css'],
})
export class FormBookingComponent implements OnInit {
  bookingForm!: FormGroup;
  userIpAddress!: string;
  clinics: Clinic[] = [];
  isReservationEnabled: boolean = true;
  isBookingFormHidden = false;

  constructor(
    private bookingService: BookingService,
    private formBuilder: FormBuilder,
    private httpClient: HttpClient
  ) { }

  ngOnInit() {
    this.initializeForm();
    this.getUserIpAddress();
    this.getClinicsForReservations();
  }

  initializeForm() {
    this.bookingForm = this.formBuilder.group({
      firstName: [null, [Validators.required, Validators.maxLength(100)]],
      lastName: [null, [Validators.required, Validators.maxLength(100)]],
      region: [null, [Validators.required, Validators.maxLength(100)]],
      phoneNumber: [
        null,
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(100),
        ],
      ],
      dateOfBirth: [null, Validators.required],
      gender: [0, Validators.required],
      clinicId: [0, Validators.required],
      userIpAddress: [null, [Validators.required, Validators.minLength(3)]],
    });
  }

  getUserIpAddress() {
    this.httpClient
      .get<{ ip: string }>('https://api.ipify.org/?format=json')
      .subscribe((data) => {
        this.userIpAddress = data.ip;
        this.bookingForm.patchValue({ userIpAddress: this.userIpAddress });
        console.log(this.userIpAddress);
        this.checkReservationStatus();
      });
  }

  getClinicsForReservations() {
    this.bookingService.getClinics().subscribe((data) => {
      this.clinics = data;
      if (this.clinics.length === 0) {
        this.hideBookingForm();
        this.appendAlert('No available clinics for reservations', 'warning');
      }
    });
  }

  hideBookingForm() {
    const bookingFormElement = document.getElementById('bookingForm');
    console.log("bookingFormElement.style.display = 'none'");
    if (bookingFormElement) {
      bookingFormElement.style.display = 'none';
      console.log("bookingFormElement.style.display = 'none'");
    }
  }

  checkReservationStatus(): void {
    this.bookingService.reservationStatus(this.userIpAddress).subscribe(
      (response) => {
        if (response.stopping) {
          this.isReservationEnabled = false;
          this.appendAlert(`${response.status}\n${response.stoppingTo }`, 'warning');
        }
      },
      (error) => {
        console.log('Error: Could not connect to the server.', error);
      }
    );
  }

  onSubmit() {
    this.bookingService.submitBooking(this.bookingForm.value).subscribe(
      (response) => {
        console.log('Booking successful.', 'success');
        this.bookingForm.reset();
        this.checkReservationStatus();
      },
      (error) => {
        console.log(error, 'danger');
      }
    );
  }

  appendAlert(message: string, type: string) {
    const alertPlaceholder = document.getElementById('div-message')!;
    if (alertPlaceholder) {
      const wrapper = document.createElement('div');
      wrapper.innerHTML = `<div class="alert alert-${type} alert-dismissible" role="alert">    
                           <div> <strong>${message}</strong>     </div> 
                           <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button> 
                           </div>  ;`
      alertPlaceholder.append(wrapper);
    }
  }
}