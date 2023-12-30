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
            CreateMap<Clinic,ClinicCreationDTO>();
            CreateMap<ClinicCreationDTO, Clinic>();
            CreateMap<Clinic,ClinicWithiutAnyThinkAsync>();
            CreateMap<Clinic,ClinicForUpdateDTO>().ReverseMap();
            CreateMap<DoctorCreataionDTO, Doctor>();
            CreateMap<Doctor, DoctorCreataionDTO>();
            CreateMap<Doctor, DoctorWithoutSubstitueDTO>();
            CreateMap<PatientCreationDTO, Patient>();   
            CreateMap<Patient, PatientWithoutReversoinDTO>();
            /////-----Reservation
            CreateMap<Reservation, ReservationForCreateDTO>();

        }
    }
}
