using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareLab.Core.Exceptions
{
    public class UserAlreadyCreated : Exception
    {
        public UserAlreadyCreated(string? message) : base(message)
        {
        }
    }
}
