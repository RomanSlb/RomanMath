using System;
using RomanMath.Impl;

namespace RomanMath.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in RomanMath.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			var result = Service.Evaluate("IV + IV - XV + C *  III");// IV + II - XV + C *  III");//("XV+IV+IX-M*XVIII+X"); //("IV+II/V");
			System.Console.WriteLine(result);
			System.Console.ReadKey();
		}
	}
}
