using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            initialiseCanvas();

            Console.WriteLine(Canvas_MyButtons.MyCanvas.GetCurrentNumberOfButtons());
            Console.WriteLine(Canvas_MyButtons.MyCanvas.GetMaxNumberOfButtons());
            Console.WriteLine(Canvas_MyButtons.MyCanvas.GetTheMaxHeightOfAButton());
            Console.WriteLine(Canvas_MyButtons.MyCanvas.GetTheMaxWidthOfAButton());
            Console.WriteLine(Canvas_MyButtons.MyCanvas.IsPointInsideAButton(5, 10));
            Console.WriteLine(Canvas_MyButtons.MyCanvas.IsPointInsideAButton(25, 100));
            Canvas_MyButtons.MyCanvas.DeleteLastButton();
            Console.WriteLine(Canvas_MyButtons.MyCanvas.GetCurrentNumberOfButtons());
            Canvas_MyButtons.MyCanvas.ClearAllButtons();
            Console.WriteLine(Canvas_MyButtons.MyCanvas.GetCurrentNumberOfButtons());

            Console.ReadKey();
        }

        private static void initialiseCanvas()
        {
            int[,] matrix = new int[(int)Math.Sqrt(Canvas_MyButtons.MyCanvas.MaxButtons), (int)Math.Sqrt(Canvas_MyButtons.MyCanvas.MaxButtons)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Canvas_MyButtons.MyCanvas.CreatenewButton(i, j, i + 15, j + 15);


                }
            }

            


        }
    }
}
