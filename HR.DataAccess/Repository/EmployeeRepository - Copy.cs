
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
    public class QualificationRepository : RepositoryAsync<Qualification>, IQualificationRepository
    {
        private readonly ArmyTechTaskEntities _db;
        public QualificationRepository(ArmyTechTaskEntities db) : base(db)
        {
            _db = db;
        }
        public void update(Qualification entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}
