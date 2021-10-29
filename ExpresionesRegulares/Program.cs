using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpresionesRegulares
{
	class Program
	{
		static void Main(string[] args)
		{
			string frase = "Mi web es: https://www.instagram.com/vintagenewlifeclothing/";

			string patron = @"http(s)?://(www.)?instagram.com";

			Regex regex = new Regex(patron);

			MatchCollection mc = regex.Matches(frase);

			if (mc.Count > 0)
				Console.WriteLine("Se ha encontrado");
			else
				Console.WriteLine("No Se ha encontrado");
		}
	}
}
