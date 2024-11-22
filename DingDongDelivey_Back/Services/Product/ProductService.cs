using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Database.Interface;
using DingDongDelivey_Back.Models;
using DingDongDelivey_Back.Services.Account;

namespace DingDongDelivey_Back.Services.Product
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;
        private AppSettings appSettings;
        TokenService tokenService;
        ValidateService validateService;

        public ProductService(AppSettings appSettings, IUnitOfWork unitOfWork)
        {
            //this.manager = manager;
            this.appSettings = appSettings;
            tokenService = new TokenService();
            this.unitOfWork = unitOfWork;
            validateService = new ValidateService();
        }

        public async Task<string> AddProduct(Models.Product p)
        {
            Models.Product product = new Models.Product();

            if (checkIfProductExists(p.name) == 1)
            {
                return "Name";
            }

            product.name = p.name;
            product.price = p.price;
            product.quantity = p.quantity;
            product.ingredients = p.ingredients;
            product.isDeleted = false;
            //product.orders = new Order[0];

            unitOfWork.ProductRepository.Add(product);

            return "Success";
        }

        public async Task<Models.Product[]> GetAllProducts()
        {
            var AllProducts = unitOfWork.ProductRepository.GetAll();

            Models.Product[] products = AllProducts.Cast<Models.Product>().ToArray();

            return products;
        }

        private int checkIfProductExists(string name)
        {
            var AllUser = unitOfWork.ProductRepository.GetAll();
            foreach (var temp in AllUser)
            {
                if (temp.name == name)
                    return 1;
            }
            return 0;
        }
    }
}
