using AutoMapper;
using Reservio.AppDataContext;
using Reservio.Services.ClinicRepo;
using Reservio.Services.DotorRepo;
using Reservio.Services.PatientRepo;
using Reservio.Services.ReservationRepo;

namespace Reservio.Services.BaseRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IReservationRepository Reservation { get; private set; }
        public IClinicRepository Clinics { get; private set; }

        public IDotorRepository Doctors { get; private set; }

        public IPatientRepository Patients { get; private set; }
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            Reservation = new ReservationRepository(context , mapper); 
            Clinics = new ClinicRepository(context);
            Doctors = new DotorRepository(context); 
            Patients = new PatientRepository(context, mapper); 
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
