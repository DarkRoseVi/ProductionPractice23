//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminTeaShopWpf.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.ProductOrder = new HashSet<ProductOrder>();
        }
    
        public int Id { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> TypeOrderId { get; set; }
        public Nullable<int> TypePaymentId { get; set; }
        public string Chek { get; set; }
        public string Adress { get; set; }
        public Nullable<int> TableId { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Tabel Tabel { get; set; }
        public virtual TypeOrder TypeOrder { get; set; }
        public virtual TypePaument TypePaument { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
    }
}
