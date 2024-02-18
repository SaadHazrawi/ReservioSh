import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../../environments/environment';
import { ClinicCreationDTO } from '../../clinics/Model/ClinicCreationDTO';
import { DoctorCreation } from '../Model/DoctorCreation';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  deleteClinic(clinicId: any) {
    throw new Error('Method not implemented.');
  }
  addClinic(newData: any) {
    throw new Error('Method not implemented.');
  }
  updateClinic(newData: any) {
    throw new Error('Method not implemented.');
  }
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  deleteDoctor(doctorId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}Doctors/${doctorId}`)
      .pipe(catchError(this.handleError));
  }

  updateDoctor(formData: any): Observable<any> {
    // Remove the isDeleted field
    const { isDeleted, ...updatedFormData } = formData;
    const url = `${this.apiUrl}Doctors`;
    console.log(formData);
    return this.http.put<any>(url, updatedFormData).pipe(
      catchError(this.handleError)
    );
  }
  
  addDoctor(formData: DoctorCreation): Observable<any> {
    const data: DoctorCreation = {
      fullName: formData.fullName,
      specialist: formData.specialist,
    };
    const url = `${this.apiUrl}Doctors`;
    return this.http.post<any>(url, data).pipe(
      catchError(this.handleError)
    );
  }

  getDoctorById(doctorId: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}Doctors/${doctorId}`)
      .pipe(catchError(this.handleError));
  }
 
  getDoctors(pageNumber: number, pageSize: number): Observable<HttpResponse<any[]>> {
    let url = `${this.apiUrl}Doctors`;
    return this.http.get<any[]>(url, { observe: 'response' }).pipe(
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