using System;
using WebOrganizationService.Interface;
using WebOrganizationService.Models;

namespace WebOrganizationService.Concrete
{
    public class OrganizationConcrete : IOrganization
    {
        private MonkeyCRMConfigEntities monkeyCRMConfigEntities = null;
        public string ActivateOrganization(Guid organizationid)
        {
            monkeyCRMConfigEntities = new MonkeyCRMConfigEntities();
            if(monkeyCRMConfigEntities.tbl_Organization.Find(organizationid) == null)
            {
                return ""
            }

        }

        public Guid CreateOrganization()
        {
            throw new NotImplementedException();
        }

        public void DeactivateOrganization(Guid OrganizationId)
        {
            throw new NotImplementedException();
        }

        public tbl_Organization GetOrganization(Guid OrganizationId)
        {
            throw new NotImplementedException();
        }

        public string GetOrganizationUrl(Guid OrganizationId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrganization(Guid OrganizationId)
        {
            throw new NotImplementedException();
        }
    }
}
