using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            
            mock.Setup(m => m.Products).Returns(new List<Product> 
            { 
                new Product { Name = "aaa", Price = 25,Category = "a", ProductID = 1}, 
                new Product { Name = "bbb", Price = 179,Category = "a", ProductID = 2 }, 
                new Product { Name = "ccc", Price = 95,Category = "a" , ProductID = 3}, 
                new Product { Name = "ddd", Price = 25,Category = "b", ProductID = 4}, 
                new Product { Name = "eee", Price = 179,Category = "b", ProductID = 5 }, 
                new Product { Name = "fff", Price = 95,Category = "b", ProductID = 6 } 
            }.AsQueryable());
            
            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }
    }
}