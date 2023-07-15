using System;
namespace Triangles.Validation
{
	public class TriangleValidator
	{
		private bool _valid = true;
		public bool ValidateSides(int sideA, int sideB, int sideC)
		{
			if (sideA < 1 || sideB < 1 || sideC < 1)
			{
				_valid = false;
			} else if ((sideA + sideB <= sideC) || (sideA + sideC <= sideB) || (sideC + sideB <= sideA))
			{
				_valid = false;
			}
			return _valid;
		}
		
	}
}

