import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { ClinicCreationDTO } from '../Model/ClinicCreationDTO';

@Injectable({
  providedIn: 'root'
})
export class ClinicService {

  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  deleteClinic(clinicId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}Clinics/${clinicId}`)
      .pipe(catchError(this.handleError));
  }

  updateClinic(formData: any): Observable<any> {
     // Remove the isDeleted field
    const { isDeleted, ...updatedFormData } = formData;
    const url = `${this.apiUrl}Clinics`;
    console.log(formData);
    return this.http.put<any>(url, updatedFormData).pipe(
      catchError(this.handleError)
    );
  }
  
  addClinic(formData: ClinicCreationDTO): Observable<any> {
    const data: ClinicCreationDTO = {
      name: formData.name,
      acceptedPatientsCount: formData.acceptedPatientsCount,
    };
    const url = `${this.apiUrl}Clinics`;
    return this.http.post<any>(url, data).pipe(
      catchError(this.handleError)
    );
  }

  getClinicById(clinicId: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}Clinics/${clinicId}`)
      .pipe(catchError(this.handleError));
  }

  getClinics(): Observable<HttpResponse<any[]>> {
    let url = `${this.apiUrl}Clinics`;
    return this.http.get<any[]>(url, { observe: 'response' }).pipe(
    catchError(this.handleError));
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
