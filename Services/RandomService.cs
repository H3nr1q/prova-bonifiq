using System;

namespace ProvaPub.Services
{
	public class RandomService
	{
		private Random random;
		public RandomService()
		{
			this.random = new Random(Guid.NewGuid().GetHashCode());
		}
		public int GetRandom()
		{
			return random.Next(1,101);
		}

	}
}
