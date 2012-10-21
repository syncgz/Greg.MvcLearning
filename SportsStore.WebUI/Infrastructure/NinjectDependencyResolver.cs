
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Ninject;
using Ninject.Syntax;
using SportsStore.Domain.Abstract;

public class NinjectDependencyResolver : IDependencyResolver
{
    private IKernel kernel;

    public NinjectDependencyResolver()
    {
        kernel = new StandardKernel();
        AddBindings();
    }

    // Funkcja implementujaca interface
    public object GetService(Type serviceType)
    {
        return kernel.TryGet(serviceType);
    }

    // Funkcja implementujaca interface
    public IEnumerable<object> GetServices(Type serviceType)
    {
        return kernel.GetAll(serviceType);
    }

    // Funkcja pomocnicza by z zewnatrz mozna bylo dodawac nowe bindingi
    public IBindingToSyntax<T> Bind<T>()
    {
        return kernel.Bind<T>();
    }
    
    // Publiczna instancja resolvera ninjectowego
    public IKernel Kernel
    {
        get { return kernel; }
    }

    // Inicializacja ninjecta odpowiednimi wiazaniami miedzy interfacami a klasami implementujacymi
    private void AddBindings()
    {
        //
        //
        // Funkcja rejestrujaca odpowiednie dependences!!!!!!! E.g.
        //
        //
        //// put additional bindings here 
        //Bind<IProductRepository>().To<EFProductRepository>();

        //// create the email settings object 
        //EmailSettings emailSettings = new EmailSettings
        //{
        //    WriteAsFile = bool.Parse(
        //    ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
        //};
        
        //Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
    }
}