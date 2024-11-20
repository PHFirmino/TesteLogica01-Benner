using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLogico01
{
    internal class MessageException : Exception
    {
        public MessageException(string message) : base(message) 
        {
            
        }
    }
}
