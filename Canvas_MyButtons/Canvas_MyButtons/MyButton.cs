using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas_MyButtons
{
    internal class MyButton: Button
    {
        protected Point TopLeft = default(Point);
        protected Point BottomRight = default(Point);
        private int wWidth = default(int);
        private int hHeight = default(int);

        internal MyButton(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        internal int GetWidth()
        {
            return this.wWidth;
        }
        internal int GetHeight()
        {
            return this.hHeight;
        }
        internal bool SetTopLeft(Point point)
        {
            if (point.GetX() > this.GetBottomRight().GetX()) { MessageBox.Show("The Top Left corner can't be lower than the botton right corner"); return false; /*point.SetX(this.GetBottomRight().GetX());*/ }
            if (point.GetY() > this.GetBottomRight().GetY()) { MessageBox.Show("The Top Left corner can't be more left than the botton right corner"); return false; /*point.SetY(this.GetBottomRight().GetY());*/ }

            this.TopLeft = point;

            this.wWidth =  this.GetBottomRight().GetX() - point.GetX();
            this.hHeight = this.GetBottomRight().GetY() - point.GetY();
            this.Location = new System.Drawing.Point(point.GetX(), point.GetY());
            return true;
        }
        internal bool SetBottomRight(Point point)
        {
            if (point.GetX() < this.GetTopLeft().GetX()) { MessageBox.Show("The Bottom Right corner can't be higher than the top left corner"); return false; /*point.SetX(this.GetTopLeft().GetX());*/ }
            if (point.GetY() < this.GetTopLeft().GetY()) { MessageBox.Show("The Bottom Right corner can't be more right than the top left corner"); return false; /*point.SetX(this.GetTopLeft().GetY());*/ }

            this.BottomRight = point;

            this.wWidth = point.GetX() - this.GetTopLeft().GetX();
            this.hHeight = point.GetY() - this.GetTopLeft().GetY();

            return true;
        }
        internal Point GetTopLeft()
        {
            return this.TopLeft;
        }
        internal Point GetBottomRight()
        {
            return this.BottomRight;
        }
        public override string ToString()
        {
            return base.ToString();
        }



    }
}
