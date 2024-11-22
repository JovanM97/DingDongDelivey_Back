using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Database.Repository;

namespace DingDongDelivey_Back.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UserRepository UserRepository { get; set; }
        public ProductRepository ProductRepository { get; set; }
        public OrderRepository OrderRepository { get; set; }
        public ProductOrderRepository ProductOrderRepository { get; set; }

        public UnitOfWork(AppDbContext options)
        {
            _context = options;
            UserRepository = new UserRepository(_context);
            ProductRepository = new ProductRepository(_context);
            OrderRepository = new OrderRepository(_context);
            ProductOrderRepository = new ProductOrderRepository(_context);
        }



        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
