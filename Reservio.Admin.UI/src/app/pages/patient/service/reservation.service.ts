import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { ReservationFilter } from '../Model/ReservationFilter';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getReservations(reservationFilter: ReservationFilter): Observable<HttpResponse<any[]>> {
    const url = `${this.apiUrl}Reservations`;
    var params = {...reservationFilter};
    return this.http.get<any[]>(url, { observe: 'response', params: params });
  }

  MarkReservationAsPatientVisitReviewed(id: number): Observable<any> {
    const url = `${this.apiUrl}Reservations?id=${id}`
    return this.http.delete(url);
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage: string = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Client-side error: ${error.error.message}`;
    } else {
      errorMessage = `Error Code: ${error.status}, Message: ${error?.message}`;
    }
    console.log(errorMessage);
    return throwError(() => errorMessage);
  }
}
