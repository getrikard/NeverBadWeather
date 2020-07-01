using System;
using System.Collections.Generic;
using System.Text;

namespace NeverBadWeather.DomainModel
{
    public class BaseEntity
    {
        public Guid Id { get; }

        public BaseEntity() : this(Guid.NewGuid())
        {
        }

        public BaseEntity(Guid id)
        {
            Id = id;
        }
    }
}
