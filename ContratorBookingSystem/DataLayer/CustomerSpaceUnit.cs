//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerSpaceUnit
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SpaceUnitId { get; set; }
        public Nullable<System.Guid> GroupId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual SpaceUnit SpaceUnit { get; set; }
    }
}
