//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiabeticsHelper
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Insulin_Dosage = new HashSet<Insulin_Dosage>();
            this.Log_Book = new HashSet<Log_Book>();
            this.Meal_Routine = new HashSet<Meal_Routine>();
            this.Schedules = new HashSet<Schedule>();
            this.User_Setting = new HashSet<User_Setting>();
        }
    
        public long User_ID { get; set; }
        public System.DateTime Date_of_Birth { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Cell_Phone { get; set; }
        public Nullable<System.DateTime> Last_Activity { get; set; }
        public Nullable<int> Diabetes_Type { get; set; }
        public System.DateTime First_Diagnosed { get; set; }
        public bool Sex { get; set; }
        public int Country_ID { get; set; }
        public Nullable<int> City_ID { get; set; }
        public Nullable<int> Medicine_ID { get; set; }
    
        public virtual City City { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Insulin_Dosage> Insulin_Dosage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Log_Book> Log_Book { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meal_Routine> Meal_Routine { get; set; }
        public virtual Medicine Medicine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Setting> User_Setting { get; set; }
    }
}
