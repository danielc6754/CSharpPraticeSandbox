using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
	public class QuickSort
	{
		private List<int> _items;

		public QuickSort()
		{
			_items = new List<int>();
			Random rnd = new Random();

			for (int i = 0; i < 100; i++)
			{
				_items.Add(rnd.Next());
			}
		}

		public void CustomQSort(int left, int right, IList<int> original, IList<int> copy)
		{
			// Forgot this part again. Need to make sure that I remember to break when we see that we are only looking at a single/null item
			if (right - left <= 1)
				return;

			int mid = (left + right) / 2;

			CustomQSort(left, mid, copy, original);
			CustomQSort(mid, right, copy, original);

			// Intializing the leftmost index for our left and right partitions. Used to keep track of where in the two arrays we are looking at
			int l = left, r = mid;
			for (int i = left; i < right; i++)
			{
				// This is a little bit confusing, so let's break it down
				//
				// BREAKDOWN
				// 1. we need to check that left array left idx isn't point beyond the scope of the left array, which is denoted by mid
				// STEP 1 CODEPATH for TRUE
				//		2. Since we know that the left array isn't completed yet. We can continue on. One the first checks we can do is to see if we have completed the searching of the right array
				//				If we know the right array has been completely searched, we can just quickly start inserting the values of the left array
				//
				//		3. If the right array isn't completed, then we need to check which of the two values from the right and left arrays is smaller (weight to the left if they are equal)
				//
				//		NEW CODEPATH for (r >= right || original[l] <= original[r]): TRUE
				//			4. We add the value of at the current search index of the left array and place it into the ordered array
				//			5. We need tin incrememt the current left array search index to the next value location
				//		New CODEPATH for (r >= right || original[l] <= original[r]): FALSE
				//			4. We break out of this if statement and send it to the else statement
				// STEP 1 CODEPATH for FALSE
				//		2. This means that we reached the end of the left array and don't need to look at the left array anymore. Just need to complete the transfer of the data
				//			from the right array
				if (l < mid && (r >= right || original[l] <= original[r]))
				{
					copy[i] = original[l];
					l++;
				}
				else
				{
					copy[i] = original[r];
					r++;
				}
			}
		}

		public void RunQuickSort()
		{

			for (int i = 0; i < _items.Count; i++)
			{
				Console.WriteLine(_items[i]);
			}

			Console.WriteLine("\nSorting list now...");

			// In C#, we always take the reference of a value. So initializing via the method below just creates a reference to _items with the name copy. To explicitly
			// create an actual copy of the List, we need to declare it as a new List(_items) to get a physical copy of the existing List we want.
			// var copy = _items
			var copy = new List<int>(_items);
			CustomQSort(0, 100, _items, copy);


			for (int i = 0; i < _items.Count; i++)
			{
				Console.WriteLine(_items[i]);
			}
		}
	}
}
