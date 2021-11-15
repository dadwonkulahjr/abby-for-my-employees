using AbbyWeb.Data;
using AbbyWeb.Services.Repository.IRepository;
using System;

namespace AbbyWeb.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            EmployeeRepository = new EmployeeRepository(applicationDbContext);
            GenderRepository = new GenderRepository(applicationDbContext);
            OccupationRepository = new OccuupationRepository(applicationDbContext);
        }

        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IGenderRepository GenderRepository { get; private set; }

        public IOccupationRepository OccupationRepository { get; private set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void SaveToDb()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
