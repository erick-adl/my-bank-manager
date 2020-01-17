﻿using System;
using FluentValidation.Results;

namespace MyBankManager.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ (GetType().GetHashCode() * 907);
        }

        public abstract bool IsValid();

        public static bool operator ==(Entity leftEntity, Entity rightEntity)
        {
            if (ReferenceEquals(leftEntity, null) && ReferenceEquals(rightEntity, null))
                return true;

            if (ReferenceEquals(leftEntity, null) || ReferenceEquals(rightEntity, null))
                return false;

            return leftEntity.Equals(rightEntity);
        }

        public static bool operator !=(Entity leftEntity, Entity rightEntity)
        {
            return !(leftEntity == rightEntity);
        }

        public override string ToString()
        {
            return GetType().Name + " [ID =" + Id + "]";
        }
    }
}