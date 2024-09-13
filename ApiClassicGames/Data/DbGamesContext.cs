using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiClassicGames.Models;

namespace ApiClassicGames.Data
{
    public class DbGamesContext : DbContext
    {
        public DbGamesContext (DbContextOptions<DbGamesContext> options)
            : base(options)
        {
        }

        public DbSet<ApiClassicGames.Models.ClassicGame> ClassicGame { get; set; } = default!;
    }
}
