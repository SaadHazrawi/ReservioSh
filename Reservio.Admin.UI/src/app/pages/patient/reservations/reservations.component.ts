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

  reservations:any[];
  private subs = new SubSink();

  constructor(private reservationService: ReservationService) { }

  ngOnInit(): void {
    this.subs.sink = this.reservationService.getReservationsByDate(1, new Date('2022-02-19 00:00:00.0000000'), new Date('2025-02-19 00:00:00.0000000'), 1, 10)
      .subscribe(
        (data: any[]) => {
          this.reservations = data;
          console.log(data);
        },
        (error) => {
          console.log(error);
        }
      );
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
