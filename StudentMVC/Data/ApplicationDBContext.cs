using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using StudentMVC.Models;

namespace StudentMVC.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<Student> Students { get; set; }

    public DbSet<Course> Courses { get; set; }

}
}
