using Common.RepositoryHelper;
using SFSAdacdemyAdminPortalService.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.RepositoryHelper;
using SFSAdacdemyAdminPortalService.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace SFSAdacdemyAdminPortalService.Controllers
{
    public class BaseController<T> : ApiController
    {
        public T iRepository;
        public BaseController(string repositoryName)
        {
            iRepository = new RepositoryFactory().GetBusinessLayerRepository<T>(repositoryName);
        }

        public HttpResponseMessage GetResponse(string content)
        {
            var resp = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(content,System.Text.Encoding.UTF8, "application/json")
            };

            return resp;
        }
    }
}
