using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Game.Concrete.Factories;
using Game.Concrete.Personages;

namespace Game.Concrete
{
    internal class Game
    {
	    private readonly Dictionary<ConsoleKey, Func<Personage>> _actions;
		private readonly Gamer _gamer;
		public Game(MonsterFactory monsterFactory,
			HealerFactory healerFactory,
			WeaponDealerFactory weaponDealerFactory,
			ClothesDealerFactory clothesDealerFactory,
			BotFactory botFactory,
			Gamer gamer)
		{
			_gamer = gamer;
			_actions = new Dictionary<ConsoleKey, Func<Personage>>
			{
				{ConsoleKey.W, monsterFactory.GetPersonage},
				{ConsoleKey.S, healerFactory.GetPersonage},
				{ConsoleKey.A, weaponDealerFactory.GetPersonage},
				{ConsoleKey.D, clothesDealerFactory.GetPersonage},
				{ConsoleKey.E, botFactory.GetPersonage}


			};
		}
	    public void Start()
	    {
			Console.WriteLine("Press ESC to stop");
		    do
		    {
			    while (!Console.KeyAvailable)
			    {
				    var key = Console.ReadKey(true).Key;
				    if (_actions.ContainsKey(key))
				    {
					    var personage = _actions[key].Invoke();
					    personage.Action(_gamer);
					    continue;
				    }
				    Console.WriteLine("Invalid key!");
			    }
		    } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

		}
	}
}
