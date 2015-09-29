using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class Reservations
    {
        #region Constants (for BLL validation)
        //constants for vaild reservation status values
        //A = Arrived, B = Booked; C = Complete; N = No show; X = Cancelled
        public const string Arrived = "A";
        public const string Booked = "B";
        public const string Complete = "C";
        public const string NoShow = "N";
        public const string Cancelled = "X";
        #endregion 

        [Key]
        public int ReservationID { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }

        [Range(1,16)]
        public int NumberInParty { get; set; }
        [StringLength(15)]
        public string ContactPhone { get; set; }
        [Required, StringLength(1)]
        public string ReservationStatus { get; set; }
        [StringLength(1)]
        public string EventCode { get; set; }

        //Navigation Properties
        public virtual ICollection<Tables> Tables { get; set; } //one resevation to many tables relationship
        public virtual SpecialEvent SpecialEvent { get; set; } //one reservation to one special event relationship
    }
}
