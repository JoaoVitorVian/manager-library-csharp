namespace Manager.Domain.Entities
{
    public class LoanBook : Base
    {
        public Guid LoanId { get; set; }
        public Loan Loan { get; set; }

        public Guid BookId { get; set; } 
        public Book Book { get; set; } 

        protected LoanBook() { }

        public LoanBook(Guid loanId, Guid bookId)
        {
            LoanId = loanId;
            BookId = bookId;
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
