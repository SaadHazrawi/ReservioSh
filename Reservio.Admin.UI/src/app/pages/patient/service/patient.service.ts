import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { PatientFilter } from '../Model/patientFilter';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }
  
  getPatients(patientFilter: PatientFilter): Observable<HttpResponse<any[]>> {
    const url = `${this.apiUrl}Patients`;
    var params = {...patientFilter};
    return this.http.get<any[]>(url, { observe: 'response', params });
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