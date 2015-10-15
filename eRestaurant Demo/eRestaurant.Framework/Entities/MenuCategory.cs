using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class MenuCategory
    {
        [Key] //This attribute identifies the MenuCategoryId property as mapping to a PK
        public int MenuCategoryID {get; set;}

        [Required(ErrorMessage = "A Description is required (5-15 characters")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Descriptions must be from 5 to 15 characters in length")]
        public string Description { get; set; }   
        

        //Navigation Properties
        public virtual ICollection<Item> Items { get; set; }
    }
}
