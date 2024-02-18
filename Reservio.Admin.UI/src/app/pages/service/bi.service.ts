import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { throwError } from "rxjs";
import { environment } from "../../../environments/environment";
import { Observable } from "rxjs-compat";
import { catchError } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class BIService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  GetCountByGenderPatient(): Observable<any> {
    return this.http
      .get<any>(`${this.apiUrl}BI/GetCountByGenderPatient`)
      .pipe(catchError(this.handleError));
  }
  GetPatientInWeek(): Observable<any> {
    return this.http
      .get<any>(`${this.apiUrl}BI/GetPatientInWeek`)
      .pipe(catchError(this.handleError));
  }
  GetPatientInClinic(): Observable<any> {
    return this.http
      .get<any>(`${this.apiUrl}BI/GetPatientInClinic`)
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
