using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleFreshApp.Interfaces
{
    public interface  IPostWithSingleReturn<TParam,TResult>
    {
        Task<TResult> PostWithSingleReturnAsync(string apiEndPoint,TParam param);
    }
}
