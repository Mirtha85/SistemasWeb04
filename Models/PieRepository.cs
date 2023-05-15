using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace SistemasWeb01.Models
{
    public class PieRepository: IPieRepository
    {
        private readonly BethesdaPieShopDbContext _bethesdaPieShopDbContext;

        public PieRepository(BethesdaPieShopDbContext bethesdaPieShopDbContext)
        {
            _bethesdaPieShopDbContext = bethesdaPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies {

            get {
                return _bethesdaPieShopDbContext.Pies.Include(c => c.Category).ToList();
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek {
            get
            {
                return _bethesdaPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
                
            }

        }    

        public Pie? GetPieById(int pieId)
        {
            return _bethesdaPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
