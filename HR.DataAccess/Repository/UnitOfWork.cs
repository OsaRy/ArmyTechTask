using HR.DataAccess.IRepository;
using HR.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private  ArmyTechTaskEntities _db;

        public UnitOfWork(ArmyTechTaskEntities db)
        {
            _db = db;

            Employee = new EmployeeRepository(_db);
            CareerField = new CareerFieldRepository(_db);
            Governorate = new GovernorateRepository(_db);
            CompanyJob = new CompanyJobRepository(_db);
            EmployeeQualification = new EmployeeQualificationRepository(_db);
            Neighborhood = new NeighborhoodRepository(_db);
            Qualification = new QualificationRepository(_db);

        }
        public void ProxyCreationEnabled()
        {
            _db.Configuration.ProxyCreationEnabled = false;
        }

        public IEmployeeRepository Employee { get; private set; }

        public IGovernorateRepository Governorate { get; private set; }
        public ICareerFieldRepository CareerField { get; private set; }
        public ICompanyJobRepository CompanyJob { get; private set; }
        public IEmployeeQualificationRepository EmployeeQualification { get; private set; }
        public INeighborhoodRepository Neighborhood { get; private set; }
        public IQualificationRepository Qualification { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
