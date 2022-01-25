using System;

namespace CsIO.Business.Core.Models
{
    public abstract class Entity
    {
        #region Constructor

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }

        #endregion
    }
}
