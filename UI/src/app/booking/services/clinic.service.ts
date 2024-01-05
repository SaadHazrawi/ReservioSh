import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { IClinic } from '../Model/IClinic';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClinicService {

  constructor(private http: HttpClient) { }

  apiUrl = environment.apiUrl;

  getClinics(): Observable<IClinic[]> {
    const url = this.apiUrl+'/Booking/Clinics';
    return this.http.get<IClinic[]>(url).pipe(
      catchError((error) => {
        console.log('Error: Could not connect to server.', error);
        return throwError(error.message);
      })
    );
  }
}