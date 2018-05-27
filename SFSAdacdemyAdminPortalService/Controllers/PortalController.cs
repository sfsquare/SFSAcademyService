using Common.RepositoryHelper;
using SFSAdacdemyAdminPortalService.BusinessLogic;
using SFSAdacdemyAdminPortalService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace SFSAdacdemyAdminPortalService.Controllers
{
    public class PortalController : ApiController //BaseController<IPortalBL>
    {
        //public PortalController() : base(PortfolioModules.PORTAL) { }

        PortalBL _portalBL;

        public PortalController(PortalBL portalBL)
        {
            _portalBL = portalBL;
        }

        [HttpPost]
        public IEnumerable<Portal> GetPortalDetails(Portal input)
        {
            //return iRepository.GetPortalDetails(input);
            return _portalBL.GetPortalDetails(input);
        }

        public Portal GetPortalDetailByID(string environment, Int32 ID)
        {
            //Portal portal = new Portal();
            //portal.Environment = "Dev";
            //portal.ID = 1;
            //return iRepository.GetPortalDetailByID(environment, ID);

            return _portalBL.GetPortalDetailByID(environment, ID);
        }

        [HttpGet]
        public Portal GetPortalDetailByIDTest(Int32 ID)
        {
            return _portalBL.GetPortalDetailByID("Dev", ID);
        }
    }
}
