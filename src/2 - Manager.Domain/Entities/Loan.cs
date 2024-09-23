namespace Manager.Domain.Entities
{
    public class Loan : Base
    {
        public long TotalValue { get; set; }
        public long BooksQuantity { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime BorrowDate { get; set; }

        public decimal LateFeePerDay { get; set; }

        public ICollection<Library> Books { get; private set; }
        public ICollection<User> Users { get; private set; }

        public Loan()
        {
            Books = new List<Library>();
            Users = new List<User>();
            LateFeePerDay = 1.00m; // Valor padrão de multa por atraso ($1.00 por dia)
        }

        public void AddBook(Library book)
        {
            Books.Add(book);
            CalculateTotalValue();
            BooksQuantity = Books.Count;
        }

        private void CalculateTotalValue()
        {
            TotalValue = (long)Books.Sum(book => book.BookPrice);
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
