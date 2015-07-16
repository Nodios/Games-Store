
using System;
namespace GameStore.DAL.Models
{
    /// <summary>
    /// Provides data contract for databae entites
    /// </summary>
    public interface IDataEntity
    {
        Guid Id { get; set; }
    }
}
