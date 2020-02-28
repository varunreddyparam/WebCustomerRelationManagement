using OrganizationService.Concrete;
using OrganizationService.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OrganizationService.Controllers
{
    /// <summary>
    /// Organization Controller
    /// </summary>
    public class OrganizationController : ApiController
    {
        /// <summary>
        /// source
        /// </summary>
        public string source = "DESKTOP-N8FHTDG";
        /// <summary>
        /// initialCatalog
        /// </summary>
        public string initialCatalog = "MonkeyCRMConfig";

        /// <summary>
        /// GetAllOrganization
        /// </summary>
        /// <returns></returns>
        // GET: api/Organization
        public IEnumerable<tbl_Organization> GetAllOrganization()
        {
            return new OrganizationConcrete().GetAllOrganizations(source, initialCatalog);
        }

        /// <summary>
        /// GetOrganizationDetail 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Organization/5
        public tbl_Organization GetOrganization(Guid id)
        {
            return new OrganizationConcrete().GetOrganization(id, source, initialCatalog);
        }

        /// <summary>
        /// Create Organization
        /// </summary>
        /// <param name="orgName"></param>
        /// <returns></returns>
        // POST: api/Organization
        [HttpPost]
        public Guid CreateOrganization([FromUri]string orgName)
        {
            tbl_Organization tableOrg = new tbl_Organization();
            tableOrg.organizationid = Guid.NewGuid();
            tableOrg.organizationname = orgName;
            tableOrg.createdon = DateTime.Now.Date;
            tableOrg.modifiedon = DateTime.Now.Date;
            tableOrg.organizationurl = string.Format("https://{0}.com", orgName);
            tableOrg.createdby = new Guid("1cbdb00f-07d0-4644-b3f2-11d63dcfde0c");
            tableOrg.createdbyname = "Admin";
            tableOrg.modifiedby = new Guid("1cbdb00f-07d0-4644-b3f2-11d63dcfde0c");
            tableOrg.modifiedbyname = "Admin";
            tableOrg.statuscode = true;
            tableOrg.statuscodename = "Activated";
            return new OrganizationConcrete().CreateOrganization(tableOrg, source, initialCatalog);
        }

        /// <summary>
        /// Activate Organization
        /// </summary>
        /// <param name="OrgId"></param>
        /// <param name="Status"></param>
        [Route("api/Organization/Activate")]
        [HttpPut]
        // PUT: api/Organization/Activate
        public void Activate([FromUri]Guid OrgId, [FromUri]bool Status)
        {
            new OrganizationConcrete().ActivateOrganization(OrgId, source, initialCatalog);
        }

        /// <summary>
        /// Deactivate Organization
        /// </summary>
        /// <param name="OrgId"></param>
        /// <param name="Status"></param>
        [Route("api/Organization/DeActivate")]
        [HttpPut]
        public void DeActivate([FromUri]Guid OrgId, [FromUri]bool Status)
        {
            new OrganizationConcrete().DeactivateOrganization(OrgId, source, initialCatalog);
        }

    }
}
