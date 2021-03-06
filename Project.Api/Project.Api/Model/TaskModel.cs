﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Model
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        public int ClientId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string ClientAddress { get; set; }
    }
}
