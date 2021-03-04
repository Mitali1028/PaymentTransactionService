using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace PaymentTransactionService.Data
{
    public class PaymentTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long Id { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        [JsonIgnore]
        public long UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
