using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class OrganizationConcrete : IEntity
    {
        public OrganizationConcrete()
        {

        }

        /// <summary>
        /// When User is ready to create account with Monkey CRM, Registration process starts with setup of Organization and then add himself as user in to the org.
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="requestBody"></param>
        /// <param name="azureTableStorage"></param>
        /// <returns></returns>
        public async Task<string> CreateRequest(string entityLogicalName, string OrganizationId, string UserId, string requestBody, AzureTableStorage azureTableStorage)
        {
            if (requestBody != null)
            {
                if (await this.SetupOrganization(entityLogicalName, requestBody, azureTableStorage) != null)
                    return JsonConvert.SerializeObject(true);
                //JsonConvert.SerializeObject(await azureTableStorage.AddAsync(entityLogicalName, entity));
            }
            return JsonConvert.SerializeObject(false);
        }

        public Task<string> DeleteRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> RetrieveMultipleRequest(QueryDeSerializer queryExpression, AzureTableStorage azureTableStorage)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Retrieve Organization based on the Name in request body and 
        /// Retrieve Organization Name based on Id, Tablename and partion key (Entity Logical Name)
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="Id"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public async Task<string> RetrieveSingleRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            if (requestBody != null)
            {
                object orgObject = JsonConvert.DeserializeObject(requestBody);
                var getOgId = await this.GetOrganization(orgObject, azureTableStorage, entityLogicalName);
                if (getOgId.Length > 2)
                    return getOgId;
            }
            return JsonConvert.SerializeObject(await azureTableStorage.GetAsync<OrganizationEntity>(entityLogicalName, entityLogicalName, Id));
        }

        public Task<string> UpdateRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UpsertRequest(string entityLogicalName, string Id, string requestBody, AzureTableStorage azureTableStorage)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// GetOrganization detail from the orgObject
        /// </summary>
        /// <param name="orgObject"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public async Task<string> GetOrganization(object orgObject, AzureTableStorage azureTableStorage, string entityLogicalName)
        {
            TableQuery<OrganizationEntity> table = new TableQuery<OrganizationEntity>();
            table.Where(TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, entityLogicalName),
                TableOperators.And,
                TableQuery.GenerateFilterCondition("Organizationname", QueryComparisons.Equal, ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JProperty)((Newtonsoft.Json.Linq.JContainer)orgObject).First).Value).Value.ToString())));
            return JsonConvert.SerializeObject(await azureTableStorage.QueryAsync(entityLogicalName, table));
        }

        /// <summary>
        /// OrganizationName is available or not
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="Id"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public async Task<string> ValidateRequest(string entityLogicalName, string Id, AzureTableStorage azureTableStorage, string requestBody)
        {
            if (requestBody != null)
            {
                object orgObject = JsonConvert.DeserializeObject(requestBody);
                var getOgId = await this.GetOrganization(orgObject, azureTableStorage, entityLogicalName);
                if (getOgId.Length > 2)
                    return JsonConvert.SerializeObject(true);
                else
                    return JsonConvert.SerializeObject(false);
            }
            return JsonConvert.SerializeObject(false);
        }

        /// <summary>
        /// 1. Sign up requestbody is deserialized to Registration Model.
        /// 2. To create the Organization and user in the ServiceAccount User is used as the Owner of the Organization.
        /// 3. Once Organization is create the User will be created under newly created Organization.
        /// 4. Address will be created in address entity under the newly created Org and Updates Organization and user with the newly created Address
        /// 5. Userprivileges will be given as full access for the first created User (System Admin)
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="requestBody"></param>
        /// <param name="azureTableStorage"></param>
        /// <returns></returns>
        private async Task<string> SetupOrganization(string entityLogicalName, string requestBody, AzureTableStorage azureTableStorage)
        {
            OrganizationEntity entity = new OrganizationEntity(Guid.NewGuid());
            var registration = JsonConvert.DeserializeObject<Registration>(requestBody);
            UserEntity ownerEntity = JsonConvert.DeserializeObject<UserEntity>(await new UserConcrete().RetrieveSingleRequest("User", "95ec7100-e877-4f9d-8d69-a6b495105f99", azureTableStorage, null));
            entity = JsonConvert.DeserializeObject<OrganizationEntity>(await this.CreateOrganization(entity, registration, azureTableStorage, ownerEntity));
            UserEntity userEntity = new UserEntity(Guid.NewGuid());
            userEntity = JsonConvert.DeserializeObject<UserEntity>(await this.CreateUser(entity, registration, azureTableStorage, ownerEntity, userEntity));
            AddressEntity addressEntity = new AddressEntity(Guid.NewGuid());
            addressEntity = JsonConvert.DeserializeObject<AddressEntity>(await this.CreateAddress(entity, registration, azureTableStorage, ownerEntity, addressEntity));
            entity = JsonConvert.DeserializeObject<OrganizationEntity>(await this.UpdateOrganization(entity, registration, azureTableStorage, addressEntity, ownerEntity));
            userEntity = JsonConvert.DeserializeObject<UserEntity>(await this.UpdateUser(entity, userEntity, azureTableStorage, addressEntity, ownerEntity));
            CreateUserPrivilege(entity, userEntity, azureTableStorage, addressEntity, ownerEntity);
            return JsonConvert.SerializeObject(entity);
        }

        /// <summary>
        /// Create Organization from registration Model and  use service account User as the owner for Organization
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="registration"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
        private async Task<string> CreateOrganization(OrganizationEntity entity, Registration registration, AzureTableStorage azureTableStorage, UserEntity ownerEntity)
        {
            entity.Organizationname = registration.UserName.Split('@')[1];
            entity.OrganizationURL = null;
            entity.AddressId = Guid.Empty;
            entity.OrganizationFullAddress = registration.AddressLine1 + ", " + registration.AddressLine2 + ", " + registration.AddressLine3 + ", " + registration.City + ", " + registration.State + " - " + registration.Zip + ", " + registration.Country;
            entity.Phone1 = registration.Phone;
            entity.Phone2 = null;
            entity.Phone3 = null;
            entity.EmailAddress1 = registration.Email;
            entity.EmailAddress2 = null;
            entity.EmailAddress3 = null;
            entity.LinkedINURL = null;
            entity.TwitterUrL = null;
            entity.facebookURL = null;
            entity.BlogURL1 = null;
            entity.BlogURL2 = null;
            entity.BlogURL3 = null;
            entity.OwnerId = ownerEntity.UserId;
            entity.OwnerName = ownerEntity.FullName;
            entity.CreatedBy = ownerEntity.UserId;
            entity.CreatedByName = ownerEntity.FullName;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedOnBehalfBy = Guid.Empty;
            entity.CreatedOnBehalfByName = null;
            entity.ModifiedOn = DateTime.Now;
            entity.ModifiedBy = Guid.Empty;
            entity.ModifiedByName = null;
            entity.ModifiedOnBehalfBy = Guid.Empty;
            entity.ModifiedOnBehalfByName = null;
            return JsonConvert.SerializeObject(await azureTableStorage.AddAsync(entity.PartitionKey, entity));

        }

        /// <summary>
        /// Create User under Created Organization and owner from the service account
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="registration"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="ownerEntity"></param>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        private async Task<string> CreateUser(OrganizationEntity entity, Registration registration, AzureTableStorage azureTableStorage, UserEntity ownerEntity, UserEntity userEntity)
        {
            userEntity.UserName = registration.UserName.Split('@')[0];
            userEntity.Password = StringCipher.Encrypt(registration.Password);
            userEntity.FirstName = registration.FirstName;
            userEntity.LastName = registration.LastName;
            userEntity.MiddleName = null;
            userEntity.FullName = registration.LastName + registration.FirstName;
            userEntity.IsPrimary = true;
            userEntity.CustomerAddressId = Guid.Empty;
            userEntity.CustomerFullAddress = registration.AddressLine1 + ", " + registration.AddressLine2 + ", " + registration.AddressLine3 + ", " + registration.City + ", " + registration.State + " - " + registration.Zip + ", " + registration.Country;
            userEntity.Phone1 = registration.Phone;
            userEntity.Phone2 = null;
            userEntity.Phone3 = null;
            userEntity.EmailAddress1 = registration.Email;
            userEntity.EmailAddress2 = null;
            userEntity.EmailAddress3 = null;
            userEntity.LinkedINURL = null;
            userEntity.TwitterUrL = null;
            userEntity.facebookURL = null;
            userEntity.BlogURL1 = null;
            userEntity.BlogURL2 = null;
            userEntity.BlogURL3 = null;
            userEntity.Organization = entity.OraganizationId;
            userEntity.OrganizationName = entity.Organizationname;
            userEntity.OwnerId = ownerEntity.OwnerId;
            userEntity.OwnerName = ownerEntity.OwnerName;
            userEntity.CreatedBy = ownerEntity.OwnerId;
            userEntity.CreatedByName = ownerEntity.OwnerName;
            userEntity.CreatedOn = DateTime.Now;
            userEntity.CreatedOnBehalfBy = Guid.Empty;
            userEntity.CreatedOnBehalfByName = null;
            userEntity.ModifiedOn = DateTime.Now;
            userEntity.ModifiedBy = Guid.Empty;
            userEntity.ModifiedByName = null;
            userEntity.ModifiedOnBehalfBy = Guid.Empty;
            userEntity.ModifiedOnBehalfByName = null;
            return JsonConvert.SerializeObject(await azureTableStorage.AddAsync(userEntity.PartitionKey, userEntity));
        }

        /// <summary>
        /// Create Address from Registration Model
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="registration"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="ownerEntity"></param>
        /// <param name="addressEntity"></param>
        /// <returns></returns>
        private async Task<string> CreateAddress(OrganizationEntity entity, Registration registration, AzureTableStorage azureTableStorage, UserEntity ownerEntity, AddressEntity addressEntity)
        {

            addressEntity.OrganizationId = entity.OraganizationId;
            addressEntity.Organizationname = entity.Organizationname;
            addressEntity.AddressTypeCode = (int)AddressType.User;
            addressEntity.AddressTypeCodeName = AddressType.User.ToString();
            addressEntity.City = registration.City;
            addressEntity.Country = registration.Country;
            addressEntity.County = null;
            addressEntity.CreatedBy = ownerEntity.UserId;
            addressEntity.CreatedByName = ownerEntity.UserName;
            addressEntity.CreatedOn = DateTime.Now;
            addressEntity.CreatedOnBehalfBy = Guid.Empty;
            addressEntity.CreatedOnBehalfByName = null;
            addressEntity.IsPrimary = true;
            addressEntity.CustomerFullAddress = entity.OrganizationFullAddress;
            addressEntity.Fax = null;
            addressEntity.Latitude = null;
            addressEntity.Line1 = registration.AddressLine1;
            addressEntity.Line2 = registration.AddressLine2;
            addressEntity.Line3 = registration.AddressLine3;
            addressEntity.State = registration.State;
            addressEntity.Zip = registration.Zip;
            addressEntity.Longitude = null;
            addressEntity.ModifiedOn = DateTime.Now;
            addressEntity.ModifiedBy = Guid.Empty;
            addressEntity.ModifiedByName = null;
            addressEntity.ModifiedOnBehalfBy = Guid.Empty;
            addressEntity.ModifiedOnBehalfByName = null;
            addressEntity.OwnerId = ownerEntity.UserId;
            addressEntity.OwnerName = ownerEntity.UserName;
            return JsonConvert.SerializeObject(await azureTableStorage.AddAsync(addressEntity.PartitionKey, addressEntity));

        }

        /// <summary>
        /// Update Organization Address from addressid
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="registration"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="addressEntity"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
        private async Task<string> UpdateOrganization(OrganizationEntity entity, Registration registration, AzureTableStorage azureTableStorage, AddressEntity addressEntity, UserEntity ownerEntity)
        {
            entity.AddressId = addressEntity.CustomerAddressId;
            entity.ModifiedOn = DateTime.Now;
            entity.ModifiedBy = ownerEntity.UserId;
            entity.ModifiedByName = ownerEntity.OwnerName;
            return JsonConvert.SerializeObject(await azureTableStorage.AddOrUpdateAsync(entity.PartitionKey, entity));

        }

        /// <summary>
        /// Update User Address from registration Model
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userEntity"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="addressEntity"></param>
        /// <param name="ownerEntity"></param>
        /// <returns></returns>
        private async Task<string> UpdateUser(OrganizationEntity entity, UserEntity userEntity, AzureTableStorage azureTableStorage, AddressEntity addressEntity, UserEntity ownerEntity)
        {
            userEntity.CustomerAddressId = addressEntity.CustomerAddressId;
            userEntity.ModifiedOn = DateTime.Now;
            userEntity.ModifiedBy = ownerEntity.UserId;
            userEntity.ModifiedByName = ownerEntity.OwnerName;
            return JsonConvert.SerializeObject(await azureTableStorage.AddOrUpdateAsync(userEntity.PartitionKey, userEntity));

        }

        /// <summary>
        /// Create Privilege for the newly created User, give full access permissions on all the entities
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userEntity"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="addressEntity"></param>
        /// <param name="ownerEntity"></param>
        private async void CreateUserPrivilege(OrganizationEntity entity, UserEntity userEntity, AzureTableStorage azureTableStorage, AddressEntity addressEntity, UserEntity ownerEntity)
        {
            List<EntityName> entityNames = new List<EntityName>();
            entityNames = this.GetEnumList<EntityName>();
            entityNames.Remove(EntityName.Organization);
            foreach (var eNames in entityNames)
            {
                UserPrivilegeEntity userPrivilegeEntity = new UserPrivilegeEntity(Guid.NewGuid());
                userPrivilegeEntity.EntityName = eNames.ToString();
                userPrivilegeEntity.UserId = userEntity.UserId;
                userPrivilegeEntity.UserName = userEntity.UserName;
                userPrivilegeEntity.CanRead = true;
                userPrivilegeEntity.CanWrite = true;
                userPrivilegeEntity.CanCreate = true;
                userPrivilegeEntity.CanDelete = true;
                userPrivilegeEntity.OwnerId = ownerEntity.UserId;
                userPrivilegeEntity.OwnerName = ownerEntity.UserName;
                userPrivilegeEntity.Organization = entity.OraganizationId;
                userPrivilegeEntity.OrganizationName = entity.Organizationname;
                userPrivilegeEntity.CreatedBy = ownerEntity.UserId;
                userPrivilegeEntity.CreatedByName = ownerEntity.UserName;
                userPrivilegeEntity.CreatedOn = DateTime.Now;
                userPrivilegeEntity.CreatedOnBehalfBy = Guid.Empty;
                userPrivilegeEntity.CreatedOnBehalfByName = null;
                userPrivilegeEntity.ModifiedOn = DateTime.Now;
                userPrivilegeEntity.ModifiedBy = Guid.Empty;
                userPrivilegeEntity.ModifiedByName = null;
                userPrivilegeEntity.ModifiedOnBehalfBy = Guid.Empty;
                userPrivilegeEntity.ModifiedOnBehalfByName = null;
                await azureTableStorage.AddAsync(userPrivilegeEntity.PartitionKey, userPrivilegeEntity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private List<T> GetEnumList<T>()
        {
            T[] array = (T[])Enum.GetValues(typeof(T));
            List<T> list = new List<T>(array);
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <param name="userId"></param>
        /// <param name="organizationId"></param>
        /// <param name="azureTableStorage"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public Task<string> EmailRetrieveRequest(string entityLogicalName, string userId, string organizationId, AzureTableStorage azureTableStorage, string requestBody)
        {
            throw new NotImplementedException();
        }
    }
}