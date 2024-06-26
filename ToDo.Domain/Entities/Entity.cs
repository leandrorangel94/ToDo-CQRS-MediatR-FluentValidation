﻿namespace ToDo.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(Entity? other)
        {
            if (other != null)
                return Id == other.Id;
            return false;
        }
    }
}
