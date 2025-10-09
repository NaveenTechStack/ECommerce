using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            _db = _dbContext;
        }
        
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
