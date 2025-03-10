namespace Manager.Domain.Entities
{
    public class Loan : Base
    {
        public decimal TotalValue { get; set; }
        public long BooksQuantity { get; set; }
        public Enum BookStatus { get; set; } // Verificar como usar o enum neste caso.
        public DateTime ReturnDate { get; set; }
        public DateTime BorrowDate { get; set; }

        public decimal LateFeePerDay { get; set; }

        public ICollection<Book> Books { get; private set; }
        public User Users { get; private set; }
        public ICollection<LoanBook> LoanBooks { get; set; }

        public Loan()
        {
            Books = new List<Book>();
            LateFeePerDay = 1.00m; // Valor padrão de multa por atraso ($1.00 por dia)
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            CalculateTotalValue();
            BooksQuantity = Books.Count;
        }

        private void CalculateTotalValue()
        {
            TotalValue = (long)Books.Sum(book => book.Price);
        }


        public decimal CalculateLateFee()
        {
            if (ReturnDate > BorrowDate.AddDays(15))
            {
                var lateDays = (ReturnDate - BorrowDate.AddDays(15)).Days;
                return lateDays * LateFeePerDay;
            }

            return 0;
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
