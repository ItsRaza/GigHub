﻿using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs
                .Include(g=>g.Attendences.Select(a=>a.Attendee))
                .Single(g => g.Id == id && g.ArtistId == userId);
            if(gig.IsCancelled)
            {
                return NotFound();
            }
            gig.Cancel();
            
            _context.SaveChanges();
            return Ok();

        }
    }
}
