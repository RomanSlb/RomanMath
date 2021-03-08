using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace RomanMath.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		private static Dictionary<char, int> romanDictionary = new Dictionary<char, int>() { { ' ', 0 }, { '*', 0 }, { '-', 0 }, { '+', 0 }, { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
		public static int Evaluate(string expression)
		{
			try
			{
				if (!String.IsNullOrEmpty(expression))
				{
					int sum = 0;
					List<string> numbers = new List<string>();
					List<string> symbols = new List<string>();
					List<string> arabianExpression = new List<string>();

					for (int i = 0; i < expression.Length; i++)
					{
						if (i + 1 < expression.Length && ((expression[i] == ('+')) || (expression[i] == ('-')) || (expression[i] == ('*'))))
						{
							symbols.Add(expression[i].ToString());
							string sumString = sum.ToString();
							numbers.Add(sumString);
							sum = 0;
						}
                
						else if (i + 1 < expression.Length && romanDictionary[expression[i]] < romanDictionary[expression[i + 1]])
						{
							sum -= romanDictionary[expression[i]];

						}
						else
						{
							sum += romanDictionary[expression[i]];
						}
					}
						
					numbers.Add(sum.ToString());

					string[] arrayNumbers = numbers.ToArray();
					string[] arraySymbols = symbols.ToArray();
					for (int i = 0; i < arrayNumbers.Length; i++)
					{
						if (i != arraySymbols.Length)
						{
							arabianExpression.Add(numbers[i]);
							arabianExpression.Add(symbols[i]);
						}
						else
						{
							arabianExpression.Add(numbers[i]);
						}
					}

					string[] arabianExpressionArray = arabianExpression.ToArray();
					string arabianExpressionString = string.Join("", arabianExpressionArray);

					DataTable dt = new DataTable();
					int romanNumbersResult = Convert.ToInt32(dt.Compute(arabianExpressionString, ""));

					return romanNumbersResult;
				}
                else
                {
					throw new Exception("'expression' argument shouldn't be null or empty");
				}
			}
            catch (Exception ex)
            {
				Console.WriteLine($"{ex.Message}");
				return 0;
			}
		}
	}
}
