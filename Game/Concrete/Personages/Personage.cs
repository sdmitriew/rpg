using System;
using Game.Abstract;

namespace Game.Concrete.Personages
{
	internal abstract class Personage
	{
		protected IOutput Output;
		protected Personage(IOutput output)
		{
			Output = output;
		}
		public abstract void Action(Gamer gamer);
	}
}
