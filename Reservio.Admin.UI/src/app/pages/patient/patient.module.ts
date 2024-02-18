import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservationsComponent } from './reservations/reservations.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    ReservationsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: 'x', component: ReservationsComponent,
      },

    ])
    
  ]
})
export class PatientModule { }
