using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Common
{
    public class PostFilter : GenericFilter
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        public PostFilter(int pageNumber, int pageSize)
            : base(pageNumber, pageSize)
        {
            base.defaultPageSize = 15;
        }

        #endregion
    }
}
