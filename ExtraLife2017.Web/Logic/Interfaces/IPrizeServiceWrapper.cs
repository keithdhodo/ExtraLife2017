using System.Collections.Generic;
using System.Threading.Tasks;
using ExtraLife2017.Web.Models;

// ReSharper disable once CheckNamespace
namespace ExtraLife2017.Web.Logic
{
    public interface IPrizeServiceWrapper
    {
        Task<IEnumerable<Prize>> GetPrizes();
    }
}