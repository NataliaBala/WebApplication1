namespace WebApplication1.Models.Services;

public class MemoryContactService : IContactService
{
    private Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ContactModel
            {
                Id = 1,
                FirstName = "Michał",
                LastName = "Brokuł",
                Email = "michał@wsei.edu.pl",
                Category = Category.Friend,
                BirthDate = new DateOnly(2005, 03, 25),
                PhoneNumber = "555 333 222"
            }
        },
        {
            2, 
            new ContactModel()
            {
                Id = 1,
                FirstName = "Maja",
                LastName = "Zupa",
                Category = Category.Business,
                Email = "Maja@wsei.edu.pl",
                BirthDate = new DateOnly(1999, 05, 12),
                PhoneNumber = "555 666 777"
            }
        },
        {
            3, 
            new ContactModel()
            {
                Id = 1,
                FirstName = "Emilia",
                LastName = "Borówka",
                Email = "Emilia@wsei.edu.pl",
                Category = Category.Family,
                BirthDate = new DateOnly(2023, 05, 31),
                PhoneNumber = "666 777 888"
            }
        }

    };

    private int _index = 3;

    public void Add(ContactModel model)
    {
        model.Id = ++_index;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel model)
    {
        if (_contacts.ContainsKey(model.Id))
        {
            _contacts[model.Id] = model;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }
}