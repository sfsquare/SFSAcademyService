using Common.RepositoryHelper;
using SFSAdacdemyAdminPortalService.DataAccess;
using SFSAdacdemyAdminPortalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SFSAdacdemyAdminPortalService.BusinessLogic
{
    public class PortalBL//: BaseRepository<IPortalRepository>, IPortalBL
    {
        //public PortalBL(string keyName)
        //    : base(keyName) { }

        //public List<Portal> GetPortalDetails(Portal input)
        //{
        //    return iRepository.GetPortalDetails(input);
        //}

        //public Portal GetPortalDetailByID(string environment, Int32 ID)
        //{
        //    return iRepository.GetPortalDetailByID(environment, ID);
        //}

        IPortalRepository _portalRepository;
        //CodeHandler codehandler = new CodeHandler();

        public PortalBL(IPortalRepository portalRepository)
        {
            _portalRepository = portalRepository;
        }

        public List<Portal> GetPortalDetails(Portal input)
        {
            return _portalRepository.GetPortalDetails(input);
        }

        public Portal GetPortalDetailByID(string environment, Int32 ID)
        {
            return _portalRepository.GetPortalDetailByID(environment, ID);
        }

        public Portal GetPortalDetailByIDTest(Int32 ID)
        {
            return _portalRepository.GetPortalDetailByID("Dev", ID);
        }

    }
}