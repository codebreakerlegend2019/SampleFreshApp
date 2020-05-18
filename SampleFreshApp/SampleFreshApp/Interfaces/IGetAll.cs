using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleFreshApp.Interfaces
{
    public interface IGetAll<T>where T:class
    {
        Task<List<T>> GetAllAsync();
        List<T> GetAll();
    }
}
