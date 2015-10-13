using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities.DTOs
{
    public class CategoryDTO //Data transfer Object
    {
	public string Description {get; set;}
	public IEnumerable<MenuItemDTO> MenuItems {get; set;}
    }
}
