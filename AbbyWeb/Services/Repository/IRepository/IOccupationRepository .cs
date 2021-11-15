using AbbyWeb.Models;


namespace AbbyWeb.Services.Repository.IRepository
{
    public interface IOccupationRepository : IAmtuseRepository<Occupation>
    {
        void Update(Occupation occupationToUpdate);
    }
}
