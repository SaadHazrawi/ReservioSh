import { NgModule } from "@angular/core";
import { ReservationsComponent } from "./reservations/reservations.component";
import { Ng2SmartTableModule } from "ng2-smart-table";
import { NbCalendarRangeModule, NbCardModule, NbDatepickerModule, NbIconModule, NbInputModule, NbSelectModule } from "@nebular/theme";
import { ThemeModule } from "../../@theme/theme.module";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { ReservationFilterComponent } from './reservation-filter/reservation-filter.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { PatientsTableComponent } from './patients-table/patients-table.component';
import { PatientsFilterComponent } from './patients-filter/patients-filter.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { PatientsFormComponent } from './patients-form/patients-form.component';

@NgModule({
  declarations: [
    ReservationsComponent,
    ReservationFilterComponent,
    PatientsTableComponent,
    PatientsFilterComponent,
    PatientsFormComponent,
  ],
  imports: [
    CommonModule,
    ThemeModule,
    Ng2SmartTableModule,
    NbCardModule,
    NbIconModule,
    NbInputModule,
    ReactiveFormsModule,
    FormsModule,
    NbCalendarRangeModule,
    NbSelectModule,
    NgxPaginationModule,
    NbDatepickerModule,
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
