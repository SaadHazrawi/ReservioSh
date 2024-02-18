import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getReservationsByDate(clinicId: number, startDate: Date, endDate: Date, pageNumber: number, pageSize: number): Observable<any[]> {
    const params = {
      ClinicId: clinicId.toString(),
      StartDate: startDate.toISOString(),
      EndDate: endDate.toISOString(),
      PageNumber: pageNumber.toString(),
      PageSize: pageSize.toString()
    };
    const url = `${this.apiUrl}Reservations/GetReservationsByDate`;
    return this.http.get<any[]>(url, { params });
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
