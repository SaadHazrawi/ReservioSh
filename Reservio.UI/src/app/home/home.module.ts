import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main/main.component';
import { RouterModule } from '@angular/router';
import { ThemeModule } from '../@theme/theme.module';
import { HomeComponent } from './home.component';
import { NbMenuModule, NbSidebarModule, NbSpinnerModule, NbThemeModule } from '@nebular/theme';
import { DashboardModule } from '../pages/dashboard/dashboard.module';
import { ECommerceModule } from '../pages/e-commerce/e-commerce.module';
import { MiscellaneousModule } from '../pages/miscellaneous/miscellaneous.module';



@NgModule({
  declarations: [
    MainComponent,
    HomeComponent,
  ],
  imports: [
    CommonModule,
    NbThemeModule.forRoot({ name: 'cosmic' }),
    RouterModule.forChild([
      { path: '', component: MainComponent },
      { path: '**', redirectTo: '', pathMatch: 'full' }
    ])
  ]
})
export class HomeModule { }
