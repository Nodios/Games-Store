using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Common
{
    public class GameFilter : GenericFilter
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public GameFilter(int pageNumber, int pageSize)
            : base(pageNumber, pageSize)
        {
            
        }

        #endregion     

    }
}
