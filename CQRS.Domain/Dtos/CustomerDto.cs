using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Domain.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public String Address { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }
}
