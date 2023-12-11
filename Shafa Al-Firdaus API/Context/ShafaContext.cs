using Shafa_Al_Firdaus_API.Models;
using Microsoft.EntityFrameworkCore;
using Shafa_Al_Firdaus_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shafa_Al_Firdaus_API.Context
{
    public class ShafaContext : DbContext
    {
        public ShafaContext()
        {

        }
        public ShafaContext(DbContextOptions<ShafaContext> options) : base(options)
        {

        }

        public virtual DbSet<DkmModel> DkmModels { get; set; }




    }
}