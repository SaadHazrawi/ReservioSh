using AutoMapper;
using Reservio.AppDataContext;
using Reservio.Services.ClinicRepo;
using Reservio.Services.DotorRepo;
using Reservio.Services.PatientRepo;
using Reservio.Services.ReservationRepo;
using Reservio.Services.ScheduleRepo;
using Reservio.Services.VacationRepo;

namespace Reservio.Services.BaseRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IReservationRepository Reservation { get; private set; }
        public IClinicRepository Clinics { get; private set; }
        public IDotorRepository Doctors { get; private set; }
        public IPatientRepository Patients { get; private set; }
        public ISchedulesRepository Schedules { get; private set; }

        public IVacationRepository Vacations { get; private set; }

        public UnitOfWork(DataContext context, IMapper mapper, ILogger<UnitOfWork> logger)
        {
            _context = context;
            Reservation = new ReservationRepository(context, mapper, logger);
            Clinics = new ClinicRepository(context, mapper, logger);
            Doctors = new DotorRepository(context, mapper, logger);
            Patients = new PatientRepository(context, mapper, logger);
            Schedules = new SchedulesRepository(context, mapper, logger);
            Vacations = new VacationRepository(context, mapper, logger);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
