namespace Laxsan.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets the entity by id
        /// </summary>
        /// <param name="id">entity id </param>
        /// <returns> entity </returns>
        TEntity Get(string id);

        /// <summary>
        /// Gets all the entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Adds the entity
        /// </summary>
        /// <param name="entity">entity to add</param>
        /// <returns>Entity which was added</returns>
        /// 
        TEntity Add(TEntity entity);

        /// <summary>
        /// Adds the range of entities
        /// </summary>
        /// <param name="entities">entities to be add</param>
        /// <returns></returns>
         void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Deletes the entity
        /// </summary>
        /// <param name="entity"> entity to be deleted </param>
        /// <returns></returns>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes the range of entities
        /// </summary>
        /// <param name="entities">entities to be added</param>
        /// <returns></returns>
        void DeleteRange(IEnumerable<TEntity> entities);
       
    }

}
