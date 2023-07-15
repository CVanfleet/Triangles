using SkiaSharp;

namespace Triangles.Services
{
	public class TriangleDrawer
	{
        public void DrawTriangle(double sideA, double sideB, double sideC, double angleA, double angleB, double angleC)
        {
            // Get max side and calculate scale factor
            double maxSide = Math.Max(sideA, Math.Max(sideB, sideC));

            double scaleFactor = 400 / maxSide;

            // Scale the sides
            double scaledSideA = sideA * scaleFactor;
            double scaledSideB = sideB * scaleFactor;
            double scaledSideC = sideC * scaleFactor;

            // Convert angles to radians
            double angleARad = angleA * Math.PI / 180.0;
            double angleBRad = angleB * Math.PI / 180.0;
            double angleCRad = angleC * Math.PI / 180.0;

            // Calculate the coordinates of the triangle vertices
            var pointA = new SKPoint((float)((500 - scaledSideC) /2), 100);
            var pointB = new SKPoint((float)scaledSideC + (float)(500 - scaledSideC) /2, 100);
            var pointC = new SKPoint(
                (float)(scaledSideB * Math.Cos(angleARad)) + (float)(500 - scaledSideC) / 2,
                (float)(scaledSideB * Math.Sin(angleARad))+100
            );

            using (var bitmap = new SKBitmap(500, 500))
            using (var canvas = new SKCanvas(bitmap))
            using (var paint = new SKPaint())
            {
                // Set the canvas background color
                canvas.Clear(SKColors.White);

                // Create a path and add the triangle vertices
                var path = new SKPath();
                path.MoveTo(pointA);
                path.LineTo(pointB);
                path.LineTo(pointC);
                path.Close();

                // Draw the triangle
                paint.Color = SKColors.DarkBlue;
                canvas.DrawPath(path, paint);

                // Save the bitmap as an image file
                using (var image = SKImage.FromBitmap(bitmap))
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = System.IO.File.OpenWrite("wwwroot/img/triangle.png"))
                {
                    data.SaveTo(stream);
                }
            }
        }
        }
    }


