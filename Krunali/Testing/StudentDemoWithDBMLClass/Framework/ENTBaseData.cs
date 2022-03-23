using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDemoWithDBMLClass.Framework
{
    public abstract class ENTBaseData<T> where T : IENTBaseEntity
    {
        public abstract T Select(string connectionString, int id);

    }
}