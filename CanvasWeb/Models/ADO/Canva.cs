//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CanvasWeb.Models.ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Canva
    {
        public int CanvasId { get; set; }
        public string Key_Partners { get; set; }
        public string Value_Propositions { get; set; }
        public string Customer_Relationships { get; set; }
        public string Customer_Segments { get; set; }
        public string Key_Resources { get; set; }
        public string Channels { get; set; }
        public string Cost_Structure { get; set; }
        public string Revenue_Streams { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}