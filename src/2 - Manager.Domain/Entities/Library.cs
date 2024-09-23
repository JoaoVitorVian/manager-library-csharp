using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Domain.Validators;

public class Library : Base
{
    public string BookName { get; set; }
    public string BookImg { get; set; }
    public long BookCodeSerial { get; set; }
    public long BookStockQuantity { get; set; }
    public decimal BookPrice { get; set; }
    public bool BookExists { get; set; }
    public bool BookRead { get; set; }

    public ICollection<User> Users { get; private set; }

    protected Library()
    {
        Users = new List<User>();
    }

    public Library(string bookName, string bookImg, long bookCodeSerial, long bookStockQuantity, decimal bookPrice, bool bookExists, bool bookRead)
    {
        BookName = bookName;
        BookImg = bookImg;
        BookCodeSerial = bookCodeSerial;
        BookStockQuantity = bookStockQuantity;
        BookPrice = bookPrice;
        BookExists = bookExists;
        BookRead = bookRead;
        Users = new List<User>();
        _errors = new List<string>();
    }

    public override bool Validate()
    {
        var validator = new LibraryValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
                _errors.Add(error.ErrorMessage);

            throw new DomainExceptions("Alguns campos estão invalidos, corrija-os", _errors);
        }
        return true;
    }
}