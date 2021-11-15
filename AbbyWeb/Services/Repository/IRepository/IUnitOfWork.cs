using System;

namespace AbbyWeb.Services.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveToDb();
        public IEmployeeRepository EmployeeRepository { get;}
        public IGenderRepository GenderRepository { get; }
        public IOccupationRepository OccupationRepository { get; }
    }
}
