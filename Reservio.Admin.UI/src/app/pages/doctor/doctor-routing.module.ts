import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorTableComponent } from './doctor-table/doctor-table.component';
 import { DoctorsComponent } from './DoctorsComponent';

const routes: Routes = [{
 path: '',
component: DoctorTableComponent,
children: [
  {
    path: 'doctor-table',
    component: DoctorTableComponent,
  },
],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { }
export const routedComponents = [
  DoctorsComponent,
  DoctorTableComponent
];
