using DotNetTask.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DotNetTask.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<ProgramData> ProgramDatas { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramData>(p =>
            {
                p.ToContainer("ProgramData");
                p.HasPartitionKey(x => x.ProgramId);
                p.OwnsOne(pi => pi.PersonalInformation);
                p.OwnsMany(q => q.QuestionData);

            });


            modelBuilder.Entity<Candidate>(c =>
            {
                c.ToContainer("Candidate");
                c.HasPartitionKey(x => x.ProgramId);
                c.OwnsMany(q => q.Answers);

            });
        }
    }
}
