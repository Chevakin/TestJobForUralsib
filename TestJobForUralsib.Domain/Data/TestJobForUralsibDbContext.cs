using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJobForUralsib.Domain.Data
{
    public class TestJobForUralsibDbContext : DbContext
    {
        public TestJobForUralsibDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
