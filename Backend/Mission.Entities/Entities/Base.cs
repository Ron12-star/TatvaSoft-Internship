using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Entities
{
    public class Base
    {
        public DateTime CreateDate {  get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }

    }
}
