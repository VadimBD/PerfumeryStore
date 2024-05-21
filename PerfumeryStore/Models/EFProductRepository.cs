using Microsoft.EntityFrameworkCore;
using PerfumeryStore.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PerfumeryStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private AppDBContext _DBContext;
        public EFProductRepository(AppDBContext dBContext) 
        {
            _DBContext = dBContext;
        }
        public IEnumerable<Product> Products => _DBContext.Products.Include(p=>p.Brand)
            .Include(p=>p.Container).Include(p=>p.Reviews);

        public IEnumerable<Brand> Brands => _DBContext.Brands;

        public void SaveReview(Review review, int productId)
        {
            var dbEntry = Products.First(p => p.Id == productId);
            dbEntry.Reviews.Add(review);
            _DBContext.SaveChanges();
        }
    }
}
