using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    public class ApplicationUser : IdentityUser
    {
        public List<Comment> Comments { get; set; }
    }
}
