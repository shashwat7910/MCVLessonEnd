using Microsoft.EntityFrameworkCore;
using Models;
using MVCLessonEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DataLayer
{
    public class AppContext :DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<SubjectModel> Subject { get; set; }
        public DbSet<ClassModel> Class { get; set; }
    }
}
