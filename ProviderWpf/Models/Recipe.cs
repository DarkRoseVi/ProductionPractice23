//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProviderWpf.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipe
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> IngredientId { get; set; }
        public Nullable<int> TeaId { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Ingredient Ingredient { get; set; }
        public virtual Product Product { get; set; }
        public virtual Tea Tea { get; set; }
    }
}
