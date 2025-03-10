using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Domain.Validators;

public class Book : Base
{
    public string Name { get; set; }
    public string Img { get; set; }
    public string ISBN { get; set; }
    public string Editor { get; set; }
    public long NumberOfPages { get; set; }
    public long CodeSerial { get; set; }
    public long StockQuantity { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public bool IsRead { get; set; }

    public ICollection<User> Users { get; private set; }
    public ICollection<LoanBook> LoanBooks { get; set; }
    protected Book()
    {
        Users = new List<User>();
    }

    public Book(string name, string img, long codeSerial, long stockQuantity, decimal bookPrice, bool isActive, bool isRead)
    {
        Name = name;
        Img = img;
        CodeSerial = codeSerial;
        StockQuantity = stockQuantity;
        Price = bookPrice;
        IsActive = isActive;
        IsRead = isRead;
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