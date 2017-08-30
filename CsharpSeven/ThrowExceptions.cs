using System;
using NUnit.Framework;

namespace CsharpSeven
{
    [TestFixture]
	public class ThrowExceptions
	{
		[Test]
		public void Works_With_Null_Coalescing_Operator()
		{
			Assert.Throws<Exception>(() =>
			{
				string name = null;
				var theName = name ?? throw new Exception();
			});
		}

		[Test]
		public void Works_With_Conditional_Operator()
		{
			Assert.Throws<Exception>(() =>
			{
				var id = string.Empty;
				var idAsGuid = Guid.TryParse(id, out var p)
					? p : 
					throw new Exception();
			});
		}

		[Test]
		public void Works_With_Expression_Bodies()
		{
			void ThrowIt() => throw new Exception();

			Assert.Throws<Exception>(() =>
			{
				ThrowIt();
			});
		}
	}
}
