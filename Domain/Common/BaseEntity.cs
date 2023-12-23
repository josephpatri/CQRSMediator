﻿using System;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
    }
}