using AbbyWeb.Data;
using AbbyWeb.Models;
using AbbyWeb.Services.Repository.IRepository;


namespace AbbyWeb.Services.Repository
{
    public class GenderRepository : TuseRepository<Gender>, IGenderRepository
    {
        private readonly ApplicationDbContext _context;
        public GenderRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public void Update(Gender genderToUpdate)
        {
            var findGender = _context.Attach(genderToUpdate);
            findGender.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
