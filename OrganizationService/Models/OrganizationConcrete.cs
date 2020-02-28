using OrganizationService.Interface;
using OrganizationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationService.Concrete
{
    /// <summary>
    /// OrganizationConcrete to Implement Iorganization
    /// </summary>
    public class OrganizationConcrete : IOrganization
    {
        /// <summary>
        /// Declaration for Context
        /// </summary>
        private OrganizationConfigDataContext monkeyCRMConfigEntities = null;

        /// <summary>
        /// Activate Organization
        /// </summary>
        /// <param name="organizationid"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        public void ActivateOrganization(Guid organizationid, string source, string initialCatalogue)
        {
            monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            var organization = this.GetOrganization(organizationid, source, initialCatalogue);
            if (organization != null)
            {
                organization.statuscode = true;
                organization.statuscodename = "Activated";
                this.UpdateOrganization(organization, source, initialCatalogue);
            }

        }

        /// <summary>
        /// CreateOrganization
        /// </summary>
        /// <param name="Organization"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public Guid CreateOrganization(tbl_Organization Organization, string source, string initialCatalogue)
        {
            monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            monkeyCRMConfigEntities.tbl_Organizations.InsertOnSubmit(Organization);
            monkeyCRMConfigEntities.SubmitChanges();
            return Organization.organizationid;
        }

        /// <summary>
        /// DeactivateOrganization
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        public void DeactivateOrganization(Guid organizationId, string source, string initialCatalogue)
        {
            monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            var organization = this.GetOrganization(organizationId, source, initialCatalogue);
            if (organization != null)
            {
                organization.statuscode = false;
                organization.statuscodename = "De-Activated";
                this.UpdateOrganization(organization, source, initialCatalogue);
            }

        }

        /// <summary>
        /// GetOrganization
        /// </summary>
        /// <param name="OrganizationId"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public tbl_Organization GetOrganization(Guid OrganizationId, string source, string initialCatalogue)
        {
            monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            return monkeyCRMConfigEntities.tbl_Organizations.Where(org => org.organizationid == OrganizationId).FirstOrDefault();
        }

        /// <summary>
        /// GetOrganizationByName
        /// </summary>
        /// <param name="OrganizationName"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public tbl_Organization GetOrganizationByName(string OrganizationName, string source, string initialCatalogue)
        {
            monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            return monkeyCRMConfigEntities.tbl_Organizations.Where(org => org.organizationname == OrganizationName).FirstOrDefault();
        }

        /// <summary>
        /// GetOrganizationUrl
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public string GetOrganizationUrl(Guid organizationId, string source, string initialCatalogue)
        {
            monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            var organization = this.GetOrganization(organizationId, source, initialCatalogue);
            if (organization != null)
                return organization.organizationurl;
            else
                return null;
        }

        /// <summary>
        /// UpdateOrganization
        /// </summary>
        /// <param name="Organization"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        public void UpdateOrganization(tbl_Organization Organization, string source, string initialCatalogue)
        {
            monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            monkeyCRMConfigEntities.SubmitChanges();
        }

        /// <summary>
        /// GetAllOrganizations
        /// </summary>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public IEnumerable<tbl_Organization> GetAllOrganizations(string source, string initialCatalogue)
        {
            monkeyCRMConfigEntities = new OrganizationConfigDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            return monkeyCRMConfigEntities.tbl_Organizations;
        }
    }
}
