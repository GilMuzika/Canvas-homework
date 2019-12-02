using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas_MyButtons
{
    internal class Point
    {
        private int X = default(int);
        private int Y = default(int);

        internal Point(int x, int y)
        {
            X = x; Y = y;
        }

        internal int GetX()
        {
            return X;
        }
        internal int GetY()
        {
            return Y;
        }
        internal void SetX(int forX)
        {
            if(forX < 0 || forX > MyCanvas.MAX_WIDTH)
            {
                MessageBox.Show($"Sorry, But point location can't be less than O or more than the width of the screen (currently {MyCanvas.MAX_WIDTH})");
                return;
            }
        }
        internal void SetY(int forY)
        {
            if (forY < 0 || forY > MyCanvas.MAX_HEIGHT)
            {
                MessageBox.Show($"Sorry, But point location can't be less than O or more than the height of the screen (currently {MyCanvas.MAX_HEIGHT})");
                return;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }




    }
}
