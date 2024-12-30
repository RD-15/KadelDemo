using Microsoft.AspNetCore.Mvc.Formatters;

namespace KadelDemo.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public string? PropertyImage { get; set; }
        
    }
}
