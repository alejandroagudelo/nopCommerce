using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Events
{
    /// <summary>
    /// A container for passing entities that have been status changed.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityChangeStatusEvent<T> where T : BaseEntity
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="entity">Entity</param>
        public EntityChangeStatusEvent(T entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// Entity
        /// </summary>
        public T Entity { get; }
    }
}
