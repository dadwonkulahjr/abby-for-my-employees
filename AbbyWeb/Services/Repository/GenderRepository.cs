using AbbyWeb.Data;
using AbbyWeb.Models;
using AbbyWeb.Services.Repository.IRepository;

namespace AbbyWeb.Services.Repository
{
    public class OccuupationRepository : TuseRepository<Occupation>, IOccupationRepository
    {
        private readonly ApplicationDbContext _context;
        public OccuupationRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public void Update(Occupation occupationToUpdate)
        {
            var findOccupation = _context.Attach(occupationToUpdate);
            findOccupation.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
