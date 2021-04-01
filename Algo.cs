using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Computer_graphics
{

    public partial class Algo : Form
    {
        int x1, x2, y1, y2;
        Bitmap pp;
        int dir = 1, dir2 = -1;
        int right = 0 , buttom = 0;


        public void DDA_fun(int x1, int x2, int y1, int y2, Bitmap pp)
        {

            int dx = x1 - x2;
            int dy = y1 - y2;
            float steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
            float inc_x = dx / steps;
            float inc_y = dy / steps;
            float x = x1, y = y1;

            for (int i = 0; i < steps; i++)
            {
                pp.SetPixel((int)(Math.Round(x)), (int)(Math.Round(y)), Color.BlueViolet);
                x += inc_x;
                y += inc_y;

            }
            pictureBox1.Image = pp;
        }

        public void Circle_fun(int xc, int yc, int r, Bitmap pp)
        {
            int x = 0;
            int y = r;
            int p = 1 - r;

            while (x < r)
            {
                //pp.SetPixel(x, y, Color.DarkBlue);
                x += 1;
                if (p < 0)
                    p += (2 * x + 1);

                else
                {
                    y -= 1;
                    p += (2 * (x - y) + 1);
                }
                pp.SetPixel(xc + x, yc + y, Color.BlueViolet);
                pp.SetPixel(xc - x, yc - y, Color.BlueViolet);
                pp.SetPixel(xc + x, yc - y, Color.BlueViolet);
                pp.SetPixel(xc - x, yc + y, Color.BlueViolet);

                pp.SetPixel(xc + y, yc + x, Color.BlueViolet);
                pp.SetPixel(xc - y, yc - x, Color.BlueViolet);
                pp.SetPixel(xc + y, yc - x, Color.BlueViolet);
                pp.SetPixel(xc - y, yc + x, Color.BlueViolet);

            }
            pictureBox1.Image = pp;
        }

        public void bres_fun(int x1, int x2, int y1, int y2, Bitmap pp)
        {
            int dx = Math.Abs(x1 - x2);
            int dy = Math.Abs(y1 - y2);
            int x, xend, y;

            int p = 2 * dy - dx;
            int d2 = 2 * dy, dw2 = 2 * (dy - dx);

            if (x1 > x2)
            {
                x = x2; xend = x1; y = y2;
            }

            else
            {
                x = x1; xend = x2; y = y1;
            }

            while (x < xend)
            {
                pp.SetPixel(x, y, Color.DarkBlue);
                x += 1;

                if (p < 0)
                    p += d2;

                else
                {
                    y += 1;
                    p += dw2;
                }

            }
            pictureBox1.Image = pp;
        }


        void elipse_dda(int xc, int yc, int rx, int ry, Bitmap pp)
        {

            int x = 0, y;

            double p0 = 0.0, d0 = 0.0;

            y = ry;
            p0 = ry * ry - rx * rx * ry + 0.25 * rx * rx;


            //region 1

            while (2 * ry * ry * x < 2 * rx * rx * y)
            {

                pp.SetPixel(xc + x, yc + y, Color.BlueViolet);
                pp.SetPixel(xc - x, yc + y, Color.BlueViolet);
                pp.SetPixel(xc - x, yc - y, Color.BlueViolet);
                pp.SetPixel(xc + x, yc - y, Color.BlueViolet);

                x++;

                if (p0 < 0)
                {
                    p0 += 2 * ry * ry * x + ry * ry;

                }
                else
                {
                    y--;
                    p0 += 2 * ry * ry * x + ry * ry - 2 * rx * rx * y;
                }


            }

            //region 2

            d0 = ry * ry * (x + 0.5) * (x + 0.5) + rx * rx * (y - 1) * (y - 1) - ry * ry * rx * rx;
            while (y > 0)
            {

                y--;
                if (d0 < 0)
                {
                    x++;
                    d0 += 2 * ry * ry * x - 2 * rx * rx * y + rx * rx;
                }
                else
                {
                    d0 += -2 * rx * rx * y + rx * rx;
                }
                pp.SetPixel(xc + x, yc + y, Color.BlueViolet);
                pp.SetPixel(xc - x, yc + y, Color.BlueViolet);
                pp.SetPixel(xc - x, yc - y, Color.BlueViolet);
                pp.SetPixel(xc + x, yc - y, Color.BlueViolet);


            }

            pictureBox1.Image = pp;

        }


        public void ellipse_fun(Bitmap bp, int xc, int yc, int rx, int ry)
        {
            // regoin 1
            double pp = (ry * ry) - (rx * rx * ry) + (.25 * (rx * rx));
            int p1 = (int)pp;
            int x = 0, y = ry;
            while ((2 * rx * rx * y) > (2 * ry * ry * x))
            {
                bp.SetPixel(xc + x, yc + y, Color.BlueViolet);
                bp.SetPixel(xc - x, yc + y, Color.BlueViolet);
                bp.SetPixel(xc - x, yc - y, Color.BlueViolet);
                bp.SetPixel(xc + x, yc - y, Color.BlueViolet);

                x++;

                if (p1 < 0)
                    p1 += (2 * ry * ry * x) + (ry * ry);
                else
                {
                    y--;
                    p1 += (2 * ry * ry * x) - (2 * rx * rx * y) + (ry * ry);
                }
            }

            // regoin 2
            pp = ((ry * ry) * (x + 0.5) * (x + 0.5)) + ((rx * rx) * (y - 1) * (y - 1)) - (rx * rx * ry * ry);
            int p2 = (int)pp;
            while (y >= 0)
            {


                y--;
                if (p2 > 0)
                    p2 -= (2 * rx * rx * y) + (rx * rx);
                else
                {
                    x++;
                    p2 += (2 * ry * ry * x) - (2 * rx * rx * y) + (rx * rx);
                }
                bp.SetPixel(xc + x, yc + y, Color.BlueViolet);
                bp.SetPixel(xc - x, yc + y, Color.BlueViolet);
                bp.SetPixel(xc - x, yc - y, Color.BlueViolet);
                bp.SetPixel(xc + x, yc - y, Color.BlueViolet);
            }
            pictureBox1.Image = bp;
        }


        public void rotat(double ceta) {

            double[,] rotate = { { Math.Cos(ceta), Math.Sin(ceta) * dir, 0 },
                             { Math.Sin(ceta) * dir2, Math.Cos(ceta), 0 },
                             { 0, 0, 1 } };

            double[,] p1_zer0 = tras_to_zero((x1 + x2) / 2, (y1 + y2) / 2);

            double newddx1 = x1 + p1_zer0[0, 2];
            double newddx2 = x2 + p1_zer0[0, 2];
            double newddy1 = y1 + p1_zer0[1, 2];
            double newddy2 = y2 + p1_zer0[1, 2];

            double[,] come_back = tras_to_zero((x1 + x2) / -2, (y1 + y2) / -2);

            double[,] test = matrix33_X_matrix33(come_back, rotate);
            double[,] res = matrix33_X_matrix33(test, p1_zer0);

            double[] point_1_before = { x1, y1, 1 };
            double[] point_2_before = { x2, y2, 1 };

            double[] point_1_after_rotate = matrix33_X_matrix31(res, point_1_before);
            double[] point_2_after_rotate = matrix33_X_matrix31(res, point_2_before);

            x1 = (int)point_1_after_rotate[0];
            y1 = (int)point_1_after_rotate[1];
            x2 = (int)point_2_after_rotate[0];
            y2 = (int)point_2_after_rotate[1];
        }


        double[,] tras_to_zero(double x, double y)
        {
            double[,] trans = { { 1, 0, -1 * x }, { 0, 1, -1 * y }, { 0, 0, 1 } };
            return trans;
        }


        double[,] matrix33_X_matrix33(double[,] v1, double[,] v2)
        {
            double[,] res = new double[3, 3];

            for (int i = 0; i < 9; i++) {
                for (int col = 0; col < 3; col++)
                    res[i / 3, i % 3] += v1[i / 3, col] * v2[col, i % 3];
            }

            return res;
        }


        double[] matrix33_X_matrix31(double[,] v1, double[] v2)
        {
            double[] res = new double[3];
            for (int i = 0; i < 9; i++)
                res[i / 3] += v1[i / 3, i % 3] * v2[i % 3];

            return res;
        }


        public Algo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){  }

        private void Run_Click(object sender, EventArgs e)
        {
            x1 = int.Parse(XAT.Text);
            x2 = int.Parse(xbt.Text);
            y1 = int.Parse(YAT.Text);

            right = pictureBox1.Width;
            buttom = pictureBox1.Height;
            
        
            if (circle.Checked)
                y2 = 0;
            else
                y2 = int.Parse(ybt.Text);

            pictureBox1.Visible = true;
            pp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            try
            {
                if (DDA.Checked)
                    DDA_fun(x1, x2, y1, y2, pp);

                if (bres.Checked)
                    bres_fun(x1, x2, y1, y2, pp);

                if (Elipse.Checked)
                {
                    XA.Text = "RX";
                    XB.Text = "XC";
                    YA.Text = "RY";
                    YB.Text = "YC";


                    ellipse_fun(pp,x2, y2, x1, y1 );

                    // elipse_dda(x1, y1, x2, y2, pp);
                }

                if (circle.Checked)
                {
                    XA.Text = "X";
                    YA.Text = "Y";
                    XB.Text = "Radius";
                    YB.Visible = false;
                    Circle_fun(x1, y1, x2, pp);
                }
            }

            catch (Exception ) { MessageBox.Show("please inter correct data"); }


        }


        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;

            // clear text in X1 ,X2 ,Y1 ,Y2 textbox
            XAT.Clear();
            xbt.Clear();
            YAT.Clear();
            ybt.Clear();
            tx.Clear();
            ty.Clear();
            angle.Clear();
            YB.Visible = true;

            // clear drawing in pictuerbox
            pictureBox1.Image = null;
            pictureBox1.Invalidate();

            // to clear ckecked box
            if (DDA.Checked)
                DDA.Checked = false;

            if (bres.Checked)
                bres.Checked = false;

            if (Elipse.Checked)
                Elipse.Checked = false;

            if (circle.Checked)
                circle.Checked = false;
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mn = new MainForm();
            mn.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e) { pictureBox1.Visible = false; }

        private void bres_CheckedChanged(object sender, EventArgs e) { }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e) { }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e) { }

        // Tranformation
        private void bunifuTileButton2_Click_1(object sender, EventArgs e)
        {

            // clear drawing in pictuerbox
            /* 
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
            */

            Bitmap pp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            right = pictureBox1.Width;
            buttom = pictureBox1.Height;
            
      
            try {

                if (translation.Checked)
                {
                    int tx_ = int.Parse(tx.Text);
                    int ty_ = int.Parse(ty.Text);
                    x1 += tx_;
                    x2 += tx_;
                    y1 += ty_;
                    y2 += ty_;

                    if (DDA.Checked)
                    {
                        
                        DDA_fun(x1, x2, y1, y2, pp);
                    }

                    if (bres.Checked)
                    {
                        
                        bres_fun(x1, x2, y1, y2, pp);
                    }

                    if (Elipse.Checked)
                    {
                        
                        elipse_dda(x2, y2, x1, y1, pp);
                    }

                    if (circle.Checked)
                    {
                        
                        Circle_fun(x1, y1, x2, pp);
                    }
                }

                // Scaling
                if (scale.Checked)
                {
                    int tx_ = int.Parse(tx.Text);
                    int ty_ = int.Parse(ty.Text);

                    float sx = tx_;
                    float sy = ty_;
                    if (sx <= 0) sx = 1;
                    if (sy <= 0) sy = 1;

                    if (DDA.Checked)
                    {
                        x1 = (int)(x1 * sx);
                        x2 = (int)(x2 * sx);
                        y1 = (int)(y1 * sy);
                        y2 = (int)(y2 * sy);
                        DDA_fun(x1, y1, x2, y2, pp);

                    }
                    if (bres.Checked) {

                        x1 = (int)(x1 * sx);
                        x2 = (int)(x2 * sx);
                        y1 = (int)(y1 * sy);
                        y2 = (int)(y2 * sy);
                        bres_fun(x1, y1, x2, y2, pp);

                    }

                    if (Elipse.Checked) {
                        x2 = (int)(x2 * sx);
                        y2 = (int)(y2 * sy);

                        elipse_dda(x2, y2, x1, y1, pp);
                    }

                    if (circle.Checked) {
                        x2 = (int)(x2 * sx);
                        y2 = (int)(x2 * sy);

                        Circle_fun(x1, y1, x2, pp);

                    }


                }


                if (rotation.Checked)
                {
                    double angle_ = double.Parse(angle.Text) * Math.PI / 180;
                    rotat(angle_);

                    if (DDA.Checked)
                        DDA_fun(x1, x2, y1, y2, pp);

                    if (bres.Checked)
                        bres_fun(x1, x2, y1, y2, pp);

                    if (Elipse.Checked)

                        elipse_dda(x2, y2, x1, y1, pp);

                    if (circle.Checked)
                        Circle_fun(x1, y1, x2, pp);

                }


            }

            catch (Exception )
            { MessageBox.Show("please inter correct data"); }


        }
    } 
}
