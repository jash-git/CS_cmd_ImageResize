using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
/*
Create Image or Bitmap in console application - can't seem to find System.Drawing?
https://stackoverflow.com/questions/13784559/create-image-or-bitmap-in-console-application-cant-seem-to-find-system-drawin
    You have to add Reference to the system.Drawing.Dll in your project.

    Right click on Project, add reference and find System.Drawing.DLL and add reference.

    EDIT: You will find it under Assemblies->Framework->System.Drawing
*/
namespace CS_cmd_ImageResize
{
    class Program
    {
        static void pause()
        {
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        static bool ImageResize(String strImageSrcPath, String strImageDesPath, int intWidth = 0, int intHeight = 0)
        {
            bool blnAns = true;
            Image objImage = Image.FromFile(strImageSrcPath);
            if (intWidth > objImage.Width)
            {
                intWidth = objImage.Width;
            }
            if (intHeight > objImage.Height)
            {
                intHeight = objImage.Height;
            }
            if ((intWidth == 0) && (intHeight == 0))
            {
                intWidth = objImage.Width;
                intHeight = objImage.Height;
            }
            else if ((intHeight == 0) && (intWidth != 0))
            {
                intHeight = (int)(objImage.Height * intWidth / objImage.Width);
            }
            else if ((intWidth == 0) && (intHeight != 0))
            {
                intWidth = (int)(objImage.Width * intHeight / objImage.Height);
            }
            Bitmap imgOutput = new Bitmap(objImage, intWidth, intHeight);
            imgOutput.Save(strImageDesPath, objImage.RawFormat);
            objImage.Dispose();
            objImage = null;
            imgOutput.Dispose();
            imgOutput = null;
            return blnAns;
        }
        static void Main(string[] args)
        {
            /*
            //測試用
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            pause();
            */
            if(args.Length>2)
            {
                String StrSrcPath, StrDesPath;
                int intMax;
                try
                {
                    StrSrcPath = args[0];
                    StrDesPath = args[1];
                    intMax = Convert.ToInt32(args[2]);
                    ImageResize(StrSrcPath, StrDesPath, intMax, 0);

                }
                catch
                {
                    Console.WriteLine("Parameter error");
                    pause();
                }
            }
            else
            {
                Console.WriteLine("Parameter error");
                pause();
            }
        }
    }
}
