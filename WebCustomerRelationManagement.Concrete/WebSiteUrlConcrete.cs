using System;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class WebSiteUrlConcrete : IWebSiteURL
    {
        public void CreateWebSiteUrl(tbl_WebsiteURL entity)
        {
            try
            {
                using (var context = new MonkeyCRMEntities())
                {
                    context.tbl_WebsiteURL.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public int DeleteWebsiteURL(Guid webSiteUrlId)
        {
            try
            {
                var context = new MonkeyCRMEntities();
                var webSiteUrl = (from webSiteUrlentity in context.tbl_WebsiteURL
                                    where webSiteUrlentity.websiteurlid == webSiteUrlId
                                    select webSiteUrlentity).SingleOrDefault();
                if (webSiteUrl != null)
                {
                    context.tbl_WebsiteURL.Remove(webSiteUrl);
                    int resultWebSiteUrl = context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<tbl_WebsiteURL> GetWebSiteByContact(Guid contactId, string contactType)
        {
            var _Context = new MonkeyCRMEntities();
            var urlDeatil = (from webSiteUrl in _Context.tbl_WebsiteURL
                             where webSiteUrl.customertype == contactId &&
                             webSiteUrl.customertypename == contactType
                             select webSiteUrl);
            return urlDeatil;
        }

        public void UpdateWebsiteURL(tbl_WebsiteURL websiteURL)
        {
            try
            {
                using (var context = new MonkeyCRMEntities())
                {
                    var contactEntity = context.tbl_WebsiteURL.Where(key => key.websiteurlid == websiteURL.websiteurlid).SingleOrDefault();
                    context.Entry(contactEntity).CurrentValues.SetValues(websiteURL);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
