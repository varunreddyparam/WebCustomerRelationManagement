using System;
using System.Linq;
using System.Collections.Generic;
using OrganizationService.Models;
using OrganizationService.Interface;

namespace OrganizationService.Concrete
{
    public class OrganizationConcrete : IOrganization
    {
        public OrganizationConfigDataContext monkeyCRMConfigEntities = null;
        public void ActivateOrganization(Guid organizationid, string source, string initialCatalogue)
        {
            using (monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source)))
            {
                var organization = this.GetOrganization(organizationid, source, initialCatalogue);
                if (organization != null)
                {
                    organization.statuscode = true;
                    organization.statuscodename = "Activated";
                    this.UpdateOrganization(organization, source, initialCatalogue);
                }

            }

        }

        public Guid CreateOrganization(tbl_Organization Organization, string source, string initialCatalogue)
        {
            using (monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source)))
            {
                monkeyCRMConfigEntities.tbl_Organizations.InsertOnSubmit(Organization);
                monkeyCRMConfigEntities.SubmitChanges();
                return Organization.organizationid;
            }
        }

        public void DeactivateOrganization(Guid organizationId, string source, string initialCatalogue)
        {
            using (monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source)))
            {
                var organization = this.GetOrganization(organizationId, source, initialCatalogue);
                if (organization != null)
                {
                    organization.statuscode = false;
                    organization.statuscodename = "De-Activated";
                    this.UpdateOrganization(organization, source, initialCatalogue);
                }

            }
        }

        public tbl_Organization GetOrganization(Guid OrganizationId, string source, string initialCatalogue)
        {
            using (monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source)))
            {
                return monkeyCRMConfigEntities.tbl_Organizations.Where(org => org.organizationid == OrganizationId).FirstOrDefault();
            }
        }

        public string GetOrganizationUrl(Guid organizationId, string source, string initialCatalogue)
        {
            using (monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source)))
            {
                var organization = this.GetOrganization(organizationId, source, initialCatalogue);
                if (organization != null)
                    return organization.organizationurl;
                else
                    return null;
            }
        }

        public void UpdateOrganization(tbl_Organization Organization, string source, string initialCatalogue)
        {
            using (monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source)))
            {
                monkeyCRMConfigEntities.SubmitChanges();
            }
        }
        public IEnumerable<tbl_Organization> GetAllOrganizations(string source, string initialCatalogue)
        {
            using (monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source)))
            {
                return monkeyCRMConfigEntities.tbl_Organizations;
            }
        }
    }
}
