namespace SistemasWeb01.Models
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly BethesdaPieShopDbContext _bethesdaPieShopDbContext;

        public CategoryRepository(BethesdaPieShopDbContext bethesdaPieShopDbContext)
        {
            _bethesdaPieShopDbContext = bethesdaPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _bethesdaPieShopDbContext.Categories.OrderBy(p => p.CategoryName);

        //public void CreateCategory(Category category)
        //{
        //    category.Pies = new List<Pie>();
        //    _bethesdaPieShopDbContext.Categories.Add(category);
        //    _bethesdaPieShopDbContext.SaveChanges();    

        //}
        //public void UpdateCategory(Category category) {
            
        //    _bethesdaPieShopDbContext.Categories.Update(category);
        //    _bethesdaPieShopDbContext.SaveChanges();

        //}
    }
}
