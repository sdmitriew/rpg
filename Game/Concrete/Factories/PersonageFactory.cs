using Game.Concrete.Personages;

namespace Game.Concrete.Factories
{
	internal abstract class PersonageFactory
    {
	    internal abstract Personage GetPersonage();
    }
}
