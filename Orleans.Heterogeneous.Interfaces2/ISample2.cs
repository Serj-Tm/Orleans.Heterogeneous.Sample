using System;
using System.Threading.Tasks;

namespace Orleans.Heterogeneous.Interfaces
{
    public interface ISample2 : IGrainWithStringKey
    {
        Task<string> Ping(string message);
    }
}
