using CLB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi1.Models.ViewModels;

namespace WebApi1.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "return smth";
        }

        [HttpPost]
        public Boolean register(User control)
        {
            return control.register();
        }


        [HttpPost]
        public Boolean login(User control)
        {
            return control.login();
        }


        [HttpPost]
        public List<User> getList(UserGetList formData)
        {
            return new User().getList(formData.Filter, formData.UserType, formData.State);
        }



    }
}
