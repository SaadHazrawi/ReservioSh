import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { FormBookingComponent } from "./form-booking/form-booking.component";
import { HttpClientModule } from "@angular/common/http";
import { BookingService } from "./services/booking.service";
import { ScheduleComponent } from './schedule/schedule.component';
import { GoogleSigninComponent } from "./google-signin/google-signin.component";

@NgModule({
  declarations: [
    FormBookingComponent,
    ScheduleComponent,
    GoogleSigninComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forChild([
      {
        path: '', component: FormBookingComponent,
      },
      {
        path: 'schedule', component: ScheduleComponent,
      },
    ])
  ],  
  providers: [
    BookingService
  ]
})
export class ReservationModule { }
