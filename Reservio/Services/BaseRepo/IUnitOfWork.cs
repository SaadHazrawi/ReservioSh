using Reservio.Services.ClinicRepo;
using Reservio.Services.DotorRepo;
using Reservio.Services.PatientRepo;
using Reservio.Services.ReservationRepo;

namespace Reservio.Services.BaseRepo
{
    public interface IUnitOfWork : IDisposable
    {
        IReservationRepository Reservation { get; }
        IClinicRepository Clinics { get; }

        IDotorRepository Doctors { get; }

        IPatientRepository Patients { get; }

    }
}
