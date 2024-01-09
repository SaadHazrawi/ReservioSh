import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClinicsListComponent } from './clinics-list/clinics-list.component';
import { ClinicsComponent } from './ClinicsComponent';



const routes: Routes = [{
  path: '',
  component: ClinicsComponent,
  children: [
    {
      path: 'clinics-list',
      component: ClinicsListComponent,
    },
  ],
}];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})


export class ClinicsRoutingModule { }
export const routedComponents = [
  ClinicsComponent,
  ClinicsListComponent
];
