using System.Drawing;
using System;
using System.Xml.Linq;
public class RedBlackNode
{
    public int Value { get; set; } // Giá trị của nút
    public RedBlackNode Left { get; set; } // Con trái
    public RedBlackNode Right { get; set; } // Con phải
    public RedBlackNode Parent { get; set; } // Nút cha
    public bool IsRed { get; set; } = true; // Trạng thái màu sắc (Đỏ/Đen)

    // Thuộc tính cho giao diện đồ họa
    public int X { get; set; }
    public int Y { get; set; } = 100;
    public int TargetX { get; set; }
    public int TargetY { get; set; }

    public RedBlackNode(int value)
    {
        Value = value;
    }

    public void Draw(Graphics g)
    {
        Color fillColor = IsRed ? Color.Red : Color.Black;
        // Vẽ hình elip làm nút
        g.FillEllipse(new SolidBrush(fillColor), X - 20, Y - 20, 40, 40);
        g.DrawEllipse(Pens.White, X - 20, Y - 20, 40,40);
        string displayValue = Value.ToString();

        // Bắt đầu với font kích thước lớn nhất có thể
        Font font = new Font("Times New Roman", 10, FontStyle.Regular);
        SizeF textSize = g.MeasureString(displayValue, font);

        // Giảm kích thước font đến khi chuỗi vừa trong hình elip
        while ((textSize.Width > 36 || textSize.Height > 36) && font.Size > 1)
        {
            font = new Font(font.FontFamily, font.Size - 0.5f, font.Style);
            textSize = g.MeasureString(displayValue, font);
        }

        // Tính toán vị trí để chuỗi nằm chính giữa nút
        float textX = X - textSize.Width / 2;
        float textY = Y - textSize.Height / 2;

        // Vẽ chuỗi vào hình elip
        g.DrawString(displayValue, font, Brushes.White, textX, textY);
    }

    public void MoveTowardsTarget(int step)
    {
        int deltaX = TargetX - X;
        int deltaY = TargetY - Y;

        int distance = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));

        // Tính toán bước di chuyển dựa trên `step`
        int stepX = (int)(step * (deltaX / (float)distance));
        int stepY = (int)(step * (deltaY / (float)distance));

        // Cập nhật vị trí nút từng bước
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