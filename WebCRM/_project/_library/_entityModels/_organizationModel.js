class OrganizationModel {
    constructor(partitionKey, rowKey, orgId, orgName, orgUrl, orgfullAddress, phone1, phone2, phone3, email1, email2, email3,
        linkedinUrl, twitter, facebook, blogurl1, blogurl2, blogurl3,ownerId, ownerName, createdBy, createdByName, createdOn, createdOnBehalfBy,
        createdOnBehalfByName, modifiedOn, modifiedBy,modifiedByName, modifiedOnBehalfBy, modifiedOnBehalfByName) {
        this.PartitionKey = partitionKey;
        this.RowKey = rowKey;
        this.OraganizationId = orgId;
        this.Organizationname = orgName;
        this.OrganizationURL = orgUrl;
        this.OrganizationFullAddress = orgfullAddress;
        this.Phone1 = phone1;
        this.Phone2 = phone2;
        this.Phone3 = phone3;
        this.EmailAddress1 = email1;
        this.EmailAddress2 = email2;
        this.EmailAddress3 = email3;
        this.LinkedINURL = linkedinUrl;
        this.TwitterUrL = twitter;
        this.facebookURL = facebook;
        this.BlogURL1 = blogurl1;
        this.BlogURL2 = blogurl2;
        this.BlogURL3 = blogurl3;
        this.OwnerId = ownerId;
        this.OwnerName = ownerName;
        this.CreatedBy = createdBy;
        this.CreatedByName = createdByName;
        this.CreatedOn = createdOn;
        this.CreatedOnBehalfBy = createdOnBehalfBy;
        this.CreatedOnBehalfByName = createdOnBehalfByName;
        this.ModifiedOn = modifiedOn;
        this.ModifiedBy = modifiedBy;
        this.ModifiedByName = modifiedByName;
        this.ModifiedOnBehalfBy = modifiedOnBehalfBy;
        this.ModifiedOnBehalfByName = modifiedOnBehalfByName;
    }

}