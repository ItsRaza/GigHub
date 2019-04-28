using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class FollowingsViewModel
    {
        public List <ApplicationUser> users { get; set; }
        public bool ShowActions { get; set; }
    }
}