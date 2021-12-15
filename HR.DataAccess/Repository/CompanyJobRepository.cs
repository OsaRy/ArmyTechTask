
using HR.DataAccess.IRepository;
using HR.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Repository
{
    public class CompanyJobRepository : RepositoryAsync<CompanyJob>, ICompanyJobRepository
    {
        private readonly ArmyTechTaskEntities _db;
        public CompanyJobRepository(ArmyTechTaskEntities db) : base(db)
        {
            _db = db;
        }
        public void update(CompanyJob entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}
