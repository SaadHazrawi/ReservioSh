import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DoctorRoutingModule, routedComponents } from './doctor-routing.module';
import { DoctorTableComponent } from './doctor-table/doctor-table.component';
import { NbCardModule, NbIconModule, NbInputModule } from '@nebular/theme';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ThemeModule } from '../../@theme/theme.module';

@NgModule({
 
  imports: [
    CommonModule,
    DoctorRoutingModule,
    NbCardModule,
    NbIconModule,
    NbInputModule,
    ThemeModule,
    Ng2SmartTableModule,
  ],
  declarations: [
    DoctorTableComponent,
    ...routedComponents
  ],
})
export class DoctorModule { }

