using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; }
        public string Specie { get; set; }
        public string Race { get; set; }
        public DateTime BirtDate { get; set; }

        private int _age;
        public int Age
        {
            get
            {
                if(this._age <= 0)
                {
                    this._age = new DateTime(DateTime.UtcNow.Subtract(this.BirtDate).Ticks).Year - 1;
                }
                return this._age;
            }
        }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
