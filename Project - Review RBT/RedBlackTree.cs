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
        private RedBlackNode Minimum(RedBlackNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        private void Transplant(RedBlackNode u, RedBlackNode v)
        {
            if (u.Parent == null)
            {
                Root = v;
            }
            else if (u == u.Parent.Left)
            {
                u.Parent.Left = v;
            }
            else
            {
                u.Parent.Right = v;
            }

            if (v != null) v.Parent = u.Parent;
        } // Thay nút u bằng nút v

        private void FixDelete(RedBlackNode node, RedBlackNode parent)
        {
            while (node != Root && (node == null || !node.IsRed))
            {
                if (node == parent.Left)
                {
                    RedBlackNode sibling = parent.Right;
                    if (sibling.IsRed)
                    {
                        sibling.IsRed = false;
                        parent.IsRed = true;
                        RotateLeft(parent);
                        sibling = parent.Right;
                    }

                    if ((sibling.Left == null || !sibling.Left.IsRed) &&
                        (sibling.Right == null || !sibling.Right.IsRed))
                    {
                        sibling.IsRed = true;
                        node = parent;
                        parent = parent.Parent;
                    }
                    else
                    {
                        if (sibling.Right == null || !sibling.Right.IsRed)
                        {
                            if (sibling.Left != null) sibling.Left.IsRed = false;
                            sibling.IsRed = true;
                            RotateRight(sibling);
                            sibling = parent.Right;
                        }

                        sibling.IsRed = parent.IsRed;
                        parent.IsRed = false;
                        if (sibling.Right != null) sibling.Right.IsRed = false;
                        RotateLeft(parent);
                        node = Root;
                    }
                }
                else
                {
                    RedBlackNode sibling = parent.Left;
                    if (sibling.IsRed)
                    {
                        sibling.IsRed = false;
                        parent.IsRed = true;
                        RotateRight(parent);
                        sibling = parent.Left;
                    }

                    if ((sibling.Left == null || !sibling.Left.IsRed) &&
                        (sibling.Right == null || !sibling.Right.IsRed))
                    {
                        sibling.IsRed = true;
                        node = parent;
                        parent = parent.Parent;
                    }
                    else
                    {
                        if (sibling.Left == null || !sibling.Left.IsRed)
                        {
                            if (sibling.Right != null) sibling.Right.IsRed = false;
                            sibling.IsRed = true;
                            RotateLeft(sibling);
                            sibling = parent.Left;
                        }

                        sibling.IsRed = parent.IsRed;
                        parent.IsRed = false;
                        if (sibling.Left != null) sibling.Left.IsRed = false;
                        RotateRight(parent);
                        node = Root;
                    }
                }
            }

            if (node != null) node.IsRed = false;
        }

        public void Delete(RedBlackNode node, List<string> explanationSteps,System.Windows.Forms.Timer Del)
         { 
            RedBlackNode replacement = node; // Nút thay thế ban đầu là chính nút cần xóa
            RedBlackNode child;
            bool originalColor = replacement.IsRed; // Lưu màu của nút thay thế

            if (node.Left == null) // Trường hợp chỉ có con phải hoặc không có con
            {
                child = node.Right;
                explanationSteps.Add($"Nút cần xóa không có con trái, thay thế bằng con phải hoặc null.");
                
                Transplant(node, node.Right); // Thay thế node bằng con phải
                CalculateNodePositions(Root, 0, 1938, 100, 150);
                Del.Start();
            }
            else if (node.Right == null) // Trường hợp chỉ có con trái
            {
                child = node.Left;
                explanationSteps.Add($"Nút cần xóa không có con phải, thay thế bằng con trái.");
                Transplant(node, node.Left); // Thay thế node bằng con trái
            }
            else // Trường hợp có cả hai con
            {
                explanationSteps.Add($"Nút cần xóa có cả hai con. Tìm nút nhỏ nhất ở cây con phải.");
                replacement = Minimum(node.Right); // Tìm nút nhỏ nhất ở cây con phải
                originalColor = replacement.IsRed; // Lưu màu của nút thay thế
                child = replacement.Right;

                if (replacement.Parent == node) // Nếu replacement là con của node
                {
                    explanationSteps.Add($"Nút thay thế là con trực tiếp của nút cần xóa.");
                    if (child != null) child.Parent = replacement; // Cập nhật cha của child
                }
                else
                {
                    explanationSteps.Add($"Nút thay thế không phải con trực tiếp của nút cần xóa. Thay thế nút nhỏ nhất ở cây con phải.");
                    Transplant(replacement, replacement.Right); // Thay thế replacement
                    replacement.Right = node.Right; // Liên kết lại cây con phải
                    if (replacement.Right != null) replacement.Right.Parent = replacement;
                }

                Transplant(node, replacement); // Thay thế node bằng replacement
                replacement.Left = node.Left; // Liên kết lại cây con trái
                if (replacement.Left != null) replacement.Left.Parent = replacement;
                replacement.IsRed = node.IsRed; // Thừa kế màu của node
                explanationSteps.Add($"Hoàn tất thay thế nút cần xóa bằng nút nhỏ nhất ở cây con phải.");
            }

            if (!originalColor) // Nếu nút bị xóa hoặc thay thế là đen
            {
                explanationSteps.Add($"Nút bị xóa hoặc thay thế là đen. Cần cân bằng lại cây.");
                FixDelete(child, replacement.Parent); // Gọi hàm cân bằng lại cây
            }

            explanationSteps.Add($"Hoàn tất quá trình xóa nút {node.Value}.");
        }

        #endregion
    }
}
