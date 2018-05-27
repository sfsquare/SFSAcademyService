using SFSAdacdemyAdminPortalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFSAdacdemyAdminPortalService.BusinessLogic
{
    public interface IPortalBL
    {
        List<Portal> GetPortalDetails(Portal portal);

        Portal GetPortalDetailByID(string environment, Int32 ID);

        Portal GetPortalDetailByIDTest(Int32 ID);
    }
}
