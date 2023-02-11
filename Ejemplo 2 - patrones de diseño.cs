// See https://aka.ms/new-console-template for more information

using System;

namespace Proxypatron

{
    class program
    {
        // patron de diseño proxy

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido");

            Iservice concreteService = new ConcreteService();
            Iservice proxy = new proxy (concreteService);

            concreteService.login(15);
            proxy.login(15);

            concreteService.login(20);
            proxy.login(20);

            Console.ReadLine();

        }

        interface Iservice
        {
            void login(int edad);
        }

        class ConcreteService : Iservice
        {
            public void login(int edad)
            {
                Console.WriteLine($"Inicio de sesión satisfactorio. Tu edad es {edad}");
        }

        }

        class proxy : Iservice
        {
            private Iservice _service;

            public proxy(Iservice service)
            {
                _service=service;
            }
            public void login(int edad)
            {
                if (edad<18)
                {
                    Console.WriteLine($"Eres menor de edad");
                }
                else
                {
                    _service.login(edad);   
                }
            }
        }
    }
    
}
