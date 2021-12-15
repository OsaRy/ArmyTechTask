using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.IRepository
{
    public interface IUnitOfWork : IDisposable
    {

        IEmployeeRepository Employee { get; }
        IGovernorateRepository Governorate { get; }
        ICareerFieldRepository CareerField { get; }
        ICompanyJobRepository CompanyJob { get; }
        IEmployeeQualificationRepository EmployeeQualification { get; }
        INeighborhoodRepository Neighborhood { get; }
        IQualificationRepository Qualification { get; }

        void Save();
        void ProxyCreationEnabled();
      

    }
}
