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
    
    public partial class Shipment
    {
        public int Id { get; set; }
        public Nullable<int> IngredientId { get; set; }
        public Nullable<int> ManufacturerId { get; set; }
        public Nullable<int> TeaId { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Ingredient Ingredient { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Tea Tea { get; set; }
    }
}
