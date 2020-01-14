using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Interface
{
    interface IOrganization
    {
        Organization GetOrganization(Guid OrganizationId);
        void UpdateOrganization(Guid OrganizationId);
        Guid CreateOrganization();
        void DeactivateOrganization(Guid OrganizationId);
        void ActivateOrganization(Guid OrganizationId);
        string GetOrganizationUrl(Guid OrganizationId);
    }
}
