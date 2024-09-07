using GameStore.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Data
{
    public class GameDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public GameDbContext(DbContextOptions<GameDbContext> options)
           : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}
