using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOOKSTORE.Entities;

[Table("UserSubscriptions", Schema = "billing")]
public class Subscription
{
    [Key]
    public int SubId { get; set; }

    [Required] [MaxLength(50)] 
    public string PlanName { get; set; } = null!;
    
    [Required] 
    [Column("MonthlyRate")]
    public decimal Price { get; set; }

    [EmailAddress]
    [Column("AccountEmail")]
    public string UserEmail { get; set; } = null!;
    
    [NotMapped]
    public int PromoCode { get; set; }
}