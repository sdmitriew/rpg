using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstract;
using Game.Concrete.Settings;

namespace Game.Concrete.Personages
{
	internal class ClothesDealer : Personage
	{
		public readonly ClothesDealerSettings Settings;

		public ClothesDealer(ClothesDealerSettings settings, IOutput output) : base(output)
		{
			Settings = settings;
		}

		public override void Action(Gamer gamer)
		{
			Output.Print("By clothes.");
			if (gamer.Money >= Settings.Price)
			{
				var power = (new Random()).Next(Settings.MinHealth, Settings.MaxHealth);
				gamer.ActionResult(new ActionChange()
				{
					PowerChange = power,
					MoneyChange = -Settings.Price
				});
				return;
			}
			Output.Print("Invalid balance.");

		}
	}
}
