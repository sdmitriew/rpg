using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Game.Abstract;
using Game.Concrete;
using Game.Concrete.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Game
{
	class Program
    {
        static void Main(string[] args)
        {
	        var builder = new ConfigurationBuilder()
		        .SetBasePath(Directory.GetCurrentDirectory())
		        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

	        IConfigurationRoot configuration = builder.Build();
			var services = new ServiceCollection().AddLogging(); 

			var containerBuilder = new ContainerBuilder();
	        containerBuilder.Populate(services);
	        RegisterTypes(containerBuilder);
			InitialConfig(configuration, containerBuilder);
			containerBuilder.RegisterModule<IoCModule>();
			var container = containerBuilder.Build();
	        var serviceProvider = new AutofacServiceProvider(container);
			var game = container.Resolve<Concrete.Game>();
	        game.Start();
		}

	    static void RegisterTypes(ContainerBuilder containerBuilder)
	    {
			containerBuilder.RegisterType<Concrete.Game>();
		    containerBuilder.RegisterType<Gamer>().OnActivated(x=>x.Instance.Initial());
		    containerBuilder.RegisterType<Output>().As<IOutput>();
		}

	    static void InitialConfig(IConfigurationRoot configuration, ContainerBuilder containerBuilder)
	    {
			var gamerSettings = new GamerSettings();
		    configuration.GetSection("GamerSettings").Bind(gamerSettings);
		    containerBuilder.Register(x => gamerSettings);

			var settings = new PersonageSettings();
		    configuration.GetSection("PersonageSettings").Bind(settings);
		    containerBuilder.Register(x => settings.AttackSettings);

		    if (settings.HealerSettings.MaxHealth > settings.HealerSettings.MinHealth
				|| settings.HealerSettings.MaxHealth > 100)
		    {
			    settings.HealerSettings.MaxHealth = 10;
			    settings.HealerSettings.MinHealth = 1;
		    }
		    containerBuilder.Register(x => settings.HealerSettings);

		    if (settings.ClothesDealerSettings.MaxHealth > settings.ClothesDealerSettings.MinHealth
		        || settings.ClothesDealerSettings.MaxHealth > 100)
		    {
			    settings.ClothesDealerSettings.MaxHealth = 2;
			    settings.ClothesDealerSettings.MinHealth = 1;
		    }
			containerBuilder.Register(x => settings.ClothesDealerSettings);

		    if (settings.WeaponDealerSettings.MaxPower > settings.WeaponDealerSettings.MinPower)
		    {
			    settings.WeaponDealerSettings.MaxPower = 2;
			    settings.WeaponDealerSettings.MinPower = 1;
		    }
			containerBuilder.Register(x => settings.WeaponDealerSettings);

		    containerBuilder.Register(x => settings);

		}
	}
}
