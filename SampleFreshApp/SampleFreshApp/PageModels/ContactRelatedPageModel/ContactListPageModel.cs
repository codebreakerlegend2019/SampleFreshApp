using FreshMvvm;
using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SampleFreshApp.Interfaces;
using SampleFreshApp.Models;

namespace SampleFreshApp.ViewModels.ContactRelatedPageModel
{
    public class ContactListPageModel:FreshBasePageModel
    {
        private readonly IGetAll<Contact> _igetAllContacts;

        public List<Contact> Contacts { get; set; }
        public ContactListPageModel(IGetAll<Contact> igetAllContacts)
        {
            this._igetAllContacts = igetAllContacts;
        }
        public override void Init(object initData)
        {
            base.Init(initData);
            Contacts = _igetAllContacts.GetAll();
        }

    }
}
