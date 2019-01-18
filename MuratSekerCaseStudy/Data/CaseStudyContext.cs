using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MuratSekerCaseStudy.Data
{
    public class CaseStudyContext:DbContext
    {
        public CaseStudyContext(DbContextOptions<CaseStudyContext> options) : base(options) { }
            
        //public DbSet<Entity> Entities { get; set; }
    }
}
