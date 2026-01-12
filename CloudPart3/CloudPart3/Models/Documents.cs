using System.ComponentModel.DataAnnotations;

namespace CloudPart3.Models
{
    public class Documents
    {
        [Key]
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; } 
        public byte[]? FileContent { get; set; }
    }
}
