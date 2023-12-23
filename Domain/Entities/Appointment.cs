using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public DateTime DateAppt { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
    }
}
