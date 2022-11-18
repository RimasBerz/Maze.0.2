using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
namespace Maze
{
    public partial class Form1 : Form
    {
        Labirint l;
        public Form1()
        {
            InitializeComponent();
            Options();
            StartGame();
        }

        public void Options()
        {
            Text = "Maze";

            BackColor = Color.FromArgb(255, 92, 118, 137);

            int sizeX = 40;
            int sizeY = 20;

            Width = sizeX * 16 + 16;
            Height = sizeY * 16 + 40;
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void StartGame() {
            l = new Labirint(this, 40, 20);
            l.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = l.smileX;
            int y = l.smileY;
            l.maze[y, x] = new MazeObject(MazeObject.MazeObjectType.HALL);
            l.images[y, x].BackgroundImage = l.maze[y, x].texture;
            if (e.KeyCode == Keys.Left)
            {
                l.smileX--;
            }
            else if (e.KeyCode == Keys.Right)
            {
                l.smileX++;
            }
            else if (e.KeyCode == Keys.Down)
            {
                l.smileY++;
            }
            else if (e.KeyCode == Keys.Up)
            {
                l.smileY--;
            }
            x = l.smileX;
            y = l.smileY;
            if (y <= 0 || x <= 0 || y >= 19 || x >= 40)
            {
                MessageBox.Show("Its wall!");
                return;
            }
         
            
            l.maze[y, x] = new MazeObject(MazeObject.MazeObjectType.CHAR);
            l.images[y, x].BackgroundImage = l.maze[y, x].texture;
        }
    }
}
