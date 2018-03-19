using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Game.Concrete.Personages;

namespace Game.Concrete.Factories
{
	internal class HealerFactory : PersonageFactory
	{
		private readonly ILifetimeScope _scope;

		public HealerFactory(ILifetimeScope scope)
		{
			_scope = scope;
		}
		internal override Personage GetPersonage()
		{
			return _scope.Resolve<Healer>();
		}
	}
}
