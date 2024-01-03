using AutoMapper;
using Reservio.DTOS.Clinic;
using Reservio.DTOS.Doctor;
using Reservio.DTOS.Patient;
using Reservio.DTOS.Reservation;
using Reservio.DTOS.Schedule;
using Reservio.Models;

namespace Reservio.Helpers
{
    public class Proflies : Profile
    {
        public Proflies()
        {
            #region Clinic
            CreateMap<Clinic, ClinicCreationDTO>();
            CreateMap<ClinicCreationDTO, Clinic>();
            CreateMap<Clinic, ClinicWithiutAnyThinkAsync>();
            CreateMap<Clinic, ClinicForUpdateDTO>().ReverseMap();
            CreateMap<Clinic, ClinicDto>();
            #endregion

            #region Doctor
            CreateMap<DoctorForAddDto, Doctor>();
            CreateMap<Doctor, DoctorForAddDto>();
            CreateMap<Doctor, DoctorDTO>();
            #endregion

            #region Patient
            CreateMap<PatientCreationDTO, Patient>();
            CreateMap<Patient, PatientWithoutReversoinDTO>();
            CreateMap<ReservationForAddDto, Patient>();
            #endregion

            #region Reservation
            CreateMap<ReservationForAddDto, Reservation>();
            #endregion

            #region Schedule
            CreateMap<ScheduleForAddDto, Schedule>();

            CreateMap<Schedule, ScheduleDto>()
             .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor.FullName))
             .ForMember(dest => dest.Clinic, opt => opt.MapFrom(src => src.Clinic.Name))
             .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.DayOfWeek.ToString()));

            #endregion

        }
    }
}
