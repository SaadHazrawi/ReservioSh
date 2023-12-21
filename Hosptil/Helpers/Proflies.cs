using AutoMapper;
using Hosptil.DTOS.Clinic;
using Hosptil.DTOS.Doctor;
using Hosptil.DTOS.Patient;
using Hosptil.Models;

namespace Hosptil.Helpers
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
        }
    }
}
