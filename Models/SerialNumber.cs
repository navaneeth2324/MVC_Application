using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Application.Models
{
    public class SerialNumber
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public int? ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item? Item { get; set; } 
    }
}
