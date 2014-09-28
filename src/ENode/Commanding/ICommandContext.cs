﻿using ENode.Domain;
using ENode.Eventing;

namespace ENode.Commanding
{
    /// <summary>Represents a command context for command handler handling command.
    /// </summary>
    public interface ICommandContext
    {
        /// <summary>Add a new aggregate into the current command context.
        /// </summary>
        /// <param name="aggregateRoot"></param>
        void Add(IAggregateRoot aggregateRoot);
        /// <summary>Get an aggregate from the current context.
        /// <remarks>
        /// 1. If the aggregate already exist in the current context, then return it directly;
        /// 2. If not exist then try to get it from memory cache;
        /// 3. If still not exist then try to get it from event store;
        /// Finally, if the specified aggregate still not found, then AggregateRootNotFoundException will be raised; otherwise, returns the found aggregate.
        /// </remarks>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get<T>(object id) where T : class, IAggregateRoot;
        /// <summary>Add a new event into the current command context.
        /// </summary>
        /// <param name="evnt"></param>
        void Add(IEvent evnt);
    }
}
