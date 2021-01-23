using Microsoft.EntityFrameworkCore;
using System;

namespace EF_Activity001
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):
            base(options)
        {

        }
    }
}
