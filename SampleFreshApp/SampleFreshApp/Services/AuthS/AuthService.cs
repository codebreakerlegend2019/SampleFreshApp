using SampleFreshApp.Helpers.JdsClientTool;
using SampleFreshApp.Interfaces;
using SampleFreshApp.Models.AuthRelated;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleFreshApp.Services.AuthS
{
    public class AuthService : IPostWithSingleReturn<LoginCredential, JdsSingleResponse<LoginResult>>
    {
        public async Task<JdsSingleResponse<LoginResult>> PostWithSingleReturnAsync(string apiEndPoint, LoginCredential param)
        {
           return await JdsClient.PostWithSingleReturnAsync<LoginCredential, LoginResult>(apiEndPoint, param);
        }
    }
}
