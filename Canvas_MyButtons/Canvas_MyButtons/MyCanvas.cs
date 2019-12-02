using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas_MyButtons
{
    public class MyCanvas
    {
        public const int MAX_WIDTH = 800;
        public const int MAX_HEIGHT = 600;
        private static int buttonIndex = 0;

        public static int MaxButtons { get; private set; } = 25;
        private static MyButton[] buttons = new MyButton[MaxButtons];
        

        public static bool CreatenewButton(int x1, int y1, int x2, int y2)
        {
            if (buttonIndex == MaxButtons)
            {
                //MessageBox.Show("You aren't have any space gor a new button, so it didn't created");
                return false;
            }

            if (!isArrayEmpty(buttons))
            {
                while (buttons[buttonIndex] != null)
                {
                    buttonIndex++;
                }
            }
                MyButton button = new MyButton(new Point(x1, y1), new Point(x2, y2));
            
            buttons[buttonIndex] = button;
            buttonIndex++;

            return true;
            

        }
        public static bool MoveButton(int ButtonNumber, int x, int y)
        {
            if (buttons[ButtonNumber] == null) { MessageBox.Show($"Sorry, but button with an index {ButtonNumber} don't exists."); return false; }

            buttons[ButtonNumber].SetTopLeft(new Point(buttons[ButtonNumber].GetTopLeft().GetX() + x, buttons[ButtonNumber].GetTopLeft().GetY() + y));
            buttons[ButtonNumber].SetBottomRight(new Point(buttons[ButtonNumber].GetBottomRight().GetX() + x, buttons[ButtonNumber].GetBottomRight().GetY() + y));
            return true;
        }
        public static bool DeleteLastButton()
        {
            if (isArrayEmpty(buttons)) return false;
            
            for(int i = buttons.Length - 1; i >= 0; i--)
            {
                if (buttons[i] != null) buttons[i] = null;
                break;
            }
            return true;

        }
        public static void ClearAllButtons()
        {
            for (int i = 0; i < buttons.Length; i++) { if(buttons[i] != null) buttons[i] = null; }
        }
        public static int GetCurrentNumberOfButtons()
        {
            int count = 0;
            foreach(var s in buttons) { if (s != null) count++; }
            return count;
        }
        public static int GetMaxNumberOfButtons()
        {
            return MaxButtons;
        }

        public static int GetTheMaxWidthOfAButton()
        {
            if (isArrayEmpty(buttons)) return 0;

            List<int> widthValues = new List<int>();
            foreach(var s in buttons) widthValues.Add(s.GetBottomRight().GetX() - s.GetTopLeft().GetX());

            return findMaxNum(widthValues.ToArray());
        }
        public static int GetTheMaxHeightOfAButton()
        {
            if (isArrayEmpty(buttons)) return 0;

            List<int> widthValues = new List<int>();
            foreach (var s in buttons) widthValues.Add(s.GetBottomRight().GetY() - s.GetTopLeft().GetY());

            return findMaxNum(widthValues.ToArray());
        }
        public static bool IsPointInsideAButton(int x, int y)
        {
            if (isArrayEmpty(buttons)) { MessageBox.Show("You don't have any buttons"); return false; }

            foreach(var s in buttons)
            {
                bool isXInside = false;
                bool isYInside = false;
                if (x >= s.GetTopLeft().GetX() && x <= s.GetBottomRight().GetX()) isXInside = true;
                if (y >= s.GetTopLeft().GetY() && y <= s.GetBottomRight().GetY()) isYInside = true;

                if (isXInside && isYInside) return true;
            }
            return false;
        }
        public static bool CheckIfAnyButtonsOverlapping()
        {
            if (isArrayEmpty(buttons)) { MessageBox.Show("You don't have any buttons"); return false; }

            bool isOverlap = false;

            foreach(var s in buttons)
            {
                foreach(var ss in buttons)
                {
                    if (!s.Equals(ss))
                    {
                        int s_top = s.GetTopLeft().GetY();
                        int s_bottom = s.GetBottomRight().GetY();
                        int ss_top = ss.GetTopLeft().GetY();
                        int ss_bottom = ss.GetBottomRight().GetY();

                        int s_left = s.GetTopLeft().GetX();
                        int s_right = s.GetBottomRight().GetX();
                        int ss_left = ss.GetTopLeft().GetX();
                        int ss_right = ss.GetBottomRight().GetX();


                        if (s_bottom > ss_top && s_right > ss_left) isOverlap = true;
                        if (s_bottom > ss_top && s_left < ss_right) isOverlap = true;
                        if (s_top > ss_bottom && s_left > ss_right) isOverlap = true;
                        if (s_top > ss_bottom && s_right < ss_left) isOverlap = true;
                    }
                }
            }

            return isOverlap;
        }

        public override string ToString()
        {
            return base.ToString();
        }






        private static bool isArrayEmpty<IList>(IList array)
        {
            bool flag = false;
            foreach (var s in buttons) { if (s != null) flag = true; }
            if (flag) return false;
            else return true;
        }
        private static int findMaxNum(int[] arrayOfNumbers)
        {
            int max = arrayOfNumbers[0];
            int iMax = 0;
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                if (max < arrayOfNumbers[i])
                {
                    max = arrayOfNumbers[i];
                    iMax = i;
                }
            }
            return iMax;
        }






    }
}
