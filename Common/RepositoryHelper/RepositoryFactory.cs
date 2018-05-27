using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RepositoryHelper
{
    public class RepositoryFactory
    {
        List<RepositoryObject> _repositoryObjects = new List<RepositoryObject>();

        public T GetRepositoryObject<T>(string keyName)
        {
            Type blType = Type.GetType(GetDataRepositoryNameWithAssembly(keyName));
            return (T)Activator.CreateInstance(blType);
        }


        public T GetBusinessLayerRepository<T>(string keyName)
        {
            Type blType = Type.GetType(GetBusinessLayerRepositoryNameWithAssembly(keyName));
            return (T)Activator.CreateInstance(blType,keyName);
        }

        public RepositoryFactory()
        {
            _repositoryObjects.Add(new RepositoryObject()
            {
                KeyName = PortfolioModules.PORTAL,
                AssemblyName = "SFSAcademyAdminService",
                BusinessRepositoryName = "SFSAcademyAdminService.BusinessLogic.PortalBL",
                DataRepositoryName = "SFSAcademyAdminService.DataAccess.PortalRepository"
            });

            _repositoryObjects.Add(new RepositoryObject()
            {
                KeyName = PortfolioModules.USER,
                AssemblyName = "SFSAcademyAdminService",
                BusinessRepositoryName = "SFSAcademyAdminService.BusinessLogic.UserBL",
                DataRepositoryName = "SFSAcademyAdminService.DataAccess.UserRepository"
            });

            _repositoryObjects.Add(new RepositoryObject()
            {
                KeyName = PortfolioModules.USERACCESS,
                AssemblyName = "SFSAcademyAdminService",
                BusinessRepositoryName = "SFSAcademyAdminService.BusinessLogic.UserAccessBL",
                DataRepositoryName = "SFSAcademyAdminService.DataAccess.UserAccessRepository"
            });

            _repositoryObjects.Add(new RepositoryObject()
            {
                KeyName = PortfolioModules.ADMIN,
                AssemblyName = "SFSAcademyAdminService",
                BusinessRepositoryName= "SFSAcademyAdminService.BusinessLogic.AdminBL",
                DataRepositoryName = "SFSAcademyAdminService.DataAccess.AdminRepository"
            });
        }

        private string GetBusinessLayerRepositoryNameWithAssembly(string keyName)
        {
            var repositoryName = _repositoryObjects.Where(x => x.KeyName.ToString().Equals(keyName, StringComparison.CurrentCultureIgnoreCase)).Select(x => x.BusinessRepositoryName).FirstOrDefault();
            var assemblyName = _repositoryObjects.Where(x => x.KeyName.ToString().Equals(keyName, StringComparison.CurrentCultureIgnoreCase)).Select(x => x.AssemblyName).FirstOrDefault();
            return repositoryName + "," + assemblyName;
        }

        private string GetDataRepositoryNameWithAssembly(string keyName)
        {
            var repositoryName = _repositoryObjects.Where(x => x.KeyName.ToString().Equals(keyName, StringComparison.CurrentCultureIgnoreCase)).Select(x => x.DataRepositoryName).FirstOrDefault();
            var assemblyName = _repositoryObjects.Where(x => x.KeyName.ToString().Equals(keyName, StringComparison.CurrentCultureIgnoreCase)).Select(x => x.AssemblyName).FirstOrDefault();
            return repositoryName + "," + assemblyName;
        }
    }
}
