import { GenderPatient } from "./genderPatient";

export interface PatientUpdate {
    patientId: number;
    firstName: string;
    lastName: string;
    region: string;
    gender: GenderPatient;
    dateOfBirth: string;
}
