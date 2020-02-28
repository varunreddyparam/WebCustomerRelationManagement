using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class AddressConcrete : IAddress
    {
        /// <summary>
        /// Declaration of Context
        /// </summary>
        private MonkeyCRMOrganizationDataContext monkeyCRMOrgEntitiesContext = null;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        public void CreateAddress(tbl_Address entity, string source, string initialCatalogue)
        {
            try
            {
                monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
                monkeyCRMOrgEntitiesContext.tbl_Addresses.InsertOnSubmit(entity);
                monkeyCRMOrgEntitiesContext.SubmitChanges();

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressid"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        public void DeleteAddress(Guid addressid, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            try
            {
                var address = (from addressentity in monkeyCRMOrgEntitiesContext.tbl_Addresses
                               where addressentity.addressid == addressid
                               select addressentity).SingleOrDefault();
                if (address != null)
                {
                    monkeyCRMOrgEntitiesContext.tbl_Addresses.DeleteOnSubmit(address);
                    monkeyCRMOrgEntitiesContext.SubmitChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="contactType"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        /// <returns></returns>
        public IEnumerable<tbl_Address> GetAddressByContact(Guid contactId, string contactType, string source, string initialCatalogue)
        {
            monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
            var addressDeatil = (from address in monkeyCRMOrgEntitiesContext.tbl_Addresses
                                 where address.customertype == contactId &&
                                 address.customertypename == contactType
                                 select address);
            return addressDeatil;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="source"></param>
        /// <param name="initialCatalogue"></param>
        public void UpdateAddress(tbl_Address address, string source, string initialCatalogue)
        {
            try
            {
                monkeyCRMOrgEntitiesContext = new MonkeyCRMOrganizationDataContext(Connection.ConstructConnectionString(initialCatalogue, source));
                //var contactEntity = context.tbl_Addresses.Where(key => key.addressid == address.addressid).SingleOrDefault();
                monkeyCRMOrgEntitiesContext.SubmitChanges();
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}
