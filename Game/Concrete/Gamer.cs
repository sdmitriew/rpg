using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstract;
using Game.Concrete.Settings;

namespace Game.Concrete
{
    internal class Gamer
    {
		public int Healts { get; private set; }
	    public double Power { get; private set; }
	    public int Money { get; private set; }
	    private readonly GamerSettings _gamerSettings;
	    private readonly IOutput _output;

	    public Gamer(GamerSettings settings, IOutput output)
	    {
		    _gamerSettings = settings;
		    _output = output;
	    }

	    public void Initial()
	    {
			Healts = _gamerSettings.MaxHealth;
		    Power = _gamerSettings.DefaultPower;
		    Money = _gamerSettings.Money;
		}

	    public double GetImpactForce()
	    {
		    var power = 40 + Power * 5;
		    return power <= _gamerSettings.MaxPower ? power : _gamerSettings.MaxPower;
	    }


		public void ActionResult(ActionChange result)
		{
			Healts += result.HealthChange;
			Power += result.PowerChange;
			Money += result.MoneyChange;
			_output.Print(ToString());
			if (Healts <= 0)
			{
				_output.Print("Game over.");
				_output.Print("Initial new game.");
				Initial();
			}
		}

	    public override string ToString()
	    {
		    return $"Healts: {Healts}, Power: {Power}, Money: {Money} ";
	    }
    }
}
