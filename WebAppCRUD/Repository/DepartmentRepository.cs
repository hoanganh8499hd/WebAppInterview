using Microsoft.EntityFrameworkCore;
using WebAppCRUD.GenericRepository;
using WebAppCRUD.Models;

namespace WebAppCRUD.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        // Khởi tạo context để kết nối với cơ sở dữ liệu
        public DepartmentRepository(EFCoreDbContext context) : base(context) { }

        // Lấy thông tin bộ phận theo DepartmentID
        public async Task<Department?> GetDepartmentByIdAsync(int DepartmentID)
        {
            // Truy vấn cơ sở dữ liệu để tìm bộ phận theo ID
            return await _context.Departments
                                 .FirstOrDefaultAsync(d => d.DepartmentId == DepartmentID);
        }

        // Lấy các bộ phận theo tên bộ phận
        public async Task<IEnumerable<Department>> GetDepartmentByNameAsync(string DepartmentName)
        {
            // Truy vấn cơ sở dữ liệu để tìm các bộ phận có tên khớp với từ khóa
            return await _context.Departments
                                 .Where(d => d.Name.Contains(DepartmentName))
                                 .ToListAsync();
        }

        // Lấy tất cả các bộ phận
        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            // Truy vấn cơ sở dữ liệu để lấy tất cả các bộ phận
            return await _context.Departments.ToListAsync();
        }
    }

}
