using NUnit.Framework;

namespace CsharpSeven
{
    [TestFixture]
	public class PatternMatching
	{
		[Test]
		public void Works_In_Switch_Cases()
		{
			Geometry geometry = new Square { Width = 5 };

			switch (geometry)
			{
				case Rectangle r:
					Assert.True(false, $"Create square, got rectangle {r.Height} x {r.Width}.");
					break;
				case Square s:
					Assert.That(s.Width, Is.EqualTo(5));
					break;
				default:
					Assert.True(false);
					break;
			}
		}

		[Test]
		public void Works_In_Conditional_Switch_Cases()
		{
			Geometry geometry = new Rectangle
			{
				Width = 5,
				Height = 5
			};

			switch (geometry)
			{
				case Rectangle sq when sq.Width == sq.Height:
					Assert.True(true);
					break;
				default:
					Assert.True(false, "Should match condition above.");
					break;
			}
		}

		[Test]
		public void Works_In_Var_Is_Type()
		{
			Geometry rectangle = new Rectangle {Height = 1, Width = 2};
			if (rectangle is Square square)
			{
				Assert.False(true, $"This should not happen. Rectangle is not square {square.Width}x{square.Width}.");
			}

			if (rectangle is Rectangle r)
			{
				Assert.That(r.Width, Is.EqualTo(2));
				Assert.That(r.Height, Is.EqualTo(1));
			}
		}
	}

	internal class Geometry { }

	internal class Rectangle : Geometry
	{
		public int Width { get; set; }
		public int Height { get; set; }
	}

	class Square : Geometry
	{
		public int Width { get; set; }
	}
}
