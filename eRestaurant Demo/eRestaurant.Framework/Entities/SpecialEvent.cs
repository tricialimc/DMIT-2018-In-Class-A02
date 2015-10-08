using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class SpecialEvent
    {
        [Key]
        [Required(ErrorMessage = "An Event is required (one character only")]
        [StringLength(1, ErrorMessage= "Event Codes can only use a single-character code")]
        public string EventCode { get; set; }

        [Required()] //Can put required without a required message
        [StringLength(30, MinimumLength = 5, ErrorMessage="Description has to be 5 to 30 characters")] //Can put only the maximum length and min length
        public string Description { get; set; }

        public bool Active { get; set; }

        //Navigation Properties
        public virtual ICollection<Reservations> Reservations { get; set; } //one to many relationship

        public SpecialEvent()
        {
            //For all new SpecialEvents, there is a busines rule stating they should automatically be set to active.
            //(Similar to having a Default constraint in a database)
            Active = true;
            //To avoid null reference errors for our navigation property
            Reservations = new HashSet<Reservations>();
        }
    }
}
