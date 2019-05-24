using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GigHub.DTOs;
using GigHub.Models;

namespace GigHub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AutoMapper.Mapper.CreateMap<ApplicationUser, UserDto>();
            AutoMapper.Mapper.CreateMap<Gig, GigDto>();
            AutoMapper.Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}