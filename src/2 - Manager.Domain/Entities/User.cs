using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Domain.Validators;

public class User : Base
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; set; }

    public ICollection<Library> Books { get; private set; }
    public ICollection<Loan> Loans { get; private set; }

    protected User()
    {
        Books = new List<Library>();
        Loans = new List<Loan>();
    }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        Books = new List<Library>();
        Loans = new List<Loan>();
        _errors = new List<string>();
    }

    public void AddBook(Library book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Library book)
    {
        Books.Remove(book);
    }

    public override bool Validate()
    {
        var validator = new UserValidator();
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