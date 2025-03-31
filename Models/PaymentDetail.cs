using System.ComponentModel.DataAnnotations;

namespace mini_app_pay.Models;
   
public class PaymentDetail
{
    [Key]
    public int PaymentDetailId { get; set; }
    [MaxLength(100)]
    public string OwnerName { get; set; }
    [MaxLength(16)]
    public string CardNumber { get; set; }
    [MaxLength(5)]
    public string ExpireDate { get; set; }
    [MaxLength(3)]
    public string SecurityCode { get; set; }
}
