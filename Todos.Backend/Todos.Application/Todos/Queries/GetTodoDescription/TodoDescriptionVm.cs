﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Todos.Queries.GetTodoDescription
{
    public class TodoDescriptionVm
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? ReminderDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
