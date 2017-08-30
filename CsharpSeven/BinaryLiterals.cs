using System;
using NUnit.Framework;

namespace CsharpSeven
{
    [TestFixture]
    public class BinaryLiterals
	{
		[Theory]
		[TestCase(0b001, 1)]
		[TestCase(0b010, 2)]
		[TestCase(0b011, 3)]
		[TestCase(0b100, 4)]
		[TestCase(0b101, 5)]
		[TestCase(0b110, 6)]
		[TestCase(0b111, 7)]
		public void Should_Declare_Int(int binLitteral, int normal)
		{
			Assert.That(binLitteral, Is.EqualTo(normal));
		}

		[Theory]
		[TestCase(0b1, 1)]
		[TestCase(0b01, 1)]
		[TestCase(0b001, 1)]
		[TestCase(0b0001, 1)]
		[TestCase(0b00001, 1)]
		[TestCase(0b000001, 1)]
		[TestCase(0b0000001, 1)]
		[TestCase(0b00000001, 1)]
		public void Should_Not_Care_About_Higher_Bits_Zeroes(int binLitteral, int expected)
		{
		    Assert.That(binLitteral, Is.EqualTo(expected));
		}

		public void Should_Work_As_Enum_Value()
		{
			const DaysOfWeek day = DaysOfWeek.Friday;
			Assert.True(DaysOfWeek.Weekdays.HasFlag(day));
			Assert.False(DaysOfWeek.Weekends.HasFlag(day));
		}
	}

	[Flags]
	public enum DaysOfWeek
	{
		Monday = 0b00000001,
		Tuesday = 0b00000010,
		Wednesday = 0b00000100,
		Thursday = 0b00001000,
		Friday = 0b00010000,
		Saturday = 0b00100000,
		Sunday = 0b01000000,

		Weekdays = Monday | Tuesday | Wednesday | Thursday | Friday,
		Weekends = Saturday | Sunday
	}
}
