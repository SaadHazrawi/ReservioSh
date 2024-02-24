import { NgModule } from "@angular/core";
import { ReservationsComponent } from "./reservations/reservations.component";
import { Ng2SmartTableModule } from "ng2-smart-table";
import { NbCalendarRangeModule, NbCardModule, NbIconModule, NbInputModule, NbSelectModule } from "@nebular/theme";
import { ThemeModule } from "../../@theme/theme.module";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { ReservationFilterComponent } from './reservation-filter/reservation-filter.component';
import { ReactiveFormsModule } from "@angular/forms";
import { PatientsTableComponent } from './patients-table/patients-table.component';
import { MatDialogModule } from "@angular/material/dialog";

@NgModule({
  declarations: [
    ReservationsComponent,
    ReservationFilterComponent,
    PatientsTableComponent,
  ],
  imports: [
    CommonModule,
    ThemeModule,
    Ng2SmartTableModule,
    NbCardModule,
    NbIconModule,
    NbInputModule,
    ReactiveFormsModule,
    NbCalendarRangeModule,
    NbSelectModule,
    MatDialogModule,
    RouterModule.forChild([
      {
        path: 'reservations', component: ReservationsComponent,
      },
      {
        path: '', component: PatientsTableComponent,
      },

    ])
    
  ]
})
export class PatientModule { }
