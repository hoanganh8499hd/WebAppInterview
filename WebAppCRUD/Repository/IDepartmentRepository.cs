using WebAppCRUD.GenericRepository;
using WebAppCRUD.Models;

namespace WebAppCRUD.Repository
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        //Here, you need to define the operations which are specific to Department Entity
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int DepartmentID);
        Task<IEnumerable<Department>> GetDepartmentByNameAsync(string DepartmentName);
    }
}
