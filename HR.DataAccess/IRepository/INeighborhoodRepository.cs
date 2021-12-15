using HR.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.IRepository
{
    public interface INeighborhoodRepository : IRepositoryAsync<Neighborhood>
    {
        void update(Neighborhood entity);
    }
}
