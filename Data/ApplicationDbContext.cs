using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetDinos.Data;

namespace PetDinos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PetDinos.Data.PetStore> PetStore { get; set; }
        public DbSet<PetDinos.Data.Dinosaur> Dinosaur { get; set; }
    }
}
