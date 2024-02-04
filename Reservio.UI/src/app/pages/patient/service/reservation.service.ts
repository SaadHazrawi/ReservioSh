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

  getReservationsByDate(clinicId: number, startDate: Date, endDate: Date): Observable<any[]> {
    const url = `${this.apiUrl}/GetReservationsByDate`;
    const params = {
      clinicId: clinicId.toString(),
      startDate: startDate.toISOString(),
      endDate: endDate.toISOString()
    };
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    return this.http.get<any[]>(url, { params, headers });
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
