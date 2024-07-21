using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace TeamForge.Model
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Role { get; set; } // Add other properties if needed
    }

}
