using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
   public interface IEmailRepository
    {
        public void SendEmail(string fromAddress, string password, string toaddress, string subject, string body);
    }
}
