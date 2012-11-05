using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatManagerService.ChatResponseObject
{
    public abstract class CommonAttribute
    {
        private object _message = string.Empty;
        public object Response { get; set; }
        public object Message { get { return this._message; } set { this._message = value; } }
    }
}