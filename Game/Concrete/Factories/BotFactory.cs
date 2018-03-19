using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Game.Concrete.Personages;

namespace Game.Concrete.Factories
{
	internal class BotFactory : PersonageFactory
	{
		private readonly ILifetimeScope _scope;

		public BotFactory(ILifetimeScope scope)
		{
			_scope = scope;
		}
		internal override Personage GetPersonage()
		{
			return _scope.Resolve<Bot>();
		}
	}
}
