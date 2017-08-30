using System;
using System.Linq;
using NUnit.Framework;


namespace CsharpSeven
{
    [TestFixture]
	public class RefLocalAndRefReturn
	{
		[Test]
		public void Works_For_Value_Type_By_Ref()
		{
			/* Setup */
			ref int GetLargets(ref int first, ref int second)
			{
				if (first > second)
				{
					return ref first;
				}
				return ref second;
			}

			var eleven = 11;
			var thirty = 30;

			/* Test */
			ref var largestNumber = ref GetLargets(ref eleven, ref thirty);

			/* Assert */
			Assert.That(largestNumber, Is.EqualTo(thirty));

			largestNumber++;
			Assert.That(largestNumber, Is.EqualTo(thirty));
		}

		[Test]
		public void Works_For_Class_Members()
		{
			ref int Highest(Numbers numbers)
			{
				if (numbers.First > numbers.Second)
				{
					return ref numbers.First;
				}
				return ref numbers.Second;
			}

			/* Setup */
			var twoByFour = new Numbers
			{
				First = 2,
				Second = 4
			};

			/* Test */
			ref var byRef = ref Highest(twoByFour);
			var byValue = Highest(twoByFour);

			/* Assert */
			Assert.That(byRef, Is.EqualTo(twoByFour.Second));
			Assert.That(byValue, Is.EqualTo(twoByFour.Second));

			byRef++;
			Assert.That(byRef, Is.EqualTo(twoByFour.Second));
			Assert.That(byValue, Is.Not.EqualTo(twoByFour.Second));
		}

		[Test]
		public void Works_For_List_Members_With_Extension_Method()
		{
			/* Setup */
			var numbers = new[] {1, 2, 3, 4, 5, 6, 7};

			/* Test */
			ref var highest = ref numbers.GetHighestValue();

			/* Assert */
			Assert.That(highest, Is.EqualTo(7));

			highest++;
			var highestFromArray = numbers.Max();
			Assert.That(highestFromArray, Is.EqualTo(8));
		}
	}

	internal static class ListOfIntExtensions
	{
		public static ref int GetHighestValue(this int[] numbers)
		{
			if (numbers.Length == 0)
			{
				throw new ArgumentException();
			}
			var highestIndex = 0;
			for (var index = 1; index < numbers.Length; index++)
			{
				if (numbers[highestIndex] < numbers[index])
				{
					highestIndex = index;
				}
			}

			return ref numbers[highestIndex];
		}
	}

	internal class Numbers
	{
		public int First;
		public int Second;
	}
}
