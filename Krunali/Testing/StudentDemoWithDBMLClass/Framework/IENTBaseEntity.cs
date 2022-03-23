using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDemoWithDBMLClass.Framework
{
    public interface IENTBaseEntity
    {
        int InsertedBy { get; set; }
        DateTime InsertDateTime { get; set; }
        int UpdatedBy { get; set; }
        DateTime UpdateDateTime { get; set; }
    }
}