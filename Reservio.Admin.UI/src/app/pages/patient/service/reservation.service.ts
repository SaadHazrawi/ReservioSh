import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { ReservationFilter } from '../Model/reservationFilter';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getReservations(reservationFilter: ReservationFilter): Observable<HttpResponse<any[]>> {
    let url = `${this.apiUrl}Reservations`;
    let queryParams = `?pageNumber=${reservationFilter.pageNumber}&pageSize=${reservationFilter.pageSize}`;
    console.log(reservationFilter.clinicId);

    if (reservationFilter.clinicId) {
      queryParams += `&clinicId=${reservationFilter.clinicId}`;
    }
    if (reservationFilter.firstName) {
      queryParams += `&firstName=${reservationFilter.firstName}`;
    }
    if (reservationFilter.lastName) {
      queryParams += `&lastName=${reservationFilter.lastName}`;
    }
    if (reservationFilter.region) {
      queryParams += `&region=${reservationFilter.region}`;
    }
    if (reservationFilter.gender !== undefined) {
      queryParams += `&gender=${reservationFilter.gender}`;
    }
    if (reservationFilter.dateOfBirth) {
      queryParams += `&dateOfBirth=${reservationFilter.dateOfBirth}`;
    }
    if (reservationFilter.reservationStart) {
      const formattedReservationStart = this.formatDate(reservationFilter.reservationStart);
      console.log(formattedReservationStart);
      queryParams += `&reservationStart=${formattedReservationStart}`;
    }
    if (reservationFilter.reservationEnd) {
      const formattedReservationEnd = this.formatDate(reservationFilter.reservationEnd);
      queryParams += `&reservationEnd=${formattedReservationEnd}`;
    }
    url += queryParams;
    return this.http.get<any[]>(url, { observe: 'response' });
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
  formatDate(date: string): string {
    const reservationDate = new Date(date);
    const formattedReservationDate = reservationDate.toISOString().slice(0,10)+" 00:00:00.0000000";
    return formattedReservationDate;
  }
}
