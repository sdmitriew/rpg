using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Game.Abstract;
using Game.Concrete.Settings;

namespace Game.Concrete.Personages
{
    internal class Healer : Personage
    {
	    private readonly HealerSettings _healerSettings;
	    public Healer(HealerSettings settings, IOutput output):base(output)
	    {
		    _healerSettings = settings;
	    }
		

	    public override void Action(Gamer gamer)
	    {
			Output.Print("Go to healer");
		    if (gamer.Money >= _healerSettings.Price)
		    {
			    var health = (new Random()).Next(_healerSettings.MinHealth, _healerSettings.MaxHealth);
				gamer.ActionResult(new ActionChange()
				{
					MoneyChange = -_healerSettings.Price,
					HealthChange = (gamer.Healts+health)>100? 100-gamer.Healts:health
				});
		    }
		    else
			    Output.Print("Invalid balance.");
		}
	}
}
