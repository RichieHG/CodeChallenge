using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MessagesBrokerInterfaces
{
    public interface IConsumer
    {
        void GetMessages();
    }
}
