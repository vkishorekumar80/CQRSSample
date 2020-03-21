using System;

namespace Cqrs.Domain.Models
{
    public class Customer: ModelBase
    {
        public Customer(  string name, int age, string email, string address, string phone) {
            Age = age;
            //Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string  Phone { get; set; }

        public int Age { get; set; }

        
    }
}
