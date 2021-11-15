using AbbyWeb.Models;


namespace AbbyWeb.Services.Repository.IRepository
{
    public interface IGenderRepository : IAmtuseRepository<Gender>
    {
        void Update(Gender genderToUpdate);
    }
}
