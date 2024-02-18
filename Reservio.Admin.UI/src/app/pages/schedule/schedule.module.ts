import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ScheduleRoutingModule, routedComponents } from './schedule-routing.module';
 
import { ScheduleTableComponent } from './schedule-table/schedule-table.component';
import { NbCardModule, NbIconModule, NbInputModule } from '@nebular/theme';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ThemeModule } from '../../@theme/theme.module';
import { ScheduleViewComponent } from './schedule-view/schedule-view.component';

@NgModule({
  declarations: [
    ScheduleTableComponent,
     ...routedComponents,
     ScheduleViewComponent
  ],
  imports: [
    CommonModule,
    ScheduleRoutingModule,
    NbCardModule,
    NbIconModule,
    NbInputModule,
    ThemeModule,
    Ng2SmartTableModule,
   
  ]
})
export class ScheduleModule { }
