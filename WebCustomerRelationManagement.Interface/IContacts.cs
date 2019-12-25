using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Interface
{
    public interface IContacts 
    {
        int GetTotalContactsCount();

        int GetTotalContactbyType(int contactType);
        
        
        

    }
}
