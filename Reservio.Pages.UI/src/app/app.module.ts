import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      // {
      //   path: 'Home',
      //   loadChildren: () => import('./booking/booking.module').then((b) => b.BookingModule),
      // },
      {
        path: 'booking',
        loadChildren: () => import('./reservation/reservation.module').then((b) => b.ReservationModule),
      },

      { path: '', redirectTo: 'booking', pathMatch: 'full' },
      { path: '**', redirectTo: 'booking', pathMatch: 'full' },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
