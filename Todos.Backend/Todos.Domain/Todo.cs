using System;

namespace Todos.Domain
{
    class Todo
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isCompleted { get; set; }
        public DateTime ReminderDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
