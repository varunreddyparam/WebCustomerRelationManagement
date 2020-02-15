using OrganizationService.Models;
using System;
using System.Collections.Generic;

namespace OrganizationService.Interface
{
    internal interface IOrganization
    {
        tbl_Organization GetOrganization(Guid OrganizationId, string source, string initialCatalogue);
        void UpdateOrganization(tbl_Organization Organization, string source, string initialCatalogue);
        Guid CreateOrganization(tbl_Organization Organization, string source, string initialCatalogue);
        void DeactivateOrganization(Guid OrganizationId, string source, string initialCatalogue);
        void ActivateOrganization(Guid OrganizationId, string source, string initialCatalogue);
        string GetOrganizationUrl(Guid OrganizationId, string source, string initialCatalogue);
        IEnumerable<tbl_Organization> GetAllOrganizations(string source, string initialCatalogue);
    }
}
