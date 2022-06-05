﻿using BroadageEntity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BroadageEntity.Entities
{
    public class Status : EntityBase<int>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
