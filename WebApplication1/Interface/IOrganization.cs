using System;
using WebOrganizationService.Models;

namespace WebOrganizationService.Interface
{
    internal interface IOrganization
    {
        tbl_Organization GetOrganization(Guid OrganizationId);
        void UpdateOrganization(Guid OrganizationId);
        Guid CreateOrganization();
        void DeactivateOrganization(Guid OrganizationId);
        void ActivateOrganization(Guid OrganizationId);
        string GetOrganizationUrl(Guid OrganizationId);
    }
}
