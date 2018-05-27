using SFSAdacdemyAdminPortalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSAdacdemyAdminPortalService.DataAccess
{
    public interface IPortalRepository
    {
        List<Portal> GetPortalDetails(Portal portal);

        Portal GetPortalDetailByID(string environment, Int32 ID);
    }
}
