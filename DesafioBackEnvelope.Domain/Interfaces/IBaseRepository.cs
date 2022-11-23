using System.Linq.Expressions;

namespace DesafioBackEnvelope.Domain.Interfaces
{
    /// <summary>
    /// Repositório genérico
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Busca todos os objetos no banco de dados
        /// </summary>
        /// <returns>Retorna todas as entidades encontradas</returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Busca o objeto que tenha a chave correspondente à solicitada no banco de dados
        /// </summary>
        /// <param name="id">Chave de identificação</param>
        /// <returns>Retorna a entidade encontrada</returns>
        Task<T> GetByIdAsync(int id);
        /// <summary>
        /// Busca os objetos que atendam ao parametro definido no banco de dados
        /// </summary>
        /// <param name="predicate">Parametro de busca</param>
        /// <returns>Retorna as entidades encontradas</returns>
        Task<IEnumerable<T>> GetByParamAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Insere um objeto ao banco de dados
        /// </summary>
        /// <param name="entity">objeto a ser inserido</param>
        /// <returns>Retorna o objeto inserido</returns>
        Task<T> InsertAsync(T entity);
        /// <summary>
        /// Insere varios objetos ao banco de dados
        /// </summary>
        /// <param name="entity">objetos a serem inseridos</param>
        /// <returns>Retorna os objetos inseridos</returns>
        Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> entity);
        /// <summary>
        /// Atualiza um objeto no banco de dados
        /// </summary>
        /// <param name="entity">objeto a ser atualizado</param>
        /// <returns>Retorna o objeto atualizado</returns>
        Task UpdateAsync(T entity);
        /// <summary>
        /// Atualiza varios objetos no banco de dados
        /// </summary>
        /// <param name="entity">objetos a serem atualizado</param>
        /// <returns>Retorna os objetos atualizados</returns>
        Task UpdateRangeAsync(IEnumerable<T> entity);
        /// <summary>
        /// Remove o objeto do banco de dados
        /// </summary>
        /// <param name="entity">objeto a ser Removido</param>
        /// <returns>Confirmação de conclusão da tarefa</returns>
        Task<bool> DeleteAsync(T entity);
        /// <summary>
        /// Remove varios objetos do banco de dados
        /// </summary>
        /// <param name="entity">objetos a serem Removidos</param>
        /// <returns>Confirmação de conclusão da tarefa</returns>
        Task<bool> DeleteRangeAsync(IEnumerable<T> entity);
    }
}
