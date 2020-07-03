using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Project1.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Data
{
    class Project01ContextFactory : IDesignTimeDbContextFactory<Project01Context>
    {

        public static readonly String connectionString = System.IO.File.ReadAllText("C:/Users/james/Desktop/Revature/Project0Connect.txt");
        public Project01Context CreateDbContext(string[] args = default)
        {
            var options = new DbContextOptionsBuilder<Project01Context>()
                .UseSqlServer(connectionString)
                .Options;

            return new Project01Context(options);
        }
    }
}
