namespace Manager.Domain.Entities
{
    public class LoanBooks : Base
    {
        public Guid LoanId { get; set; }
        public Loan Loan { get; set; }

        public Guid BookId { get; set; } 
        public Library Book { get; set; } 

        protected LoanBooks() { }

        public LoanBooks(Guid loanId, Guid bookId)
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
