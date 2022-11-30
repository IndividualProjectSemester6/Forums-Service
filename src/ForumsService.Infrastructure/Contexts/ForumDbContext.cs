﻿using ForumsService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumsService.Infrastructure.Contexts
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : 
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ForumDto>().ToTable("Forums");
            modelBuilder.Entity<ForumDto>().HasData(
                new ForumDto(Guid.NewGuid(), "dune_forum", "A Forum for the Dune movie."),
                new ForumDto(Guid.NewGuid(), "sw_forum", "A Forum for the Star Wars movies."),
                new ForumDto(Guid.NewGuid(), "hp_forum", "A Forum for the Harry Potter movies."));
        }


        public DbSet<ForumDto> Forums { get; set; }
    }
}