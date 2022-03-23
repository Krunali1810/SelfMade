using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using StudentDemoWithDBMLClass.Framework;

namespace StudentDemoWithDBMLClass.Models
{

    public partial class Student_MasterDataContext : IENTBaseEntity
    {
        public int InsertedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime InsertDateTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UpdatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime UpdateDateTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class CustomisedEntities
    {

    }
}