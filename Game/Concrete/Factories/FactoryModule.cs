using Autofac;

namespace Game.Concrete.Factories
{
	public class FactoryModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<MonsterFactory>();
			builder.RegisterType<HealerFactory>();
			builder.RegisterType<WeaponDealerFactory>();
			builder.RegisterType<ClothesDealerFactory>();
			builder.RegisterType<BotFactory>();
			

		}
	}
}
