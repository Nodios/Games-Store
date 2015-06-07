
namespace GameStore.Common
{
    public class PublisherFilter : GenericFilter
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        public PublisherFilter(int pageNumber, int pageSize)
            : base(pageNumber, pageSize)
        {

        }
        #endregion
    }
}
