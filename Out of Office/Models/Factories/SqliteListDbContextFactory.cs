using OutOfOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Factories
{
    public class SQLiteListDbContextFactory : IListDbContextFactory
    {
        string? ConnectionStr { get; set; } = null;

        public SQLiteListDbContextFactory()
        {
        }

        public SQLiteListDbContextFactory(string connectionStr)
        {
            ConnectionStr = connectionStr;
        }

        public ListsDbContext Create()
        {
            return ConnectionStr is null
                ? new ListsDbContext()
                : new ListsDbContext(ConnectionStr);
        }
    }
}
