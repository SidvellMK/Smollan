using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Statement
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public DateTime StatementDate { get; set; }
        public float ClosingBalance { get; set; }
        public int StatementNumber { get; set; }
        public float OutstandingAmount { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public float CreditLimit { get; set; }
        public float AvailableAmount { get; set; }
        public float BalanceBroughtForward { get; set; }
        public float PaymentsAndCredits { get; set; }
        public float PurchasesAndDebits { get; set; }
        public float Interest { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
