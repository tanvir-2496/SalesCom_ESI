using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity.ViewModel
{
    public class SuccessMessage
    {
        public int Type { get; set; }
        public string Message { get; set; }

     
    }
    public static class Message
    {
        public enum MessageType
        {
            Success = 1,
            Fail
        }
    }
  
}

