using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eVisaWeb.Models
{
    public class UserManagementViewModels
    {
        public UserManagementViewModels()
        {
            UserViewModelsList = new List<UserViewModels>();
        }

        public IList<UserViewModels> UserViewModelsList { get; set; }

        public int Page { get; set; }

        public int TotalPages { get; set; }

        public int Total { get; set; }

        public int Start { get; set; }

        public int Limit { get; set; }

        public string Query { get; set; }

        public int DisplayFrom { get; set; }

        public int DisplayTo { get; set; }
    }
}