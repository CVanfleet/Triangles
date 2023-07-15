using System;
namespace Triangles.Models
{
    public class Triangle
    {
        public int SideA { get; set; }
        public int SideB { get; set; }
        public int SideC { get; set; }

        public int AngleA { get; private set; }
        public int AngleB { get; private set; }
        public int AngleC { get; private set; }

        public string SideClassification { get; private set; }
        public string AngleClassification { get; private set; }

        // Constructor
        public Triangle(int sideA, int sideB, int sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            CalculateAngles();
            FigureAngleClassification();
            FigureSideClassification();
        }

        // Calculates each angle
        private void CalculateAngles()
        {
            double angleCosA = (SideB * SideB + SideC * SideC - SideA * SideA) / (2.0 * SideB * SideC);
            double radianA = Math.Acos(angleCosA);
            double degreeA = radianA * 180.0 / Math.PI;
            AngleA = (int)Math.Round(degreeA);

            double angleCosB = (SideA * SideA + SideC * SideC - SideB * SideB) / (2.0 * SideA * SideC);
            double radianB = Math.Acos(angleCosB);
            double degreeB = radianB * 180.0 / Math.PI;
            AngleB = (int)Math.Round(degreeB);

            double angleCosC = (SideA * SideA + SideB * SideB - SideC * SideC) / (2.0 * SideA * SideB);
            double radianC = Math.Acos(angleCosC);
            double degreeC = radianC * 180.0 / Math.PI;
            AngleC = (int)Math.Round(degreeC);
        }

        // Use logic to figure out what kind of Angle classification this triangle is
        private void FigureAngleClassification()
        {
            if (AngleA > 90 || AngleB > 90 || AngleC > 90)
            {
                AngleClassification = "Obtuse";
            }
            else if (AngleA == 90 || AngleB == 90 || AngleC == 90)
            {
                AngleClassification = "Right";
            }
            else
            {
                AngleClassification = "Acute";
            }
        }

        // Use logic to figure out what kind of Side classification this triangle is
        private void FigureSideClassification()
        {
            // If all sides are equal set to Equilateral, else if two sides are equal set to Isosceles, else set to Scalene
            if (SideA == SideB && SideB == SideC)
            {
                SideClassification = "Equilateral";
            }
            else if (SideA == SideB || SideA == SideC || SideB == SideC)
            {
                SideClassification = "Isosceles";
            }
            else
            {
                SideClassification = "Scalene";
            }
        }
    }
}

