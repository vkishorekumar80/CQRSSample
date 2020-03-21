using System;
using System.Collections.Generic;
using System.Text;

using Cqrs.Domain.Dtos;

using MediatR;

namespace Cqrs.Domain.Commands
{
    public class CreateCustomerCommand:IRequest<NewCustomerDto>
    {
        public string Name { get;}
        public string Email { get;}
        public String Address { get;}
        public string Phone { get;}
        public int Age { get;}

        public CreateCustomerCommand(string name, string email, string address, string phone, int age) {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            Age = age;
        }
    }
}
