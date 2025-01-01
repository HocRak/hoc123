using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___Review_RBT
{
    internal class HighlightCircle
    {
        public int X { get; set; } 
        public int Y { get; set; } 
        public int Radius { get; set; } = 20; // Bán kính mặc định
        public Pen Pen { get; set; } = new Pen(Color.Blue, 8); // Đường viền mặc định

        public int TargetX {  get; set; }
        public int TargetY { get; set; }
        public HighlightCircle(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw(Graphics g)
        {
            g.DrawEllipse(Pen, X - 20, Y - 20, Radius * 2, Radius * 2);
        }
        public void MoveCircle(int step)
        {
            // Tính khoảng cách giữa vị trí hiện tại và vị trí đích
            int deltaX = TargetX - X;
            int deltaY = TargetY - Y;

            int distance = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));

            if (distance > 0)
            {
                float ratio = step / (float)distance;
                int stepX = (int)(deltaX * ratio);
                int stepY = (int)(deltaY * ratio);

                if (Math.Abs(deltaX) > step || Math.Abs(deltaY) > step)
                {
                    X += stepX;
                    Y += stepY;
                }
                else
                {
                    X = TargetX;
                    Y = TargetY;
                }
            }
        }
    }
}
