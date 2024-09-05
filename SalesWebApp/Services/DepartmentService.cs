using SalesWebApp.Data;
using SalesWebApp.Models;

namespace SalesWebApp.Services
{
    public class DepartmentService
    {
        private readonly SalesWebAppContext _context;

        public DepartmentService(SalesWebAppContext context)
        {
            _context = context;
        }

        public List<Department> FindALl()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
