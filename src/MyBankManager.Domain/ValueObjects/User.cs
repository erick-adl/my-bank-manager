using Microsoft.EntityFrameworkCore;

namespace MyBankManager.Domain.ValueObjects
{
    [Owned]
    public class User
    {
        public User() { }
        public User(string name, string document)
        {
            Name = name;
            Document = document;
        }
        public string Name { get; set; }
        public string Document { get; set; }
    }
}
