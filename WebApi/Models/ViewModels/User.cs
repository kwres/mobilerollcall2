using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.ViewModels
{
    /// <summary>
    /// Viewmodel used for listing users over User class getList method
    /// </summary>
    public class UserGetList
    {
        public string Filter { get; set; }
        public int UserType { get; set; }
        public int State { get; set; }

    }
}