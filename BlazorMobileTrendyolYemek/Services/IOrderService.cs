using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlazorMobileTrendyolYemek.Models;

namespace BlazorMobileTrendyolYemek.Services
{
    public interface IOrderService
    {
        Task<List<Content>> GetOrders();
        Task<List<Content>> GetOrdersDirectly();
    }
}
