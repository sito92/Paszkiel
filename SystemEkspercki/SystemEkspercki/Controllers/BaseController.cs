using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemEkspercki.Models;

namespace SystemEkspercki.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/ 
        protected SystemContext context;
        public BaseController()
        {
            context= new SystemContext();
        }

    }
}
