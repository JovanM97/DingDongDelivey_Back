using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Repository;

namespace DingDongDelivey_Back.Database.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        UserRepository UserRepository { get; }
        ProductRepository ProductRepository { get; }
        OrderRepository OrderRepository { get; }
        ProductOrderRepository ProductOrderRepository { get; }


        int Complete();
    }
}
