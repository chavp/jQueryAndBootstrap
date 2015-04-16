using eVisaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace eVisaWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IList<UserViewModels> UserViewModelsList = null;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            UserViewModelsList = CreateUserViewModels();
        }

        public IList<UserViewModels> CreateUserViewModels()
        {
            return new List<UserViewModels>
            {
                new UserViewModels
                {
                    ID = 1,
                    ImgUrl = "../../Content/UserImages/img1.jpg",
                    Name = "Sed nec elit arcu",
                    Address = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed id commodo lacus. Fusce non malesuada ante. Donec vel arcu.",
                    JoinedDate = "February 28, 2014",
                    Status = "Success",
                    Email = "info@example.com",
                    Website = "http://www.htmlstream.com",
                },

                new UserViewModels
                {
                    ID = 2,
                    ImgUrl = "../../Content/UserImages/img2.jpg",
                    Name = "Donec at aliquam est, a mattis mauris",
                    Address = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed id commodo lacus. Fusce non malesuada ante. Donec vel arcu.",
                    JoinedDate = "February 28, 2014",
                    Status = "Pending",
                    Email = "info@example.com",
                    Website = "http://www.htmlstream.com",
                },

                new UserViewModels
                {
                    ID = 3,
                    ImgUrl = "../../Content/UserImages/img3.jpg",
                    Name = "Pellentesque semper tempus vehicula",
                    Address = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed id commodo lacus. Fusce non malesuada ante. Donec vel arcu.",
                    JoinedDate = "February 28, 2014",
                    Status = "Expiring",
                    Email = "info@example.com",
                    Website = "http://www.htmlstream.com",
                },

                new UserViewModels
                {
                    ID = 4,
                    ImgUrl = "../../Content/UserImages/img4.jpg",
                    Name = "Alesuada fames ac turpis egestas",
                    Address = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed id commodo lacus. Fusce non malesuada ante. Donec vel arcu.",
                    JoinedDate = "February 28, 2014",
                    Status = "Error",
                    Email = "info@example.com",
                    Website = "http://www.htmlstream.com",
                },

                new UserViewModels
                {
                    ID = 5,
                    ImgUrl = "../../Content/UserImages/img5.jpg",
                    Name = "Etiam bibendum orci ut ante sagittis, sit amet imperdiet augue vulputate",
                    Address = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed id commodo lacus. Fusce non malesuada ante. Donec vel arcu.",
                    JoinedDate = "February 28, 2014",
                    Status = "Success",
                    Email = "info@example.com",
                    Website = "http://www.htmlstream.com",
                }
            };
        }
    }
}
