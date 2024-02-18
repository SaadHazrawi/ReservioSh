import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { BookingForAdd } from '../Model/BookingForAdd';
import { environment } from 'src/environments/environment';
import { Clinic } from '../Model/Clinic';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http: HttpClient) { }

  apiUrl = environment.apiUrl;
  reservationStatus(iPAddress: String): Observable<any> {
    const url = this.apiUrl+'Reservations?iPAddress='+iPAddress;
    return this.http.get(url)
      .pipe(
        catchError(this.handleError)
      );
  }


  getSchedule(): Observable<any> {
    let url = `${this.apiUrl}Schedules/View`;
    return this.http.get(url).pipe(catchError(this.handleError));
  }
  getClinics(): Observable<Clinic[]> {
    const url = this.apiUrl + 'Reservations/Clinics';
    return this.http.get<Clinic[]>(url).pipe(
      catchError(this.handleError)
    );
  }

  submitBooking(formData: BookingForAdd): Observable<any> {
    const url = this.apiUrl+'Reservations';

    let bookingForAdd:BookingForAdd ={
     ...formData,
      "gender":  Number(formData.gender),     
    }
    console.log(bookingForAdd);
    return this.http.post<any>(url, bookingForAdd)
      .pipe(
        catchError(this.handleError)
      );
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage: string = "";
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Client-side error: ${error.error.message}`;
    } else {
      errorMessage = `Error Code: ${error.status}, Message: ${error?.message}`;
    }
    console.log(errorMessage);
    return throwError(() => errorMessage);
  }
}

