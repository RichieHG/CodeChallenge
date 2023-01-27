using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatedModels
{
    public class Message<T>
    {
        public string Type { get; set; }
        public T  Content { get; set; }
    }
}
