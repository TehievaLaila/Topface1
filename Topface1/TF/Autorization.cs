//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Topface1.TF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Autorization
    {
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> ID_Role { get; set; }
        public int id_autorization { get; set; }
        public Nullable<int> ID_User { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
