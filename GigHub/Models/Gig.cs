using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }
        public ApplicationUser Artist { get; set; }

        public bool IsCancelled { get; private set; }

        [Required]
        public string  ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
        public ICollection<Attendence> Attendences { get; private set; }

        public Gig()
        {
            Attendences = new Collection<Attendence>();
        }

        internal void Cancel()
        {
            IsCancelled = true;

            var notification = Notification.GigCanceled(this);

            foreach (var attendee in Attendences.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
        internal void Modify(DateTime dateTime, string venue, byte genere)
        {
            var notification = Notification.GigUpdated(this, DateTime, Venue);

            Venue = venue;
            DateTime = dateTime;
            GenreId = genere;
            foreach (var attendee in Attendences.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}