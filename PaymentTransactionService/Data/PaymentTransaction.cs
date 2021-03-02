using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        public long UserPaymentTransactionId { get; set; }
        [JsonIgnore]
        public UserPaymentTransaction UserPaymentTransaction { get; set; }
    }
}
