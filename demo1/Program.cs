using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            CrmConnection con = new CrmConnection("CRM");

            IOrganizationService service = new OrganizationService(con);

            //var response = service.Execute(new WhoAmIRequest());

            Entity account = new Entity("account");

            account["name"] = "rishi";

            account["numberofemployees"] = 12345;

            account["accountcategorycode"] = new OptionSetValue(1);

            account["creditlimit"] = new Money((decimal)500000);

            var contact = new Entity("contact") { Id = Guid.NewGuid() };

            account["primarycontactid"] = new EntityReference(contact.LogicalName, contact.Id);

            account["primarycontactid"] = contact.ToEntityReference();

            string name = account["name"].ToString();

            if (account.Contains("name"))
            { }
            name = account.GetAttributeValue<string>("name");

            var notfoundstring = account.GetAttributeValue<string>("notfound");

            var notfoundoptionset = account.GetAttributeValue<OptionSetValue>("notfound");



        }
    }
}
