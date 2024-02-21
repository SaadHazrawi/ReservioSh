import { GenderPatient } from "./GenderPatient";

export interface PatientFilter {
    firstName: string;
    lastName: string;
    region: string;
    gender: GenderPatient;
    dateOfBirth: string;
    pageNumber: number;
    pageSize: number;
}



