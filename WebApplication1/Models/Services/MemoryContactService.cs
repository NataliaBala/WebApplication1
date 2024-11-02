namespace WebApplication1.Models.Services;

public class MemoryContactService :IContactService
{
    private Dictionary<int, ContactModel> _contacts = new Dictionary<int, ContactModel>()
    {
        {1, new(){Id = 1, Email = "wsei@gmail.com", FirstName = "Adam", LastName = "Brzeziak", Category = CategoryModel.Family, BirthDate = new DateOnly(1950, 10, 10), PhoneNumber = "666 666 666"}},
        {2, new(){Id = 2, Email = "dgshgds@gmail.com", FirstName = "Marcin", LastName = "Pypec",Category = CategoryModel.Business, BirthDate = new DateOnly(1930, 10, 10), PhoneNumber = "444 222 666"}}, 
        {3, new(){Id = 3, Email = "dsdsds@gmail.com", FirstName = "Dupa", LastName = "Debil",Category = CategoryModel.Friend , BirthDate = new DateOnly(1920, 10, 10), PhoneNumber = "777 111 666"}}
    };

    private static int _index = 3;//currentId = _contacts.Count;
    public void Add(ContactModel model)
    {
        model.Id = ++_index;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;  
        }

        //_contacts[contact.Id] = contact;
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel GetById(int id)
    {
        return _contacts[id];
    }
}