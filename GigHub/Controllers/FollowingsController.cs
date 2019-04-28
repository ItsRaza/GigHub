using GigHub.DTOs;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;
        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if(_context.Followings.Any(f=>f.FolloweeId==userId && f.FolloweeId==dto.FolloweeId))
            {
                return BadRequest("Already following!");
            }
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();
            return Ok();
        }
        /*[Authorize]
        public IHttpActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
            var viewModel = new FollowingsViewModel()
            {
                users = user,
                ShowActions = User.Identity.IsAuthenticated
            };
            return View("Following",viewModel);
        }*/
    }
}
