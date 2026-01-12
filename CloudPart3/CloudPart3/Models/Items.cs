using System.ComponentModel.DataAnnotations;

namespace CloudPart3.Models
{
    public class Items
    {
        [Key]
        public int Item_Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
        public int? AvailableQuantity { get; set; }
    }
}
