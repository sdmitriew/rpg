using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Concrete.Settings
{
    internal class PersonageSettings
    {
		public AttackSettings AttackSettings { get; set; }
	    public HealerSettings HealerSettings { get; set; }
	    public WeaponDealerSettings WeaponDealerSettings { get; set; }
	    public ClothesDealerSettings ClothesDealerSettings { get; set; }
	}
}
