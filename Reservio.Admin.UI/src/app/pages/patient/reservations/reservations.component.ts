import { Component, OnDestroy, OnInit } from '@angular/core';
import { SubSink } from 'subsink';
import { ReservationService } from '../service/reservation.service';
import { log } from 'console';

@Component({
  selector: 'ngx-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.scss']
})
export class ReservationsComponent implements OnInit , OnDestroy {

  x:any[];
  private subs = new SubSink();

  constructor(private reservationService: ReservationService) { }

  ngOnInit(): void {
    this.subs.sink = this.reservationService.getReservationsByDate(1,new Date() , new Date()).subscribe({
      next: (data) => {
      this.x=data;
      console.log(data);
      
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
