import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BookingComponent } from './booking/booking.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ClinicService } from './services/clinic.service';
import { BookingService } from './services/Booking.service';

@NgModule({
  declarations: [
    BookingComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: '', component: BookingComponent,
      },
    ])
  ],
  providers: [
    ClinicService,
    BookingService
  ]
})
export class BookingModule { }
