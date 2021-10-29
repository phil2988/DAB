using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment_2.Tables;

namespace Assignment_2
{
    class DbHandler<T> where T : class
    {
        DbContext context;
       
        public DbHandler(DbContext context)
        {
            this.context = context;
            
        }

        public List<T> GetTable() {
            var dbSet = context.Set<T>();

            return dbSet.ToList();
        }
    }
}
