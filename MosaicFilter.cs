using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;

namespace AForge.Imaging.Filters
{
    /// <summary>
    /// 马赛克
    /// 是把一张图片分割成若干个N * N像素的小区块（可能在边缘有零星的小块，但不影响整体算法）
    /// ，每个小区块的颜色都是相同的。
    /// </summary>
    public class MosaicFilter 
    {

        public Bitmap ProcessBitmap(Bitmap bmp,int var)
        {
            if (bmp.Equals(null))
            {
                return null;
            }  
            int width = bmp.Width;
            int height = bmp.Height;
            int N = var;//效果粒度，值越大码越严重
            int r = 0, g = 0, b = 0;
            Color c;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    if (y % N == 0)
                    {
                        if (x % N == 0)//整数倍时，取像素赋值
                        {
                            c = bmp.GetPixel(x, y);
                            r = c.R;
                            g = c.G;
                            b = c.B;
                        }
                        else
                        {
                            bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                        }
                    }
                    else //复制上一行
                    {
                        Color colorPreLine = bmp.GetPixel(x, y - 1);
                        bmp.SetPixel(x, y, colorPreLine);

                    }
                }
            }
            return bmp;
        }

        // public Bitmap ProcessBitmap(Bitmap bmp,int var)
       /* public unsafe Bitmap UnsafeProcessBitmap(Bitmap bmp,int var)
         {
             if (bmp.Equals(null))
             {
               return null;
             }  
             int width = bmp.Width;
             int height = bmp.Height;
             int N = var;//效果粒度，值越大码越严重
             int r = 0, g = 0, b = 0;
             Rectangle rect = new Rectangle(0, 0, width, height);
             System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, 
                 System.Drawing.Imaging.PixelFormat.Format32bppArgb);
             byte* ptr = (byte*)(bmpData.Scan0);
             for (int y = 0; y < height; y++)
             {
                 for (int x = 0; x < width; x++)
                 {
                     if (y % N == 0)
                     {
                         if (x % N == 0)
                         {
                             r = ptr[2];
                             g = ptr[1];
                             b = ptr[0];
                         }
                         else
                         {
                             ptr[2] = (byte)r;
                             ptr[1] = (byte)g;
                             ptr[0] = (byte)b;
                         }
                     }
                     else //复制上一行
                     {
                         ptr[0] = ptr[0 - bmpData.Stride];//b;
                         ptr[1] = ptr[1 - bmpData.Stride];//g;
                         ptr[2] = ptr[2 - bmpData.Stride];//r
                     }
                     ptr += 4;
                 }
                 ptr += bmpData.Stride - width * 4;
             }
             bmp.UnlockBits(bmpData);
             return bmp;
         }*/
    }
}
