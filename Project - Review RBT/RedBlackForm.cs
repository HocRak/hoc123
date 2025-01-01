using System.Drawing;
using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Emit;
using System.Transactions;

namespace Project___Review_RBT
{
    public partial class RedBlackForm : Form
    {
        private RedBlackTree tree = new RedBlackTree();
        private int step => trackBar_speedanimation.Value; // Tốc độ di chuyển


        private List<RedBlackNode> pathToNode; // Đường đi tìm kiếm
        private int animationIndex; // Chỉ số của nút hiện tại trong đường đi

        private HighlightCircle FindCircle;
        private RedBlackNode insertnode;
        private RedBlackNode deletenode;
        private RedBlackNode fixedNode;

        private List<string> explanationSteps; // Danh sách các bước giải thích
        private int currentExplanationIndex; // Chỉ số bước hiện tại
        private enum TimerAction
        {
            Find,
            Insert,
            Delete
        }
        private TimerAction currentAction;

        public RedBlackForm()
        {
            InitializeComponent();
            tree = new RedBlackTree();
            // Bật Double Buffering để mượt hơn
            panel_main.GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(panel_main, true, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Điều chỉnh kích thước Panel
            panel_main.Width = Width;
            panel_main.Height = Height - panel_header.Height - panel_function.Height;

        }

        #region Chức năng thêm nút
        /// <summary>
        /// Kích hoạt sự kiện thêm nút
        /// </summary>
        private void button_insert_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_insert.Text, out int value))
            {

                insertnode = new RedBlackNode(value);

                explanationSteps = new List<string>();
                currentExplanationIndex = 0;

                pathToNode = tree.GetPathToNode(value, explanationSteps);
                ToggleControls(false);

                if (pathToNode != null && pathToNode.Count > 0)
                {
                    currentAction = TimerAction.Insert;
                    animationIndex = 0;

                    var startNode = pathToNode[0];
                    FindCircle = new HighlightCircle(startNode.X, startNode.Y);

                    PathToNode_Timer.Start();
                }
                else
                {
                    Label_Explanation.Text = $"Cây rỗng. Chèn {value} làm gốc.";
                    PerformInsert(insertnode);
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập một số nguyên hợp lệ.");
            }
        }

        /// <summary>
        /// Gọi hàm thể hiện việc insert
        /// </summary>
        private void PerformInsert(RedBlackNode insertnode)
        {
            tree.Insert(insertnode.Value); // Chèn nút vào cây với giải thích
            tree.CalculateNodePositions(tree.Root, 0, panel_main.Width, 50, 150); // Tính toán vị trí các nút
            Insert_BST_Timer.Start(); // Bắt đầu hoạt ảnh chèn
        }

        /// <summary>
        /// Gọi timer thể hiện việc chèn
        /// </summary>
        private void Insert_BST_Timer_Tick(object sender, EventArgs e)
        {
            bool allNodesStable = true;

            foreach (var node in tree.GetAllNodes())
            {
                node.MoveTowardsTarget(step);
                if (node.X != node.TargetX || node.Y != node.TargetY)
                {
                    allNodesStable = false;
                }
                panel_main.Invalidate();
            }

            if (allNodesStable)
            {
                Insert_BST_Timer.Stop();
                PerformFixInsert(insertnode); // Thực hiện sửa lỗi sau khi chèn
            }
        }

        /// <summary>
        /// Gọi hàm thể hiện việc sửa cây sau khi chèn
        /// </summary>
        private void PerformFixInsert(RedBlackNode insertnode)
        {
            explanationSteps = new List<string>(); // Khởi tạo danh sách các bước giải thích
            currentExplanationIndex = 0;

            fixedNode = tree.FindNode(tree.Root, insertnode.Value);

            if (fixedNode != null)
            {
                tree.FixInsert(ref fixedNode, explanationSteps, Insert_RBT_Timer); // Ghi lại các bước
                Label_Explanation.Text = explanationSteps[explanationSteps.Count - 1];
                ToggleControls(true);
            }
            else
            {
                ToggleControls(true);
            }
        }

        /// <summary>
        /// Gọi timer thể hiện việc sửa cây sau khi chèn
        /// </summary>
        private void Insert_RBT_Timer_Tick(object sender, EventArgs e)
        {


            bool allNodesStable = true;
            // Gọi phương thức MoveTowardsTarget cho tất cả các nút
            foreach (var node in tree.GetAllNodes())
            {
                node.MoveTowardsTarget(step);
                // Kiểm tra nếu nút vẫn chưa ổn định
                if (node.X != node.TargetX || node.Y != node.TargetY)
                {
                    allNodesStable = false;
                }
                // Vẽ lại panel
                panel_main.Invalidate();
            }
            // Nếu tất cả các nút đã ổn định, dừng timer
            if (allNodesStable)
            {
                Insert_RBT_Timer.Stop();
                tree.FixInsert(ref fixedNode, explanationSteps, Insert_RBT_Timer);
                Label_Explanation.Text = explanationSteps[explanationSteps.Count - 1];
            }
        }
        /// <summary>
        /// Hàm hiện kết quả của việc chèn một nút vào cây đỏ đen
        /// </summary>
        private bool Result_Insert()
        {
            var currentNode = pathToNode[animationIndex - 1];
            int value = int.Parse(textBox_insert.Text);

            if (value > currentNode.Value)
            {
                Label_Explanation.Text = $"Cây con phải là null.\n Chèn vào cây con phải";
                return true;
            }
            else if (value < currentNode.Value)
            {
                Label_Explanation.Text = $"Cây con trái là null.\n Chèn vào cây con trái";
                return true;
            }
            else
            {
                Label_Explanation.Text = $"Giá trị {insertnode.Value} đã tồn tại trong cây ! \nKhông thể chèn";
            }
            return false;
        }

        #endregion

        #region Chức năng tìm nút
        /// <summary>
        /// Kích hoạt sự kiện nút tìm
        /// </summary>
        private void button_find_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_find.Text, out int value))
            {
                explanationSteps = new List<string>();
                currentExplanationIndex = 0;
                pathToNode = tree.GetPathToNode(value, explanationSteps);

                if (pathToNode != null && pathToNode.Count > 0)
                {
                    ToggleControls(false);
                    currentAction = TimerAction.Find;

                    animationIndex = 0;
                    var startNode = pathToNode[0];

                    FindCircle = new HighlightCircle(startNode.X, startNode.Y);
                    panel_main.Invalidate(); // Vẽ lại giao diện

                    PathToNode_Timer.Start();
                }
                else
                {
                    MessageBox.Show($"Không tồn tại nút: {value}");
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập một số nguyên hợp lệ.");
            }
        }

        /// <summary>
        /// Hàm thể hiện kết quả tìm kiếm
        /// </summary>
        private void Result_Find()
        {
            var currentNode = pathToNode[animationIndex - 1];
            int value = int.Parse(textBox_find.Text);
            if (value == currentNode.Value)
            {
                Label_Explanation.Text = $"Kết quả :\n Tìm thấy nút {value}";
            }
            else
                Label_Explanation.Text = $"Kết quả :\n Không tìm thấy nút {value}";
            ToggleControls(true);
        }
        #endregion

        #region Chức năng xóa nút

        /// <summary>
        /// Kích hoạt sự kiện xóa 1 nút
        /// </summary>
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_delete.Text, out int value))
            {
                deletenode = new RedBlackNode(value);

                explanationSteps = new List<string>(); // Đặt lại danh sách các bước giải thích
                currentExplanationIndex = 0;

                pathToNode = tree.GetPathToNode(value, explanationSteps);
                ToggleControls(false);

                if (pathToNode != null && pathToNode.Count > 0)
                {
                    currentAction = TimerAction.Delete;
                    animationIndex = 0;

                    var startNode = pathToNode[0];
                    FindCircle = new HighlightCircle(startNode.X, startNode.Y);

                    PathToNode_Timer.Start();
                }
                else
                {
                    Label_Explanation.Text = $"Cây rỗng. Không thể xóa";
                }

            }
            else
            {
                MessageBox.Show("Hãy nhập một số nguyên hợp lệ.");
            }
        }

        private void PerformDelete()
        {
            tree.Delete(deletenode, explanationSteps, Delete_Node_Timer);
        }
        /// <summary>
        /// Hàm thể hiện kết quả xóa 1 nút
        /// </summary>
        private bool Result_Delete()
        {
            var currentNode = pathToNode[animationIndex - 1];
            int value = int.Parse(textBox_delete.Text);
            if (value != currentNode.Value)
            {
                Label_Explanation.Text = $"Không tồn tại nút {value}, không thể xóa";
                return false;
            }
            return true;
        }

        private void Delete_Node_Timer_Tick(object sender, EventArgs e)
        {
            Label_Explanation.Text = explanationSteps[explanationSteps.Count - 1];
            bool allNodesStable = true;
            // Gọi phương thức MoveTowardsTarget cho tất cả các nút
            foreach (var node in tree.GetAllNodes())
            {
                node.MoveTowardsTarget(step);
                // Kiểm tra nếu nút vẫn chưa ổn định
                if (node.X != node.TargetX || node.Y != node.TargetY)
                {
                    allNodesStable = false;
                }
                // Vẽ lại panel
                panel_main.Invalidate();
            }
            if (allNodesStable)
            {
                Delete_Node_Timer.Stop();
            }
        }
        #endregion

        #region Các hàm hỗ trợ chung
        /// <summary>
        /// Tắt bật enable các nút , textbox
        /// </summary>
        private void ToggleControls(bool enable)
        {
            // Cập nhật khả năng click cho tất cả các control
            foreach (var control in panel_function.Controls.Cast<Control>().ToList())
            {
                if (control is Button || control is TextBox) // Chỉ xử lý Button và Label
                {
                    control.Enabled = enable;
                }
            }
        }

        /// <summary>
        /// Gọi timer thể hiện đường dẫn đến node cuối cùng
        /// </summary>
        private void PathToNode_Timer_Tick(object sender, EventArgs e)
        {
            if (animationIndex < pathToNode.Count)
            {
                var currentNode = pathToNode[animationIndex];
                // Cập nhật vị trí vòng tròn
                FindCircle.TargetX = currentNode.X;
                FindCircle.TargetY = currentNode.Y;

                FindCircle.MoveCircle(step);

                if (FindCircle.X == currentNode.X && FindCircle.Y == currentNode.Y)
                {
                    Label_Explanation.Text = explanationSteps[currentExplanationIndex];
                    currentExplanationIndex++;
                    animationIndex++;
                    PathToNode_Timer.Stop();
                    Delay_PathToNode.Start();
                }
                panel_main.Invalidate(); // Vẽ lại giao diện              
            }
            else
            {

                PathToNode_Timer.Stop();

                FindCircle = null;
                panel_main.Invalidate();

                switch (currentAction)
                {
                    case TimerAction.Find:
                        Result_Find();
                        break;
                    case TimerAction.Insert:
                        if (Result_Insert()) PerformInsert(insertnode);
                        else
                        {
                            ToggleControls(true);
                        }
                        break;
                    case TimerAction.Delete:
                        if (Result_Delete())
                            PerformDelete();
                        else
                        {
                            ToggleControls(true);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Kích hoạt Timer Delay PathToNode_Timer -> delay 1s
        /// </summary>
        private void Delay_PathToNode_Tick(object sender, EventArgs e)
        {
            Delay_PathToNode.Stop();
            PathToNode_Timer.Start();
        }

        /// <summary>
        /// Vẽ vòng tròn kèm theo các node
        /// </summary>
        private void panel_main_Paint(object sender, PaintEventArgs e)
        {
            FindCircle?.Draw(e.Graphics);
            tree.DrawTree(e.Graphics);
        }
        #endregion

        #region Các chức năng khác

        /// <summary>
        /// Gọi hàm pause , cho hoạt ảnh dừng 5s
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
        }

        #endregion

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
