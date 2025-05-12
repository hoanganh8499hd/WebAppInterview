using ConsoleAppEFCore.OperationLoadRelatedEntities;

namespace ConsoleAppEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading Data");

            //EagerLoading.EagerLoadingSingleAction();

            //EagerLoading.EagerLoadingMultipleLevelsAction();

            //LazyLoading.LazyLoadingSingleLevelAction();

            //LazyLoading.EagerLoadingBranchAndLazyLoadingAddressAction();

            //ExplicitLoading.ExplicitLoadingAction();    


            //Note

            // **Eager Loading**:
            //.Include() và .ThenInclude()
            // Định nghĩa: Trong Eager Loading, các thực thể liên quan được truy vấn cùng với thực thể chính trong một truy vấn duy nhất.
            // Cách thức hoạt động: Dữ liệu liên quan được tải khi thực thể chính được tải ban đầu, thường sử dụng phương thức Include() trong truy vấn.

            // Ví dụ: Nếu bạn tải một học sinh và muốn tải nhánh (Branch) liên quan, bạn sử dụng .Include(s => s.Branch) để tải cả Học sinh và Nhánh cùng một lúc.

            // Ưu điểm: Hiệu quả nếu bạn cần dữ liệu liên quan ngay lập tức, tránh việc gửi nhiều truy vấn.
            // Nhược điểm: Có thể dẫn đến việc tải dữ liệu không cần thiết nếu các thực thể liên quan không cần thiết.

            //var student = context.Students.Include(s => s.Branch).FirstOrDefault(s => s.StudentId == 1);

            // **Lazy Loading**:
            // Định nghĩa: Trong Lazy Loading, các thực thể liên quan được tải tự động khi thuộc tính điều hướng (navigation property) được truy cập lần đầu mà không cần mã lệnh rõ ràng.
            // Cách thức hoạt động: Dữ liệu liên quan chỉ được tải khi bạn truy cập vào thuộc tính điều hướng (ví dụ: student.Branch). Điều này được thực hiện tự động, thường là trong nền.

            // Ví dụ: Khi bạn truy cập student.Branch lần đầu, EF Core tự động gửi truy vấn để tải thực thể Branch.
            // Ưu điểm: Đơn giản để triển khai, chỉ tải dữ liệu khi thực sự cần thiết.
            // Nhược điểm: Có thể gây ra vấn đề N+1 (nhiều truy vấn được gửi đi, mỗi truy vấn cho một thực thể liên quan), điều này có thể không hiệu quả.

            // **Lưu ý**: Để kích hoạt Lazy Loading trong EF Core, các thuộc tính điều hướng phải là virtual, và bạn cần cấu hình nó trong DbContext.

            //var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
            // Branch sẽ được tải lazily khi được truy cập
            //var branchLocation = student.Branch.BranchLocation;

            // **Explicit Loading**:
            //Entry().Reference().Load() hoặc Entry().Collection().Load()
            // Định nghĩa: Trong Explicit Loading, các thực thể liên quan được tải rõ ràng sau khi thực thể chính đã được tải. Bạn chỉ định chính xác khi nào và dữ liệu nào cần được tải.
            // Cách thức hoạt động: Không giống Lazy Loading, bạn tải dữ liệu liên quan một cách thủ công bằng cách sử dụng các phương thức như Entry().Reference().Load() hoặc Entry().Collection().Load().

            // Ví dụ: Sau khi tải một học sinh, bạn tải thực thể nhánh liên quan một cách rõ ràng bằng cách gọi context.Entry(student).Reference(s => s.Branch).Load().
            // Ưu điểm: Cung cấp cho bạn nhiều quyền kiểm soát hơn về thời gian và cách thức dữ liệu liên quan được tải, tránh các truy vấn không cần thiết.
            // Nhược điểm: Cần nhiều mã lệnh hơn và yêu cầu chỉ dẫn rõ ràng từ nhà phát triển.

            //var student = context.Students.FirstOrDefault(s => s.StudentId == 1);
            //context.Entry(student).Reference(s => s.Branch).Load(); // Tải nhánh rõ ràng


        }
    }
}
