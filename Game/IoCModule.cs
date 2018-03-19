using Autofac;
using Game.Concrete.Factories;
using Game.Concrete.Personages;

namespace Game
{
	public class IoCModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterModule<FactoryModule>();
			builder.RegisterModule<PersonageModule>();
		}
	}
}
