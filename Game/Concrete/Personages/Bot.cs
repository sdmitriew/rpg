using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstract;
using Game.Concrete.Factories;
using Game.Concrete.Settings;

namespace Game.Concrete.Personages
{
    internal class Bot : Personage
    {
	    private MonsterFactory _monsterFactory;
	    private HealerFactory _healerFactory;
	    private WeaponDealerFactory _weaponDealerFactory;
	    private ClothesDealerFactory _clothesDealerFactory;
	    private PersonageSettings _settings;

		public Bot(IOutput output, MonsterFactory monsterFactory,
		    HealerFactory healerFactory,
		    WeaponDealerFactory weaponDealerFactory,
		    ClothesDealerFactory clothesDealerFactory, PersonageSettings settings) : base(output)
		{
			_monsterFactory = monsterFactory;
			_healerFactory = healerFactory;
			_weaponDealerFactory = weaponDealerFactory;
			_clothesDealerFactory = clothesDealerFactory;
			_settings = settings;
		}

	    public override void Action(Gamer gamer)
	    {
			Output.Print("Bot action");
		    PersonageFactory factory = null;
			if (gamer.Healts > 70 && gamer.Power<6 && gamer.Money >= _settings.WeaponDealerSettings.Price)
				factory = _weaponDealerFactory;
			else if (gamer.Healts <40 && gamer.Money>_settings.HealerSettings.Price)
				factory = _healerFactory;
			else if (gamer.Healts < 40 && gamer.Money > _settings.ClothesDealerSettings.Price)
				factory = _clothesDealerFactory;
			else
				factory = _monsterFactory;
			factory.GetPersonage().Action(gamer);
		}
    }
}
