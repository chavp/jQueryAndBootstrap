using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eVisaWeb.Models
{
    public class UserViewModels
    {
        public int ID { get; set; }
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string JoinedDate { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}