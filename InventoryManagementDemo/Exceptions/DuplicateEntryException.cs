using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDemo.Exceptions
{
    public class DuplicateEntryException:Exception
    {
        public DuplicateEntryException(string message) : base(message) { }
    }
}
