import { Gender } from "../Enums/Gender";

export interface IBookingForAdd {
    clinicId: number;
    fullName: string;
    dateOfBirth: string;
    gender: Gender;
    phoneNumber: string;
    ipAddress:string;

}

