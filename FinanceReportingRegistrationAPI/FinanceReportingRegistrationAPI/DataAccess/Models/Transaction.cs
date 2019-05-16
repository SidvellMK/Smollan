using System;

namespace DataAccess.Models
{
    public enum TransactionType{
        Credit = 1,
        Debit
    }
    public class Transaction
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TransactionType CreditOrDebit { get; set; }
        public string CardHolder { get; set; }
    }
}
