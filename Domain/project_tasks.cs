//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektiHaldus.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class project_tasks
    {
        public int project_task_id { get; set; }
        public int project_id { get; set; }
        public string description { get; set; }
        public string worker_name { get; set; }
        public System.DateTime start_date_time { get; set; }
        public System.DateTime end_date_time { get; set; }
        public System.TimeSpan time_spent { get; set; }
        public string name { get; set; }
    
        public virtual project project { get; set; }
    }
}
