using System;
using System.Threading.Tasks;

namespace Orleans.Heterogeneous.Interfaces
{
    public interface ISample1 : IGrainWithStringKey
    {
        Task<string> Ping(string message);
    }
}
