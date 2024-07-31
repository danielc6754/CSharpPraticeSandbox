using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
	/* 
	 * OBJECTIVE
	 * 
	 * Binary is the number system all digital computers are based on.
	 * Therefore it's important for developers to understand binary, or base 2, mathematics. 
	 * The purpose of Bin2Dec is to provide practice and understanding of how binary calculations.
	 * 
	 * Bin2Dec allows the user to enter strings of up to 8 binary digits, 0's and 1's, 
	 * in any sequence and then displays its decimal equivalent.
	 * 
	 * This challenge requires that the developer implementing it follow these constraints:
	 * - Arrays may not be used to contain the binary digits entered by the user
	 * - Determining the decimal equivalent of a particular binary digit in the sequence must be calculated using a single
	 *   mathematical function, for example the natural logarithm. It's up to you to figure out which function to use.
	 * 
	 * User Stories
	 * 1. User can enter up to 8 binary digits in one input field - Completed
	 * 2. User must be notified if anything other than a 0 or 1 was entered - Completed
	 * 3. User views the results in a single output field containing the decimal (base 10) equivalent of the binary number that
	 *    was entered - Completed
	 *    
	 * 1Up
	 * 1. User can enter a variable number of binary digits - Completed
	 * 
	 * BRAINSTORM
	 * 
	 * We are trying to convert a binary string value into it's equivalent decimal value, we can do a string length check to quickly filter out
	 * inputs > 8
	 * 
	 * looks like thankfully we are constrained to a binary length of 8 digits, that means the max value is
	 * 2^8 == 127 and a min value of 0
	 * 
	 * We need to let users know when a none 0/1 is being entered - we can technically do this during the conversion process and return a -1
	 * value as a error code
	 * 
	 * Nothing in the requirements specifies whether the value can be unsigned/signed -> going to assume for now that it's only unsigned return value
	 * 
	 * Important constraints design-wise: NO arrays, calcuate using a single mathematical function
	 * 
	 * 
	 * DESIGNING THE FUNCTION
	 * 
	 * Off the top of my head, we can just use a 
	 * 
	 */
	public class Bin2Dec
	{
		public int ConvertBin2Dec(string binary)
		{
			int binLen = binary.Length;

			if (binLen == 0 || binLen > 8)
				return -1;

			int res = 0;

			for (int i = 0; i < binLen; i++)
			{
				if (binary[i] == '0' || binary[i] == '1')
					res = 2 * res + (binary[i] - '0');
				else
					return -2;
			}

			return res;
		}

		public void Interaction()
		{
			while (true)
			{
				Console.WriteLine("Please Enter in a binary value");

				string input = Console.ReadLine().TrimEnd();
				int convertVal = ConvertBin2Dec(input);

				if (convertVal == -1)
					Console.WriteLine("Invalid input length!");
				else if (convertVal == -2)
					Console.WriteLine("Detected invalid character, please only use 0s and 1s");
				else
				{
					Console.WriteLine("Orignal Binary Value: " + input);
					Console.WriteLine("Converted Decimal Value: " + convertVal);
				}

				Console.WriteLine("Input 0 to exit" + Environment.NewLine);
				string loop = Console.ReadLine();

				if (loop == "0")
					break;
			}
		}
	}
}
