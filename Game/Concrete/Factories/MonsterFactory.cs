using Autofac;
using Game.Concrete.Personages;

namespace Game.Concrete.Factories
{
    internal class MonsterFactory : PersonageFactory
    {
	    private readonly ILifetimeScope _scope;

		public MonsterFactory(ILifetimeScope scope)
		{
			_scope = scope;
		}
	    internal override Personage GetPersonage()
	    {
		    return _scope.Resolve<Monster>();
	    }
    }
}
