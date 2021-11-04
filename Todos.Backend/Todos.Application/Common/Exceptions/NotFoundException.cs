using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Common.Exceptions
{
    public class NotFoundTodoException : Exception
    {
        public NotFoundTodoException(string name, object id, object userId)
            : base($"Entity \"{name}\" ({id}) by userID({userId}) not found.") { }
    }
}
