using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Entity;

namespace GameOverGames.Controllers
{
    public class TheDbContext : DbContext
    {
       public DbSet<UserVM> userVM { get; set; }
    }
}