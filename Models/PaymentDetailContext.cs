using Microsoft.EntityFrameworkCore;

namespace mini_app_pay.Models;

public class PaymentDetailContext:DbContext
{
    public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options):base(options)
    {
        
    }
    public DbSet<PaymentDetail> paymentDetails { get; set; }
}
