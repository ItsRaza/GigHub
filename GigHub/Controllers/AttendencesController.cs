﻿using GigHub.DTOs;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendencesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendencesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendenceDTO dto)
        {
            var userId = User.Identity.GetUserId();
            var exist = _context.Attendences.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);
            if(exist)
            {
                return BadRequest("The Attendence already exist");
            }
            var attendence = new Attendence
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendences.Add(attendence);
            _context.SaveChanges();
            return Ok();
        }
    }
}
