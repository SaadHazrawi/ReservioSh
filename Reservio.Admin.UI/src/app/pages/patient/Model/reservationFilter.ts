import { GenderPatient } from "./genderPatient";

export interface ReservationFilter {
    reservationStart: string;
    reservationEnd: string;
    clinicId: number;
    firstName: string;
    lastName: string;
    dateOfBirth?: string;
    gender: GenderPatient;
    region: string;
    phoneNumber: string;
    date?: string;
    bookFor?: string;
    pageNumber: number;
    pageSize: number;
}
