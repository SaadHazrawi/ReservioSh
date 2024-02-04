import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NbThemeModule } from '@nebular/theme';
import { HomeComponent } from './home/home.component';




@NgModule({
  declarations: [
    HomeComponent,
  ],
  imports: [
    CommonModule,
    NbThemeModule.forRoot({ name: 'cosmic' }),
    RouterModule.forChild([
      { path: '', component: HomeComponent },
      { path: '**', redirectTo: '', pathMatch: 'full' }
    ])
  ]
})
export class HomeModule { }
