using AutoMapper;
using GameStore.DAL.Models;
using GameStore.Model.Common;
using GameStore.Repository.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private IRepository repository;

        public CommentRepository(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get comment
        /// </summary>
        public async Task<Model.Common.IComment> GetAsync(int id)
        {
            try
            {

                return Mapper.Map<IComment>(await repository.GetAsync<CommentEntity>(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get comments
        /// </summary>
        public async Task<IEnumerable<Model.Common.IComment>> GetAsync()
        {
            try
            {
                return Mapper.Map<IEnumerable<IComment>>(await repository.GetRangeAsync<CommentEntity>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add comment
        /// </summary>
        public async Task<int> AddAsync(Model.Common.IComment comment)
        {
            try
            {
                return await repository.AddAsync<CommentEntity>(Mapper.Map<CommentEntity>(comment));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAsync(Model.Common.IComment comment)
        {
            try
            {
                return await repository.UpdateAsync<CommentEntity>(Mapper.Map<CommentEntity>(comment));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(Model.Common.IComment comment)
        {
            try
            {
                return await repository.DeleteAsync<CommentEntity>(Mapper.Map<CommentEntity>(comment));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                return await this.DeleteAsync
                    (Mapper.Map<IComment>(await repository.GetAsync<CommentEntity>(id)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
