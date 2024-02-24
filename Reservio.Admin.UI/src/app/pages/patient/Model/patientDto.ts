import { GenderPatient } from "./genderPatient";


export interface PatientDto {
    patientId: number;
    firstName: string;
    lastName: string;
    region: string;
    gender: GenderPatient;
    dateOfBirth: string;
}


