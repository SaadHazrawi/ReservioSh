import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ScheduleComponent } from './schedule/schedule.component';
import { RouterModule } from '@angular/router';
import { ScheduleService } from './services/schedule.service';
import { HttpClientModule } from '@angular/common/http';
import { PatientsTableComponent } from './patients-table/patients-table.component';



@NgModule({
  declarations: [
    ScheduleComponent,
    PatientsTableComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule.forChild([
      {
        path: '', component:ScheduleComponent ,  
      },
      {
        path: 'patients', component:PatientsTableComponent  ,  
      },
     
    ])
  ],
  providers: [
    ScheduleService,
  ]
})
export class ClinicModule { }
