using System;
using System.Collections.Generic;
using System.Text;
using Autofac;


namespace Game.Concrete.Personages
{
	public class PersonageModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Monster>();
			builder.RegisterType<ClothesDealer>();
			builder.RegisterType<WeaponDealer>();
			builder.RegisterType<Healer>();
			builder.RegisterType<Bot>();
		}
	}
}
