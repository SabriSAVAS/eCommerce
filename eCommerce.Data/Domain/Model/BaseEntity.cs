using System.ComponentModel.DataAnnotations;

namespace eCommerce.Data.Domain.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
