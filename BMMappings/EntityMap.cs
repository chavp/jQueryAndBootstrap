using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public abstract class EntityMap<T>
        : ClassMap<T> where T : Entity
    {
        public EntityMap(string prefix, bool isIDIncrement = true)
        {
            if (isIDIncrement)
            {
                Id(t => t.ID, prefix + "_ID").GeneratedBy.Increment();
            }
            else
            {
                Id(t => t.ID, prefix + "_ID").GeneratedBy.Sequence("SQ_" + prefix);
            }
        }

        protected void MapVersion()
        {
            Map(t => t.CreatedAt, "CREATED_DATETIME").Not.Nullable();
            Map(t => t.CreatedBy, "CREATED_BY").Length(50).Not.Nullable();

            Version(t => t.ModifiedOn).Column("UPDATE_DATETIME");
            Map(t => t.ModifiedBy, "UPDATE_BY").Length(50);
        }
    }
}
