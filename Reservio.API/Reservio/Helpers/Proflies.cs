using AutoMapper;
using Reservio.DTOS.Clinic;
using Reservio.DTOS.Doctor;
using Reservio.DTOS.Patient;
using Reservio.DTOS.Reservation;
using Reservio.DTOS.Schedule;
using Reservio.DTOS.Vacation;
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
            CreateMap<Clinic, ClinicForUpdateDTO>().ReverseMap();
            CreateMap<Clinic, ClinicDto>().ReverseMap();

            CreateMap<Clinic, ClinicStatisticDto>()
                .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ReservationCount,
                        opt => opt.MapFrom(src => src.Reservations.Count()))
                .ReverseMap();
            #endregion

            #region Doctor
            CreateMap<DoctorForAddDto, Doctor>();
            CreateMap<Doctor, DoctorForAddDto>();
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorForUpdateDto, Doctor>().ReverseMap();
            #endregion

            #region Patient
            CreateMap<PatientCreationDTO, Patient>();
            CreateMap<Patient, PatientWithoutReversoinDTO>();
            CreateMap<ReservationForAddDto, Patient>();
            #endregion

            #region Reservation
            CreateMap<ReservationForAddDto, Reservation>();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Reservation, ReservationUpdateDTO>();
            CreateMap<Reservation, ReservationGenderStatisticDto>();
            
            #endregion

            #region Schedule
            CreateMap<ScheduleForAddDto, Schedule>();

            CreateMap<Schedule, ScheduleDto>()
             .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor.FullName))
             .ForMember(dest => dest.Clinic, opt => opt.MapFrom(src => src.Clinic.Name))
             .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Day.ToString()));


            CreateMap<Doctor, DoctorForShcudleDto>()
                  .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.DoctorId))
                  .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.FullName))
                  .ReverseMap();

            CreateMap<Clinic, ClinicForShcudleDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.ClinicId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();


            CreateMap<ScheduleForUpdateDto, Schedule>().ReverseMap();
            #endregion

            #region Vacation
            CreateMap<Vacation, VacationAddDTO>();
            #endregion
        }
    }
}
