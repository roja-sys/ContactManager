using Microsoft.AspNetCore.Mvc;
using ContactManager.Models; // adjust if your model namespace differs

public class ContactController : Controller
{
    private static List<Contact> contacts = new List<Contact>
    {
        new Contact { Id = 1, Name = "Alice", Email = "alice@email.com", Phone = "123-456-7890" },
        new Contact { Id = 2, Name = "Bob", Email = "bob@email.com", Phone = "987-654-3210" }
    };

    public IActionResult Index(string searchString)
    {
        var filteredContacts = string.IsNullOrEmpty(searchString)
            ? contacts
            : contacts.Where(c => c.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

        return View(filteredContacts);
    }

    // 👉 Show the form
    public IActionResult Create()
    {
        return View();
    }

    // 👉 Handle form submission
    [HttpPost]
    public IActionResult Create(Contact contact)
    {
        contact.Id = contacts.Max(c => c.Id) + 1; // auto-increment ID
        contacts.Add(contact);
        return RedirectToAction("Index");
    }
}
