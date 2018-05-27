using Common.RepositoryHelper;
using SFSAdacdemyAdminPortalService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFSAdacdemyAdminPortalService.BusinessLogic.TestRepository
{
    public class PortalBLTest : BaseRepository<IPortalRepository>
    {
        public PortalBLTest(string keyName)
            : base(keyName) { }

        public List<Models.Portal> GetPortalDetails(Models.Portal portal)
        {
            return iRepository.GetPortalDetails(portal);
        }
    }
}