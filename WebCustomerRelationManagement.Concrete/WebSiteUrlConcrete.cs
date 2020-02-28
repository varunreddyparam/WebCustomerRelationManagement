using System;
using System.Collections.Generic;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class WebSiteUrlConcrete : IWebSiteURL
    {
        /// <summary>
        /// Declaration of Context
        /// </summary>
        private MonkeyCRMOrganizationDataContext monkeyCRMOrgEntitiesContext = null;


        /// <summary>
        /// Create WebSiteUrls
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns>Guid of WebsiteUrls</returns>
        public void CreateWebSiteUrl(tbl_WebsiteURL entity, string source, string initialCatalogue)
        {
            try
            {
                monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
                monkeyCRMOrgEntitiesContext.tbl_WebsiteURLs.InsertOnSubmit(entity);
                monkeyCRMOrgEntitiesContext.SubmitChanges();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// DeleteWebSiteUrls
        /// </summary>
        /// <param name="webSiteUrlId"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        public void DeleteWebsiteURL(Guid webSiteUrlId, string source, string initialCatalogue)
        {
            try
            {
                monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
                var webSiteUrl = (from webSiteUrlentity in monkeyCRMOrgEntitiesContext.tbl_WebsiteURLs
                                  where webSiteUrlentity.websiteurlid == webSiteUrlId
                                  select webSiteUrlentity).SingleOrDefault();
                if (webSiteUrl != null)
                {
                    monkeyCRMOrgEntitiesContext.tbl_WebsiteURLs.DeleteOnSubmit(webSiteUrl);
                    monkeyCRMOrgEntitiesContext.SubmitChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// retrieve table websiteUrls
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="contactType"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns>Collection of WebsiteUrls</returns>
        public IEnumerable<tbl_WebsiteURL> GetWebSiteByContact(Guid contactId, string contactType, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            var urlDeatil = (from webSiteUrl in monkeyCRMOrgEntitiesContext.tbl_WebsiteURLs
                             where webSiteUrl.customertype == contactId &&
                             webSiteUrl.customertypename == contactType
                             select webSiteUrl);
            return urlDeatil;
        }


        /// <summary>
        /// Update With WebSiteUrls
        /// </summary>
        /// <param name="websiteURL"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        public void UpdateWebsiteURL(tbl_WebsiteURL websiteURL, string source, string initialCatalogue)
        {
            try
            {
                monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
                //var contactEntity = monkeyCRMOrgEntitiesContext.tbl_WebsiteURLs.Where(key => key.websiteurlid == websiteURL.websiteurlid).FirstOrDefault();
                monkeyCRMOrgEntitiesContext.SubmitChanges();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
