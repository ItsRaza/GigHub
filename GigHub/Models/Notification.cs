using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }

        protected Notification()
        {
        }
        private Notification(Gig gig, NotificationType type)
        {
            if(gig==null)
            {
                throw new ArgumentNullException("gig");
            }
            Gig = gig;
            Type = type;
            DateTime = DateTime.Now;
        }
        public static Notification GigCreated(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCreated);
        }
        public static Notification GigUpdated(Gig Newgig,DateTime Odatetime, string Ovenue)
        {
            var notification=new Notification(Newgig, NotificationType.GigUpdated);
            notification.OriginalDateTime = Odatetime;
            notification.OriginalVenue = Ovenue;
            return notification;
        }
        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCancelled);
        }
    }
}