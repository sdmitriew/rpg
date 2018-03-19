using System;
using System.Collections.Generic;
using System.Text;
using Game.Abstract;

namespace Game.Concrete
{
    internal class Output : IOutput
    {
	    public void Print(string value)
	    {
		    Console.WriteLine(value);
	    }
    }
}
