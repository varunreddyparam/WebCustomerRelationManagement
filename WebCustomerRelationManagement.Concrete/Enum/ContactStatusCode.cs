using WebCustomerRelationManagement.Models.Enums;

namespace WebCustomerRelationManagement.Concrete.Enum
{
    public sealed class ContactStatusCode : CustomEnum<ContactStatusCode, int>
    {
        public static readonly ContactStatusCode Element1 = new ContactStatusCode("Element1", 1, "foo");
        public static readonly ContactStatusCode Element2 = new ContactStatusCode("Element2", 2, "bar");

        private ContactStatusCode(string name, int id, string additionalText)
            : base(name, id)
        {
            AdditionalText = additionalText;
        }

        public string AdditionalText { get; private set; }
    }
}

