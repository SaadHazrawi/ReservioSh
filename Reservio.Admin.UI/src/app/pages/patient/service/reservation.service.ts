import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getReservationsByDate(clinicId: number, startDate: Date, endDate: Date, pageNumber: number, pageSize: number)
  : Observable<HttpResponse<any[]>> {
    const params = {
      ClinicId: clinicId.toString(),
      StartDate: startDate.toISOString(),
      EndDate: endDate.toISOString(),
      PageNumber: pageNumber.toString(),
      PageSize: pageSize.toString()
    };
    const url = `${this.apiUrl}Reservations/GetReservationsByDate`;
    return this.http.get<any[]>(url, { observe: 'response', params });
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
