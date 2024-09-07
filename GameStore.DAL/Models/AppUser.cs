using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(256)]
        public string LastLoginIpAdr { get; set; }
    }
}
