using HR.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.IRepository
{
    public interface IQualificationRepository : IRepositoryAsync<Qualification>
    {
        void update(Qualification entity);
    }
}
