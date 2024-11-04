namespace WebApplication1.Models.Services;

public class MemoryContactService :IContactService
{
    private Dictionary<int, ContactModel> _contacts = new Dictionary<int, ContactModel>()
    {
        {1, new(){Id = 1, Email = "wsei@gmail.com", FirstName = "Michał", LastName = "Brokuł", Category = CategoryModel.Family, BirthDate = new DateOnly(2010, 05, 12), PhoneNumber = "444 444 444"}},
        {2, new(){Id = 2, Email = "jahybhds@gmail.com", FirstName = "Maja", LastName = "Kowalsk",Category = CategoryModel.Family, BirthDate = new DateOnly(1950, 12, 27), PhoneNumber = "777 444 333"}}, 
        {3, new(){Id = 3, Email = "huhagddn@gmail.com", FirstName = "Emilia", LastName = "Zupa",Category = CategoryModel.Friend , BirthDate = new DateOnly(1990, 10, 10), PhoneNumber = "111 222 333"}}
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