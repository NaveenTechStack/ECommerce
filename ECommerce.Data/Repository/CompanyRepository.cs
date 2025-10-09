using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company> , ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            _db = _dbContext;
        }       
        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
