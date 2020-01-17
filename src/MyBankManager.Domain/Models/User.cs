using Microsoft.EntityFrameworkCore;

namespace MyBankManager.Domain.Models
{
    [Owned]
    public class Client
    {
        public Client() { }
        public Client(string name, string document)
        {
            Name = name;
            Document = document;
        }
        public string Name { get; set; }
        public string Document { get; set; }
    }
}
