import { NgModule } from '@angular/core';

import { ClinicsListComponent } from './clinics-list/clinics-list.component';
import { NbCardModule, NbIconModule, NbInputModule } from '@nebular/theme';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ThemeModule } from '../../@theme/theme.module';
import { ClinicsRoutingModule, routedComponents } from './clinics-routing.module';
import { PatientModule } from '../patient/patient.module';
@NgModule({
  imports: [
    NbCardModule,
    NbIconModule,
    NbInputModule,
    ThemeModule,
    ClinicsRoutingModule,
    Ng2SmartTableModule,
    PatientModule
  ],
  declarations: [
    ...routedComponents,
    ClinicsListComponent,
  ],
})
export class ClinicsModule { }
