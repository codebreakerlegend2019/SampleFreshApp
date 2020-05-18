using FreshMvvm;
using FreshMvvm.Popups;
using SampleFreshApp.Helpers;
using SampleFreshApp.Helpers.JdsClientTool;
using SampleFreshApp.Interfaces;
using SampleFreshApp.Models.AuthRelated;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleFreshApp.PageModels.AuthRelatedPageModel
{
    public class LoginPageModel:FreshBasePageModel
    {
        private LoginCredential _loginCredentials = new LoginCredential();

        public string Username
        {
            get => _loginCredentials.Username ?? "";
            set
            {
                _loginCredentials.Username = value;
            }
        }
        public string Password
        {
            get => _loginCredentials.Password ?? "";
            set
            {
                _loginCredentials.Password = value;
            }
        }

        private readonly IPostWithSingleReturn<LoginCredential, JdsSingleResponse<LoginResult>> _postWithSingleReturn;

        public LoginPageModel(IPostWithSingleReturn<LoginCredential,JdsSingleResponse<LoginResult>> postWithSingleReturn)
        {
            this._postWithSingleReturn = postWithSingleReturn;
        }

        [Obsolete]
        public Command GoLogin => new Command(async () =>
        {
           await  UITool.Load(ProcessLogin());
        });

        private async Task ProcessLogin()
        {
            if(InternetTool.IsConnected())
            {

                var request = await _postWithSingleReturn.PostWithSingleReturnAsync(ApiEndpoints.Auth, _loginCredentials);
                if (request.StatusCode == HttpStatusCode.OK)
                    await CoreMethods.DisplayAlert("Login", "You have entered a right Credentials", "Ok");
                else if (request.StatusCode == HttpStatusCode.Unauthorized)
                    await CoreMethods.DisplayAlert("Login Error", "You have entered a Wrong Credentials", "Ok");
                else
                    await CoreMethods.DisplayAlert("Login Error", request.RequestContent, "Ok");
            }
            else
                await CoreMethods.DisplayAlert("Login Error", "Please Check Internet", "Ok");
        }

        public Command GoReset => new Command(() =>
        {
            _loginCredentials.Username = "";
            _loginCredentials.Password = "";
        });



    }
}
