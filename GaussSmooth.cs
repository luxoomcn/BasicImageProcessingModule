using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;

namespace ImageFilters
{
    class GaussSmooth
    {
        public double[] gaussSmooth(double[] inputImage, out double[] outputImage, double sigma)
        {
            double std2 = 2 * sigma * sigma;
            int radius = Convert.ToInt16(Math.Ceiling(3 * sigma));
            int filterWidth = 2 * radius + 1;
            double[] filter = new double[filterWidth];
            outputImage = new double[inputImage.Length];
            int length = Convert.ToInt16(Math.Sqrt(inputImage.Length));
            double[] tempImage = new double[inputImage.Length];

            double sum = 0;
            for (int i = 0; i < filterWidth; i++)
            {
                int xx = (i - radius) * (i - radius);
                filter[i] = Math.Exp(-xx / std2);
                sum += filter[i];
            }
            for (int i = 0; i < filterWidth; i++)
            {
                filter[i] = filter[i] / sum;
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    double temp = 0;
                    for (int k = -radius; k <= radius; k++)
                    {
                        int rem = (Math.Abs(j + k)) % length;
                        temp += inputImage[i * length + rem] * filter[k + radius];
                    }
                    tempImage[i * length + j] = temp;
                }
            }
            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i < length; i++)
                {
                    double temp = 0;
                    for (int k = -radius; k <= radius; k++)
                    {
                        int rem = (Math.Abs(i + k)) % length;
                        temp += tempImage[rem * length + j] * filter[k + radius];
                    }
                    outputImage[i * length + j] = temp;
                }
            }
            return outputImage;
        }
    }
}
