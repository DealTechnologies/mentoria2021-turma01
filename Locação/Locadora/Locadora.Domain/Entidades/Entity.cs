﻿using Flunt.Notifications;
using System;

namespace Locadora.Domain.Entidades
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid GetId()
        {
            return Id;
        }
    }
}