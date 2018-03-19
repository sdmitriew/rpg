using System;
using System.Dynamic;
using System.Security.Cryptography;
using Game.Abstract;
using Game.Concrete.Settings;

namespace Game.Concrete.Personages
{
	internal class Monster : Personage
	{
		private readonly AttackSettings _attackSettings;
		public Monster(AttackSettings settings, IOutput output):base(output)
		{
			_attackSettings = settings;
		}

		public override void Action(Gamer gamer)
		{
			Output.Print("Attack to monster:");
			var rnd = GetRandom();
			if (rnd > gamer.GetImpactForce())
			{
				Output.Print("You are fail.");
				gamer.ActionResult(_attackSettings.Fail);

			}
			else
			{
				Output.Print("You are vin.");
				gamer.ActionResult(_attackSettings.Vin);
			}
		}

		private int GetRandom()
		{
			//Используется RNGCryptoServiceProvider т.к. дает распределение более равномерное
			
			RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
			byte[] data = new byte[8];
			provider.GetBytes(data);
			ulong value = BitConverter.ToUInt64(data, 0);
			return (int)(value % 100+1);
		}
	}
}
