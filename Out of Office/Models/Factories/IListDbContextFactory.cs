using OutOfOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models.Factories
{
    public interface IListDbContextFactory
    {
        ListsDbContext Create();
    }
}
