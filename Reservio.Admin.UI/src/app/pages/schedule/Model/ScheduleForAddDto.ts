import { DayOfWeek } from "../../../@core/data/DayOfWeek";

export interface ScheduleForAddDto {
    doctorId: number;
    clinicId: number;
    day: DayOfWeek;
}

