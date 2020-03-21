using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Domain.Models
{
    public abstract class ModelBase {
        public DateTime CreateOn => DateTime.UtcNow;
        public DateTime UpdatedOn => DateTime.UtcNow;
    }
}
