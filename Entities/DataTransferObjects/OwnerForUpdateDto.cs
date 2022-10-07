using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entities.DataTransferObjects
{
    public class OwnerForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be loner then 100 characters")]
        public string Address { get; set; }
        
        //One more thing, if you want to remove the code duplication from the OwnerForCreationDto and OwnerForUpdateDto,
        //you can create an additional abstract class,
        //extract properties to it and then just force these classes to inherit from the abstract class.
        //Due to the sake of simplicity, we won’t do that now.
    }
}
