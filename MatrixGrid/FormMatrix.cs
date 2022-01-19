using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MatrixGrid
{
    public partial class FormMatrix : Form
    {
        public int m_width;
        public int m_height;
        public int m_rows;
        public int m_columns;
        public int m_Xoffset;
        public int m_Yoffset;
        public int m_counter = 2;
        public int m_size=8;

        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 50;
        public const int DEFAULT_NO_ROWS = 2;
        public const int DEFAULT_NO_COLUMNS = 2;
        public const int DEFAULT__WIDTH = 40;
        public const int DEFAULT_HEIGHT = 40;
        public FormMatrix()
        {
            Intialize();
            InitializeComponent();
            bThreadStatus = false;
        }

        private void OnPaint(object sender, EventArgs e)
        {
            DrawGrid();
        }
        public void Intialize()
        {
            m_rows = DEFAULT_NO_ROWS;
            m_columns = DEFAULT_NO_COLUMNS;
            m_width = DEFAULT__WIDTH;
            m_height = DEFAULT_HEIGHT;
            m_Xoffset = DEFAULT_X_OFFSET;
            m_Yoffset = DEFAULT_Y_OFFSET;
        }
        private void DrawGrid()
        {
            Graphics boardLayout = this.CreateGraphics();
            Pen layoutPen = new Pen(Color.Red);
            layoutPen.Width = 3;

           // boardLayout.DrawLine(layoutPen, 0, 0, 100, 0);
            int X = DEFAULT_X_OFFSET;
            int Y = DEFAULT_Y_OFFSET;

            for (int i=0; i <= m_counter;i++)
            {
                boardLayout.DrawLine(layoutPen, X, Y, X + this.m_width * this.m_counter, Y);
                Y = Y + this.m_height;
            }
             X = DEFAULT_X_OFFSET;
             Y = DEFAULT_Y_OFFSET;

            for (int j = 0; j <= m_counter; j++)
            {
                boardLayout.DrawLine(layoutPen, X, Y, X,Y + this.m_height * this.m_counter);
                X = X + this.m_width;
            }
        }
        public void ThreadCounter()
        {
            try
            {
                while (true)
                {
                    m_counter++;

                    if (m_counter > m_size)
                    {
                        m_counter = 2;
                    }
                    Invalidate();
                    Thread.Sleep(1000);
                }
            }
            catch(Exception ex)
            {

            }

        }

       

        private void start_Click(object sender, EventArgs e)
        {
            MatrixGrid = new Thread(new ThreadStart(ThreadCounter));
            MatrixGrid.Start();
            bThreadStatus = true;

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatrixGrid.Suspend();
        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatrixGrid.Resume();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            m_size = 3;
            this.Refresh();

        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            m_size = 4;
            this.Refresh();

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            m_size = 5;
            this.Refresh();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            m_size = 6;
            this.Refresh();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            m_size = 7;
            this.Refresh();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            m_size = 8;
            this.Refresh();
        }
    }
}
