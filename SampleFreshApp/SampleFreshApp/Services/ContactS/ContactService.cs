using SampleFreshApp.Interfaces;
using SampleFreshApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleFreshApp.Services.ContactS
{
    public class ContactService : IGetAll<Contact>
    {
        public ContactService()
        {

        }

        private List<Contact> Contacts => new List<Contact>()
        {
            new Contact()
            {
                Id =1,
                FirstName= "Rosechell",
                LastName= "Maling",
                ContactNumber = "09663360773"
            },
            new Contact()
            {
                Id =2,
                FirstName= "Teresita",
                LastName= "Siuagan",
                ContactNumber = "09052410470"
            },
            new Contact()
            {
                Id =3,
                FirstName= "Jose",
                LastName= "Siuagan",
                ContactNumber = "09053448740"
            }
        };
        public List<Contact> GetAll()
        {
            return Contacts;
        }

        public Task<List<Contact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
