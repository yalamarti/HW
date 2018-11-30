using Hw.BusinessLogic;
using Hw.DataAccess;
using Hw.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Unity;

namespace Hw.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            try
            {
                // Register types with the container
                RegisterTypes(container);

                var startup = container.Resolve<StartUp>();

                // Startup the program
                var task = startup.Run();
                task.Wait();
            }
            catch (AggregateException ae)
            {
                System.Console.WriteLine("==========================Error!==============================");
                foreach (var e in ae.InnerExceptions)
                {
                    System.Console.WriteLine(e.Message);
                }
                System.Console.WriteLine("=================================================================");
                System.Console.WriteLine("");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("==========================Error!==============================");
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("=================================================================");
                System.Console.WriteLine("");
            }

            System.Console.WriteLine("Done. Press any key to exit");
            System.Console.ReadKey();
        }
        

        public static void RegisterTypes(IUnityContainer container)
        {
            const string TargetNameConsole = "console";
            const string TargetNameFile = "file";

            // Initialize app settings / configuration
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string localPath = new Uri(appPath).LocalPath;
            string filePath = Path.Combine(localPath, "appSettings.json");
            container.RegisterInstance<IConfigurationManager>(new ConfigurationManager(filePath));

            // Register named 'output target' instances for later use in a lookup dictionary
            container.RegisterInstance<IRepoTarget>(TargetNameConsole, new ConsoleTarget());
            container.RegisterInstance<IRepoTarget>(TargetNameFile, new FileTarget("Greetings.txt"));

            // Register 'output target' factory
            container.RegisterInstance<IHelloWorldRepoTargetFactory>(
                new HelloWorldRepoTargetFactory(container.Resolve<IConfigurationManager>(), 
                    new Dictionary<string, IRepoTarget>
                    {
                        {  TargetNameConsole,  container.Resolve<IRepoTarget>(TargetNameConsole) },
                        {  TargetNameFile,  container.Resolve<IRepoTarget>(TargetNameFile) }
                    }));
            
            // Register 'repository' type
            container.RegisterType<IHelloWorldRepository, HelloWorldRepository>();

            // Register 'business logic' type
            container.RegisterType<IHelloWorldManager, HelloWorldManager>();

            // Register 'starup' class
            container.RegisterType<StartUp, StartUp>();
        }
    }
}
