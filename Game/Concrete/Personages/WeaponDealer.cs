using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstract;
using Game.Concrete.Settings;

namespace Game.Concrete.Personages
{
    internal class WeaponDealer :Personage
    {
	    public readonly WeaponDealerSettings _settings;

		public WeaponDealer(WeaponDealerSettings settings, IOutput output) : base(output)
		{
			_settings = settings;
		}

	    public override void Action(Gamer gamer)
	    {
			Output.Print("By weapon.");
		    if (gamer.Money >= _settings.Price)
		    {
			    var power = (new Random()).Next(_settings.MinPower, _settings.MaxPower);
				gamer.ActionResult(new ActionChange()
				{
					PowerChange = power,
					MoneyChange = -_settings.Price
				});
				return;
			}
			Output.Print("Invalid balance.");

		}
	}
}
