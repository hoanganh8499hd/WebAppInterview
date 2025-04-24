namespace WebAppViews.Models
{
    public class Product
    {
        public int ProductID { get; set; }   // Mã sản phẩm
        public string Name { get; set; }      // Tên sản phẩm
        public string Category { get; set; }  // Danh mục sản phẩm
        public string Description { get; set; } // Mô tả sản phẩm
        public decimal Price { get; set; }    // Giá sản phẩm
    }
}
