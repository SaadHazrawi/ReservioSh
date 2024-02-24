import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { PatientFilter } from '../Model/patientFilter';
import { catchError, tap } from 'rxjs/operators';
import { PatientDto } from '../Model/patientDto';
import { PatientUpdate } from '../Model/patientUpdate';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getPatients(patientFilter: PatientFilter): Observable<HttpResponse<PatientDto[]>> {
    let url = `${this.apiUrl}Patients`;

    // Constructing query parameters
    let queryParams = `?pageNumber=${patientFilter.pageNumber}&pageSize=${patientFilter.pageSize}`;

    if (patientFilter.firstName) {
      queryParams += `&firstName=${patientFilter.firstName}`;
    }
    if (patientFilter.lastName) {
      queryParams += `&lastName=${patientFilter.lastName}`;
    }
    if (patientFilter.region) {
      queryParams += `&region=${patientFilter.region}`;
    }
    if (patientFilter.gender !== undefined) {
      queryParams += `&gender=${patientFilter.gender}`;
    }
    if (patientFilter.dateOfBirth) {
      queryParams += `&dateOfBirth=${patientFilter.dateOfBirth}`;
    }

    url += queryParams; // Append query parameters to URL

    return this.http.get<PatientDto[]>(url, { observe: 'response' })
      .pipe(
        tap(response => {
          console.log('paginationData : ' + response.headers.get('x-pagination'));
        }),
        catchError(this.handleError)
      );
  };

  getPatientById(patientId: number): Observable<PatientDto> {
    return this.http.get<PatientDto>(`${this.apiUrl}Patients/${patientId}`)
      .pipe(tap(response => {
        console.log(response);
      }),
      catchError(this.handleError))
  };

  addPatient(data: any): Observable<any> {
    const url = `${this.apiUrl}Clinics`;
    return this.http.post<any>(url, data).pipe(
      catchError(this.handleError)
    );
  }

  updatePatient(formData: PatientUpdate): Observable<PatientDto> {
    const url = `${this.apiUrl}Patients`;
    return this.http.put<PatientDto>(url, formData).pipe(
      catchError(this.handleError)
    );
  }

  deletePatient(patientId: number): Observable<void> {
    const url = `${this.apiUrl}Patients/${patientId}`;
    return this.http.delete<void>(url)
      .pipe(
        catchError(this.handleError)
      );
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