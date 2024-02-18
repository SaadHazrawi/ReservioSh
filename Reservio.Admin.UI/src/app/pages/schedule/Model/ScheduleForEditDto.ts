import { DoctorForScheduleDto } from "./DoctorForScheduleDto";
import { ClinicForScheduleDto } from "./ClinicForScheduleDto";
import { Schedule } from "./Schedule";





export interface ScheduleForEditDto {
  doctors: DoctorForScheduleDto[];
  clinics: ClinicForScheduleDto[];
  schedules: Schedule[];
}
