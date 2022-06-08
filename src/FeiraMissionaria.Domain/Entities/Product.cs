using FeiraMissionaria.Domain.Entities.Base;

namespace FeiraMissionaria.Domain.Entities;
public class Product : EntityBase
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }        
    public bool Available { get; set; }
    public string Description { get; set; }
}
