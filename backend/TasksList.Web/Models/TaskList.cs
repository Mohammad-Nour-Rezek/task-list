using System;
using System.Collections.Generic;

#nullable disable

namespace TasksList.Web.Models
{
    public partial class TaskList
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? Day { get; set; }
        public bool? Reminder { get; set; }
        public bool IsRemoved { get; set; }
    }
}

// Scaffold-DbContext "Server=MOHAMMADNOUR\SQLEXPRESS01;Database=TasksList;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force