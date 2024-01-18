import {
  HttpClient,
  HttpResponse,
  HttpErrorResponse,
} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { environment } from "../../../../environments/environment";
import { ScheduleForEditDto } from "../Model/ScheduleForEditDto";
import { ScheduleForAddDto } from "../Model/ScheduleForAddDto";

@Injectable({
  providedIn: "root",
})
export class ScheduleService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  deleteSchedule(scheduleId: string): Observable<any> {
    return this.http
      .delete(`${this.apiUrl}Schedules/${scheduleId}`)
      .pipe(catchError(this.handleError));
  }

  updateSchedule(formData: any): Observable<any> {
    // Remove any unnecessary fields
    const obj = {
      scheduleId:formData.scheduleId,
      clinicId: parseInt(formData.clinic),
      doctorId: parseInt(formData.doctor),
      day: parseInt(formData.day)
    };
    const url = `${this.apiUrl}Schedules`;
    return this.http
      .put<any>(url, obj)
      .pipe(catchError(this.handleError));
  }
  addSchedule(formData: any): Observable<any> {
    const obj = {
      clinicId: parseInt(formData.clinic),
      doctorId: parseInt(formData.doctor),
      day: parseInt(formData.day)
    };
    const url = `${this.apiUrl}Schedules`;
    return this.http.post<any>(url, obj).pipe(
      catchError(this.handleError)
    );
  }

  getScheduleById(scheduleId: string): Observable<any> {
    return this.http
      .get<any>(`${this.apiUrl}Schedules/${scheduleId}`)
      .pipe(catchError(this.handleError));
  }

  getSchedule(): Observable<any> {
    let url = `${this.apiUrl}Schedules/View`;
    return this.http.get(url).pipe(catchError(this.handleError));
  }
   
  getSchedulesForEdit(): Observable<HttpResponse<ScheduleForEditDto>> {
    let url = `${this.apiUrl}Schedules`;
    return this.http
      .get<ScheduleForEditDto>(url, { observe: "response" })
      .pipe(catchError(this.handleError));
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
