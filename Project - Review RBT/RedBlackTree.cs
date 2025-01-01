using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Imaging;
using System.Net.WebSockets;
using System.Windows.Forms;

namespace Project___Review_RBT
{
    public class RedBlackTree
    {
        public RedBlackNode Root { get; private set; }

        public RedBlackTree()
        {
            Root = null;
        }

        #region Private Insert Methods

        /// <summary>
        /// Chèn một giá trị mới vào cây.
        /// </summary>
        public void Insert(int value)
        {
            RedBlackNode newNode = new RedBlackNode(value);
            if (Root == null)
            {
               
                Root = newNode;
                Root.IsRed = false; // Gốc luôn là đen
                return;
            }
            InsertNode(Root, newNode);
        }

        /// <summary>
        /// Chèn nút như cây nhị phân tìm kiếm.
        /// </summary>
        public void InsertNode(RedBlackNode current, RedBlackNode newNode)
        {
            RedBlackNode parent = null;
            int value = newNode.Value;
            while (current != null)
            {
                parent = current;
                if (current.Value == newNode.Value)
                {
                    return;
                }
                else if (current.Value < newNode.Value)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }
            if (parent.Value < newNode.Value) 
            { 
                parent.Right = newNode;
            }
            else
            {
                parent.Left= newNode;
            }
            newNode.Parent = parent;
        }

        /// <summary>
        /// Duy trì tính chất đỏ-đen sau khi chèn.
        /// </summary>
        public void FixInsert(ref RedBlackNode node, List<string> explanationSteps, System.Windows.Forms.Timer RBT)
        {
            // Nếu node không hợp lệ hoặc đã chạm gốc, hoặc cha không phải đỏ
            if (node == null || node == Root || !node.Parent.IsRed)
            {
                Root.IsRed = false; // Đảm bảo gốc luôn đen
                explanationSteps.Add("Hoàn tất việc chèn.");
                return;
            }

            // Kiểm tra xem cha có phải con trái của ông nội hay không
            if (node.Parent == node.Parent.Parent.Left)
            {
                var uncle = node.Parent.Parent.Right;

                if (uncle != null && uncle.IsRed) // Case 1: Cha và chú đều đỏ
                {
                    explanationSteps.Add("Case 1: Đổi màu cha, chú và ông nội.");

                    node.Parent.IsRed = false;
                    uncle.IsRed = false;
                    node.Parent.Parent.IsRed = true;
                    node = node.Parent.Parent; // Chuyển lên ông nội để kiểm tra lại

                }
                else
                {
                    if (node == node.Parent.Right) // Case 2: Xoay trái tại cha
                    {
                        explanationSteps.Add("Case 2: Xoay trái tại cha.");

                        node = node.Parent;
                        RotateLeft(node); // Xoay trái tại cha

                    }
                    else // Case 3: Xoay phải tại ông nội   
                    {
                        explanationSteps.Add("Case 3: Đổi màu và xoay phải tại ông nội.");

                        node.Parent.IsRed = false;
                        node.Parent.Parent.IsRed = true;
                        RotateRight(node.Parent.Parent); // Xoay phải tại ông nội
                       
                    }
                }
            }
            else // Nếu cha là con phải của ông nội
            {
                var uncle = node.Parent.Parent.Left;

                if (uncle != null && uncle.IsRed) // Case 1: Cha và chú đều đỏ
                {
                    explanationSteps.Add("Case 1: Đổi màu cha, chú và ông nội.");

                    node.Parent.IsRed = false;
                    uncle.IsRed = false;
                    node.Parent.Parent.IsRed = true;
                    node = node.Parent.Parent; // Chuyển lên ông nội để kiểm tra lại

                   
                }
                else
                {
                    if (node == node.Parent.Left) // Case 2: Xoay phải tại cha
                    {
                        explanationSteps.Add("Case 2: Xoay phải tại cha.");

                        node = node.Parent;
                        RotateRight(node); // Xoay phải tại cha
                        
                    }
                    else
                    {
                        explanationSteps.Add("Case 3: Đổi màu và xoay trái tại ông nội.");
                        node.Parent.IsRed = false;
                        node.Parent.Parent.IsRed = true;
                        RotateLeft(node.Parent.Parent); // Xoay trái tại ông nội
                    }
                }
            }
            CalculateNodePositions(Root, 0, 1778, 50, 150);
            RBT.Start();
        }

        /// <summary>
        /// Quay trái một nút.
        /// </summary>
        private void RotateLeft(RedBlackNode node)
        {
            RedBlackNode temp = node.Right;
            node.Right = temp.Left;

            if (temp.Left != null)
                temp.Left.Parent = node;

            temp.Parent = node.Parent;

            if (node.Parent == null)
                Root = temp;
            else if (node == node.Parent.Left)
                node.Parent.Left = temp;
            else
                node.Parent.Right = temp;

            temp.Left = node;
            node.Parent = temp;
        }

        /// <summary>
        /// Quay phải một nút.
        /// </summary>
        private void RotateRight(RedBlackNode node)
        {
            RedBlackNode temp = node.Left;
            node.Left = temp.Right;

            if (temp.Right != null)
                temp.Right.Parent = node;

            temp.Parent = node.Parent;

            if (node.Parent == null)
                Root = temp;
            else if (node == node.Parent.Right)
                node.Parent.Right = temp;
            else
                node.Parent.Left = temp;

            temp.Right = node;
            node.Parent = temp;
        }
        #endregion

        #region Private Draw Methods
        /// <summary>
        /// Vẽ toàn bộ cây
        /// </summary>
        public void DrawTree(Graphics g)
        {
            if (Root != null)
            {
                DrawNode(g, Root);
            }
        }
        /// <summary>
        /// Vẽ 1 node trong cây
        /// </summary>
        private void DrawNode(Graphics g, RedBlackNode node)
        {
            if (node == null) return;

            // Vẽ đường nối đến nút con
            if (node.Left != null)
            {
                DrawArrow(g, node.X, node.Y, node.Left.X, node.Left.Y);
                DrawNode(g, node.Left);
            }

            if (node.Right != null)
            {
                DrawArrow(g, node.X, node.Y, node.Right.X, node.Right.Y);
                DrawNode(g, node.Right);
            }
            // Vẽ nút
            node.Draw(g);
        }

        private void DrawArrow(Graphics g, int x1, int y1, int x2, int y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            // Kiểm tra tránh chia cho 0
            if (distance == 0) return; // Nếu khoảng cách là 0, không thực hiện gì

            float deltaX = (float)(20 * dx) / distance;
            float deltaY = (float)(20 * dy) / distance;

            // Tạo đầu mũi tên từ nút cha tới nút con
            float arrowX = x2 - deltaX;
            float arrowY = y2 - deltaY;

            // Vẽ mũi tên từ nút cha tới nút con
            using (Pen pen = new Pen(Color.Black, 2))
            {
                pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(6, 6); // Đầu mũi tên
                g.DrawLine(pen, x1, y1, arrowX, arrowY); // Vẽ mũi tên
            }
        }


        /// <summary>
        /// Tính toán các vị trí trong cây để vẽ
        /// </summary>
        public void CalculateNodePositions(RedBlackNode node, int xStart, int xEnd, int yStart, int levelHeight)
        {
            // Nếu nút hiện tại là null, không cần tính toán
            if (node == null)
                return;

            // Tính vị trí X trung tâm cho nút hiện tại
            int centerX = (xStart + xEnd ) / 2;

            // Đặt vị trí của nút
            node.TargetX = centerX;
            node.TargetY = yStart;

            // Tính vị trí của các nút con
            int nextLevelY = yStart + levelHeight; // Vị trí dọc của các nút con

            // Xử lý nút con bên trái
            if (node.Left != null)
            {
                int leftEndX = centerX ; // Giới hạn không gian ngang của nút con trái
                CalculateNodePositions(node.Left, xStart, leftEndX, nextLevelY, levelHeight);
            }

            // Xử lý nút con bên phải
            if (node.Right != null)
            {
                int rightStartX = centerX; // Giới hạn không gian ngang của nút con phải
                CalculateNodePositions(node.Right, rightStartX, xEnd, nextLevelY, levelHeight);
            }
        }
        #endregion

        #region Private Find Methods
        /// <summary>
        /// Lấy đường đi tới node có giá trị value
        /// </summary>
        public List<RedBlackNode> GetPathToNode(int value, List<string> explanationSteps)
        {
            var path = new List<RedBlackNode>();
            var current = Root;

            while (current != null)
            {
                path.Add(current);

                if (value < current.Value)
                {
                    explanationSteps.Add($"{value} < {current.Value}:\nĐi sang cây con trái.");
                    current = current.Left;
                }
                else if (value > current.Value)
                {
                    explanationSteps.Add($"{value} > {current.Value}:\nĐi sang cây con phải.");
                    current = current.Right;
                }
                else
                { 
                    explanationSteps.Add($"{value} = {current.Value}:\nCó nút {value} trong cây");
                    break; // Tìm thấy nút
                }
            }
            
            return path;
        }
        /// <summary>
        /// Tìm node (trả về node hoặc null)
        /// </summary>
        public RedBlackNode FindNode(RedBlackNode Root, int value)
        {
            RedBlackNode current = Root;
            while (current != null)
            {
                if (value == current.Value)
                {
                    return current; // Tìm thấy nút
                }
                else if (value < current.Value)
                {
                    current = current.Left; // Duyệt sang trái
                }
                else
                {
                    current = current.Right; // Duyệt sang phải
                }
            }
            return null; // Không tìm thấy nút
        }
        #endregion

        #region Private Print Methods
        /// <summary>
        /// Duyệt trước
        /// </summary>
        private void TraverseTree(RedBlackNode node, List<RedBlackNode> nodes)
        {
            if (node == null) return;
            TraverseTree(node.Left, nodes);
            nodes.Add(node);
            TraverseTree(node.Right, nodes);
        }
        /// <summary>
        /// Danh sách các node trong cây
        /// </summary>
        public List<RedBlackNode> GetAllNodes()
        {
            List<RedBlackNode> nodes = new List<RedBlackNode>();
            TraverseTree(Root, nodes);
            return nodes;
        }
        #endregion

        #region Private Delete Methods
        /// <summary>
        /// Tìm node lớn nhất bên trái
        /// </summary>
        public RedBlackNode Maximum(RedBlackNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;  // Trả về nút nhỏ nhất
        }

        /// <summary>
        /// Tìm node nhỏ nhất bên phải
        /// </summary>
        public RedBlackNode Minimum(RedBlackNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;  // Trả về nút nhỏ nhất
        }

        /// <summary>
        /// Thay nút u bằng nút v
        /// </summary>
        public void Transplant(RedBlackNode u, RedBlackNode v)
        {
            if (u.Parent == null)  // Nếu u là nút gốc
            {
                Root = v;  // Đặt v làm gốc của cây
            }
            else if (u == u.Parent.Left)  // Nếu u là con trái của cha
            {
                u.Parent.Left = v;  // Thay u bằng v
            }
            else  // Nếu u là con phải của cha
            {
                u.Parent.Right = v;  // Thay u bằng v
            }

            if (v != null)  // Nếu v không phải là null
            {
                v.Parent = u.Parent;  // Cập nhật parent của v
            }
        }

        /// <summary> 
        /// Cân bằng cây sau khi xóa
        /// <summry>
        private void FixDelete(RedBlackNode node, RedBlackNode parent)
        {
            while (node != Root && (node == null || !node.IsRed))
            {
                if (node == parent.Left)
                {
                    RedBlackNode sibling = parent.Right;

                    // Nếu anh/chị em (sibling) của nút bị xóa là đỏ
                    if (sibling != null && sibling.IsRed)
                    {
                        sibling.IsRed = false;
                        parent.IsRed = true;
                        RotateLeft(parent);
                        sibling = parent.Right;
                    }

                    // Nếu anh/chị em của nút bị xóa là đen và cả hai con của nó đều đen
                    if (sibling == null ||
                        ((sibling.Left == null || !sibling.Left.IsRed) && (sibling.Right == null || !sibling.Right.IsRed)))
                    {
                        if (sibling != null) sibling.IsRed = true;
                        node = parent;
                        parent = parent.Parent;
                    }
                    else
                    {
                        // Nếu anh/chị em có con bên phải là đen, ta phải làm việc với nó
                        if (sibling != null && (sibling.Right == null || !sibling.Right.IsRed))
                        {
                            if (sibling.Left != null) sibling.Left.IsRed = false;
                            sibling.IsRed = true;
                            RotateRight(sibling);
                            sibling = parent.Right;
                        }

                        // Bây giờ anh/chị em phải là đỏ
                        if (sibling != null)
                        {
                            sibling.IsRed = parent.IsRed;
                            parent.IsRed = false;
                            if (sibling.Right != null) sibling.Right.IsRed = false;
                            RotateLeft(parent);
                        }
                        node = Root;
                    }
                }
                else
                {
                    RedBlackNode sibling = parent.Left;

                    // Nếu anh/chị em của nút bị xóa là đỏ
                    if (sibling != null && sibling.IsRed)
                    {
                        sibling.IsRed = false;
                        parent.IsRed = true;
                        RotateRight(parent);
                        sibling = parent.Left;
                    }

                    // Nếu anh/chị em của nút bị xóa là đen và cả hai con của nó đều đen
                    if (sibling == null ||
                        ((sibling.Left == null || !sibling.Left.IsRed) && (sibling.Right == null || !sibling.Right.IsRed)))
                    {
                        if (sibling != null) sibling.IsRed = true;
                        node = parent;
                        parent = parent.Parent;
                    }
                    else
                    {
                        // Nếu anh/chị em có con bên trái là đen, ta phải làm việc với nó
                        if (sibling != null && (sibling.Left == null || !sibling.Left.IsRed))
                        {
                            if (sibling.Right != null) sibling.Right.IsRed = false;
                            sibling.IsRed = true;
                            RotateLeft(sibling);
                            sibling = parent.Left;
                        }

                        // Bây giờ anh/chị em phải là đỏ
                        if (sibling != null)
                        {
                            sibling.IsRed = parent.IsRed;
                            parent.IsRed = false;
                            if (sibling.Left != null) sibling.Left.IsRed = false;
                            RotateRight(parent);
                        }
                        node = Root;
                    }
                }
            }

            if (node != null) node.IsRed = false;
        }

        /// <summary> 
        /// Xóa 1 node
        /// <summry>
        public void Delete(RedBlackNode node, List<string> explanationSteps, System.Windows.Forms.Timer Del, System.Windows.Forms.Timer time1)
        {
            RedBlackNode child;
            RedBlackNode replacement = node; // Nút thay thế
            bool originalColor = replacement.IsRed; // Lưu màu của nút thay thế

            // Trường hợp nút cần xóa không có con trái hoặc con phải
            if (node.Left == null)
            {
                child = node.Right;  // Thay thế nút cần xóa bằng con phải
                explanationSteps.Add($"Nút cần xóa không có con trái, thay thế bằng con phải.");
                Transplant(node, node.Right);  // Thay thế node bằng con phải
            }
            else if (node.Right == null)  // Nếu nút cần xóa không có con phải
            {
                child = node.Left;  // Thay thế nút cần xóa bằng con trái
                explanationSteps.Add($"Nút cần xóa không có con phải, thay thế bằng con trái.");
                Transplant(node, node.Left);  // Thay thế node bằng con trái
            }
            else  // Trường hợp nút cần xóa có cả hai con
            {
                explanationSteps.Add($"Nút cần xóa có cả hai con. Tìm nút lớn nhất ở cây con trái.");
                replacement = Maximum(node.Left);  // Tìm nút lớn nhất trong cây con trái
                originalColor = replacement.IsRed;  // Lưu màu của nút thay thế
                child = replacement.Left;  // Con trái của nút thay thế

                // Nếu nút thay thế là con trực tiếp của nút cần xóa
                if (replacement.Parent == node)
                {
                    explanationSteps.Add($"Nút thay thế là con trực tiếp của nút cần xóa.");
                    if (child != null)
                        child.Parent = replacement;  // Cập nhật parent của child
                }
                else
                {
                    explanationSteps.Add($"Nút thay thế không phải con trực tiếp của nút cần xóa.");
                    Transplant(replacement, replacement.Left);  // Thay thế nút lớn nhất với con trái của nó
                    replacement.Left = node.Left;  // Liên kết lại cây con trái
                    if (replacement.Left != null)
                        replacement.Left.Parent = replacement;
                }

                Transplant(node, replacement);  // Thay thế node bằng replacement
                replacement.Right = node.Right;  // Liên kết lại cây con phải
                if (replacement.Right != null)
                    replacement.Right.Parent = replacement;
                replacement.IsRed = node.IsRed;  // Thừa kế màu sắc của node
                explanationSteps.Add($"Hoàn tất thay thế nút cần xóa bằng nút lớn nhất ở cây con trái.");
            }
            FixEntireTree(Root);
            // Nếu màu của nút thay thế là đen, ta cần cân bằng lại cây
            if (!originalColor)
            {
                explanationSteps.Add($"Nút thay thế là đen. Cần cân bằng lại cây.");
                FixDelete(child, replacement.Parent);  // Gọi hàm FixDelete để cân bằng lại cây sau khi xóa
            }
            CalculateNodePositions(Root, 0, 1778, 100, 150);
            time1.Start();
        }

        /// <summary> 
        /// Sửa màu tại node
        /// <summry>
        public void FixDoubleBlackNode(RedBlackNode node)
        {
            if (node == null)
                return;

            // Kiểm tra nếu nút là đen và cả hai con đều đen
            if (node.IsRed == false && node.Left != null && node.Right != null)
            {
                // Nếu cả hai con đều đen
                if (node.Left.IsRed == false && node.Right.IsRed == false)
                {
                    // Thay đổi màu của một trong các con thành đỏ
                    node.Left.IsRed = true; // Chuyển con trái thành đỏ
                    node.Right.IsRed = true; // Chuyển con phải thành đỏ

                    // Nếu nút này là gốc của cây, thì không cần thay đổi thêm
                    if (node.Parent == null)
                    {
                        node.IsRed = false; // Gốc là đen
                    }
                    else
                    {
                        // Nếu nút này không phải là gốc, làm cho nó trở thành đỏ
                        node.IsRed = true;
                    }
                }
            }
        }

        /// <summary>
        /// Sửa màu , không có trường hợp node đen có 2 node đen con
        /// </summary>
        public void FixEntireTree(RedBlackNode node)
        {
            if (node == null)
                return;

            // Duyệt qua toàn bộ cây
            if (node.Left != null)
            {
                FixDoubleBlackNode(node.Left); // Kiểm tra và sửa cây con trái
                FixEntireTree(node.Left);  // Duyệt tiếp vào cây con trái
            }

            if (node.Right != null)
            {
                FixDoubleBlackNode(node.Right); // Kiểm tra và sửa cây con phải
                FixEntireTree(node.Right);  // Duyệt tiếp vào cây con phải
            }

            // Nếu nút hiện tại là nút đen và có cả hai con đen
            if (node.IsRed == false && node.Left != null && node.Right != null)
            {
                if (node.Left.IsRed == false && node.Right.IsRed == false)
                {
                    // Thay đổi màu của một trong các con thành đỏ
                    node.Left.IsRed = true; // Chuyển con trái thành đỏ
                    node.Right.IsRed = true; // Chuyển con phải thành đỏ

                    // Nếu nút này là gốc của cây, thì không cần thay đổi thêm
                    if (node.Parent == null)
                    {
                        node.IsRed = false; // Gốc là đen
                    }
                    else
                    {
                        // Nếu nút này không phải là gốc, làm cho nó trở thành đỏ
                        node.IsRed = true;
                    }
                }
            }
        }

        #endregion
    }
}
