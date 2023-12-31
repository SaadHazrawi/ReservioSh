using AutoMapper;
using Reservio.DTOS.Clinic;
using Reservio.DTOS.Doctor;
using Reservio.DTOS.Patient;
using Reservio.DTOS.Reservation;
using Reservio.Models;

namespace Reservio.Helpers
{
    public class Proflies:Profile
    {
        public Proflies()
        {
            #region Clinic
            CreateMap<Clinic,ClinicCreationDTO>();
            CreateMap<ClinicCreationDTO, Clinic>();
            CreateMap<Clinic,ClinicWithiutAnyThinkAsync>();
            CreateMap<Clinic,ClinicForUpdateDTO>().ReverseMap();
            #endregion

            #region Doctor
            CreateMap<DoctorCreataionDTO, Doctor>();
            CreateMap<Doctor, DoctorCreataionDTO>();
            CreateMap<Doctor, DoctorWithoutSubstitueDTO>();
            #endregion

            #region Patient
            CreateMap<PatientCreationDTO, Patient>();   
            CreateMap<Patient, PatientWithoutReversoinDTO>();
            #endregion

            #region Reservation
            CreateMap<Reservation, ReservationForAddDto>();
            #endregion

        }
    }
}
