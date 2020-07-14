using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Project1.Data.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Project1.Data
{
    public class Project01ContextFactory : IDesignTimeDbContextFactory<Project01Context>
    {
        public IConfiguration Configuration { get; }

        //public static readonly string connectionString = System.IO.File.ReadAllText("C:/Users/james/Desktop/Revature/Project0Connect.txt");
        public Project01Context CreateDbContext(string[] args = default)
        {
            var options = new DbContextOptionsBuilder<Project01Context>()
                //.UseSqlServer(connectionString)
                .UseSqlServer(Configuration.GetConnectionString("SqlServer"))
                .Options;


            return new Project01Context(options);


        }
    }
}
