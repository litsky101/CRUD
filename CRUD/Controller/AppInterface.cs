using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Controller
{
    public interface AppInterface
    {
        void SetController(EmployeeController _controller);

        string EmployeeId { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
    }
}
