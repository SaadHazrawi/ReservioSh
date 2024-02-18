import { Gender } from "../Enums/Gender";

export interface BookingForAdd {
    clinicId: number;
    firstName: string;
    lastName: string;
    regoin: string;
    dateOfBirth: string;
    gender: Gender;
    phoneNumber: string;
    ipAddress:string;
}

