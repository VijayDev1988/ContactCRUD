using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ContactViewModel
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
