﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateCoreWebAPI.Model.Abstractions;

namespace UltimateCoreWebAPI.Model.Entities
{
    public class TodoPriority : IEntity
    {
        public Guid Id { get; set; }

        public short Prio { get; set; }

        public string Designation { get; set; }
    }
}