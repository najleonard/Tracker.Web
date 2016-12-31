//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tracker.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.ItemOrders = new HashSet<ItemOrder>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<byte> Shipped { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public string RequestItems { get; set; }
        public string RequestDate { get; set; }
    
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemOrder> ItemOrders { get; set; }
    }
}