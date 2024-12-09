using CarAuction.Domain.Base;

namespace CarAuction.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : Entity
    {
        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity retrieved or null if not found.</returns>
        T? GetById(long id);

        /// <summary>
        /// Retrieves all entities of type T.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Adds a new entity of type T.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>The added entity.</returns>
        T Add(T entity);

        /// <summary>
        /// Updates an existing entity of type T.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        T Update(T entity);

        /// <summary>
        /// Deletes an entity of type T.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        void Delete(T entity);
    }
}
