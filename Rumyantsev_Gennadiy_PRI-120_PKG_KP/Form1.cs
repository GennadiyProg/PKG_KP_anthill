using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Rumyantsev_Gennadiy_PRI_120_PKG_KP
{
    public enum Status
    {
        dough,
        grinder1,
        grinder2,
        oven,
        cream,
        oven2,
        mixing,
        modeling,
        ready
    }

    public partial class Form1 : Form

    {
        double angle = 3, angleX = -96, angleY = 0, angleZ = -30;
        double sizeX = 1, sizeY = 1, sizeZ = 1;

        double translateX = -9, translateY = -60, translateZ = -10;
        float deltaColor = 0;
        double cameraSpeed;
        Anthill anthill = new Anthill();
        uint hour = 1;
        double minute = 10;
        bool crook;
        double deltaYIfCrook = 0;
        bool mesFlag;
        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();

        Status status;

        bool[] ingrDough = new bool[5];
        bool[] ingrCream = new bool[2];

        // экземпляра класса Explosion

        float global_time = 0;
        uint creamSign, flourSign, sodaSign, catSign, cMilkSign;
        int imageId;

        string cream = "prostokvashino.png";
        string flour = "flour.png";
        string soda = "soda.png";
        string cMilk = "cmilk.jpeg";
        string cat = "uzor.jpg";

        bool ovenFlag;
        double deltaZPasta = 0;
        bool[] balls = new bool[5];
        double ballTranslateY = 0;
        uint countCake = 0;
        bool salut;
        private readonly Explosion boom = new Explosion(1, 10, 1, 300, 1000);


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
                cameraSpeed = (double)numericUpDown1.Value;
            AnT.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnT.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                angle = 3; angleX = -30; angleY = 0; angleZ = -40;
                sizeX = 1; sizeY = 1; sizeZ = 1;
                translateX = 70; translateY = -160; translateZ = -50;
                label6.Visible = false;
                label7.Visible = false;
                button1.Visible = false;
                WMP.controls.stop();
            }
            if (comboBox2.SelectedIndex == 1)
            {
                translateX = 85;
                translateY = -190;
                translateZ = -21;
                angleX = -90;
                angleZ = 0;
                label6.Visible = true;
                label7.Visible = true;
                button1.Visible = false;
                WMP.controls.stop();
            }
            if (comboBox2.SelectedIndex == 2)
            {
                translateX = 65;
                translateY = -160;
                translateZ = -20;
                angleX = -80;
                angleZ = 0;
                numericUpDown1.Value = 1;
                label6.Visible = false;
                label7.Visible = false;
                if (!ovenFlag && status == Status.oven) button1.Visible = true;
                else if (ovenFlag && status == Status.oven2) button1.Visible = true; else button1.Visible = false;
                WMP.controls.stop();

            }
            if (comboBox2.SelectedIndex == 3)
            {
                translateX = 90;
                translateY = -185;
                translateZ = -37;
                angleX = 0;
                angleZ = -90;
                numericUpDown1.Value = 1;
                label6.Visible = false;
                label7.Visible = false;
                button1.Visible = false;
                
                
            }
            if (comboBox2.SelectedIndex == 4)
            {
                translateX = 75;
                translateY = -150;
                translateZ = -25;
                angleX = -60;
                angleZ = -60;
                numericUpDown1.Value = 1;
                label6.Visible = false;
                label7.Visible = false;
                button1.Visible = false;
                WMP.controls.stop();
            }
            AnT.Focus();

        }

        private void AnT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                translateY -= cameraSpeed;

            }
            if (e.KeyCode == Keys.S)
            {
                translateY += cameraSpeed;
            }
            if (e.KeyCode == Keys.A)
            {
                translateX += cameraSpeed;
            }
            if (e.KeyCode == Keys.D)
            {
                translateX -= cameraSpeed;

            }
            if (e.KeyCode == Keys.ControlKey)
            {
                translateZ += cameraSpeed;

            }
            if (e.KeyCode == Keys.Space)
            {
                translateZ -= cameraSpeed;
            }
            if (e.KeyCode == Keys.Q)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        angleX += angle;

                        break;
                    case 1:
                        angleY += angle;

                        break;
                    case 2:
                        angleZ += angle;

                        break;
                    default:
                        break;
                }
            }
            if (e.KeyCode == Keys.E)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        angleX -= angle;
                        break;
                    case 1:
                        angleY -= angle;
                        break;
                    case 2:
                        angleZ -= angle;
                        break;
                    default:
                        break;
                }
            }
            if (e.KeyCode == Keys.Z)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        sizeX += 0.1;
                        break;
                    case 1:
                        sizeY += 0.1;
                        break;
                    case 2:
                        sizeZ += 0.1;
                        break;
                    default:
                        break;
                }
            }
            if (e.KeyCode == Keys.X)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        sizeX -= 0.1;
                        break;
                    case 1:
                        sizeY -= 0.1;
                        break;
                    case 2:
                        sizeZ -= 0.1;
                        break;
                    default:
                        break;
                }

            }
            if (hour > 1 && e.KeyCode == Keys.O) hour -= 1;
            if (hour < 11 && e.KeyCode == Keys.L) hour += 1;
            if (minute > 1 && e.KeyCode == Keys.I) minute -= 10;
            if (minute < 59 && e.KeyCode == Keys.K) minute += 10;

            if (e.KeyCode == Keys.B && ballTranslateY > -10) ballTranslateY -= 1;
            if (e.KeyCode == Keys.N && ballTranslateY < 80) ballTranslateY += 1;


        }


        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void AnT_MouseClick(object sender, MouseEventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 3:
                    if (status == Status.dough)
                    {
                        if (e.X > 70 && e.X < 130 && e.Y < 300 && e.Y > 240)
                        {
                            ingrDough[0] = true;
                        }
                        else if (e.X > 132 && e.X < 170 && e.Y < 300 && e.Y > 240)
                        {
                            ingrDough[1] = true;
                        }
                        else if (e.X > 178 && e.X < 223 && e.Y < 300 && e.Y > 240)
                        {
                            ingrDough[2] = true;
                        }
                        else if (e.X > 200 && e.X < 300 && e.Y < 180 && e.Y > 100)
                        {
                            ingrDough[3] = true;
                        }
                        else if (e.X > 310 && e.X < 350 && e.Y < 180 && e.Y > 100)
                        {
                            ingrDough[4] = true;
                        }
                        if (Array.FindIndex(ingrDough, ingr => ingr.Equals(false)) == -1)
                        {
                            status = Status.grinder1;
                        }
                    }
                    else if (status == Status.cream)
                    {
                        if (e.X > 150 && e.X < 200 && e.Y < 300 && e.Y > 240)
                        {
                            ingrCream[0] = true;
                        }
                        else if (e.X > 200 && e.X < 270 && e.Y < 190 && e.Y > 100)
                        {
                            ingrCream[1] = true;
                        }
                        if (Array.FindIndex(ingrCream, ingr => ingr.Equals(false)) == -1)
                        {
                            status = Status.oven2;
                        }
                    }
                    break;
                case 4:
                    if (status == Status.grinder1 && e.X > 60 && e.X < 160 && e.Y < 300 && e.Y > 220)
                    {
                        status = Status.grinder2;
                    }

                    break;
            }

            ;
        }

        private uint genImage(string image)
        {
            uint sign = 0;
            Il.ilGenImages(1, out imageId);
            Il.ilBindImage(imageId);
            if (Il.ilLoadImage(image))
            {
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp)
                {
                    case 24:
                        sign = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        sign = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            Il.ilDeleteImages(1, ref imageId);
            return sign;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (status)
            {
                case Status.oven:
                    ovenFlag = true;
                    status = Status.cream;
                    break;
                case Status.oven2:
                    ovenFlag = false;
                    status = Status.mixing;
                    break;
                case Status.mixing:
                    status = Status.modeling;
                    break;
                case Status.modeling:
                    status = Status.ready;
                    crook = true;
                    break;
            }
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            global_time += (float)RenderTimer.Interval / 1000;
            Draw();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form about = new AboutProgram();
            about.ShowDialog();

        }

        private void рецептToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new Recipe();
            about.ShowDialog();

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            status = Status.dough;

            // инициализация openGL (glut)
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            // цвет очистки окна
            Gl.glClearColor(255, 255, 255, 1);

            // настройка порта просмотра
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(60, (float)AnT.Width / (float)AnT.Height, 0.1, 900);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            catSign = genImage(cat);
            creamSign = genImage(cream);
            flourSign = genImage(flour);
            sodaSign = genImage(soda);
            cMilkSign = genImage(cMilk);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            cameraSpeed = 5;
            deltaColor = 0;
            balls[0] = true;
            balls[1] = false;
            label9.Visible = false;

            RenderTimer.Start();
        }

        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            uint texObject;
            Gl.glGenTextures(1, out texObject);
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
            switch (Format)
            {

                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

            }
            return texObject;
        }


        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            Gl.glRotated(angleX, 1, 0, 0); Gl.glRotated(angleY, 0, 1, 0); Gl.glRotated(angleZ, 0, 0, 1);
            Gl.glTranslated(translateX, translateY, translateZ);
            Gl.glScaled(sizeX, sizeY, sizeZ);
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            boom.Calculate(global_time);

            text();

            anthill.drawFloor(deltaColor);

            anthill.drawTable(deltaColor);
            drawFractal(30, 0, 1.1, 10, 5);
            anthill.drawWalls(deltaColor, catSign);
            if (status == Status.dough) anthill.drawDishes(deltaColor, ingrDough);
            if (!ingrDough[1]) anthill.drawFlour(deltaColor, flourSign);
            if (!ingrDough[2]) anthill.drawSoda(deltaColor, sodaSign);
            if (!ingrDough[0]) anthill.drawSourCream(deltaColor, creamSign);
            if (!ingrDough[3]) anthill.drawButter(deltaColor);
            if (!ingrDough[4]) anthill.drawSugar(deltaColor);

            anthill.drawPedistal(deltaColor);
            anthill.drawGrinder(deltaColor);
            anthill.drawOven(deltaColor, ovenFlag);
            anthill.drawClock(deltaColor, hour, minute);

            if (status == Status.grinder1 && comboBox2.SelectedIndex == 4)
                anthill.drawDough(status, deltaColor);

            if (status == Status.grinder2 && comboBox2.SelectedIndex == 4)
            {
                anthill.drawPasta(deltaColor, deltaZPasta);
                deltaZPasta += 0.5;
            }
            if (deltaZPasta == 100)
            {
                status = Status.oven;
                deltaZPasta = 0;
                anthill.drawDough(status, deltaColor);

            }
            else if (status == Status.oven) anthill.drawDough(status, deltaColor);

            if (status == Status.cream && comboBox2.SelectedIndex == 3)
            {
                if (!ingrCream[1]) anthill.drawButter(deltaColor);
                if (!ingrCream[0]) anthill.drawCMilk(deltaColor, cMilkSign);
            }

            if ((status == Status.cream || status == Status.oven2 || status == Status.mixing) && comboBox2.SelectedIndex == 3)
            {
                anthill.drawCream(deltaColor, ingrCream);
            }
            if (status == Status.mixing && comboBox2.SelectedIndex == 3) anthill.drawDough(status, deltaColor);

            if (status == Status.modeling)
            {
                anthill.drawBalls(ballTranslateY, balls, deltaColor, countCake);
                if (ballTranslateY >= 50)
                {
                    ballTranslateY = 0;
                    int k = Array.FindIndex(balls, ball => ball.Equals(true));
                    balls[k] = false;
                    if (balls.Length != k + 1)
                        balls[k + 1] = true;
                    else status = Status.ready;
                }
            }
        
            if (status == Status.ready)
            {
                anthill.drawCake(deltaColor, deltaYIfCrook);
                
                if (crook)
                {
                    anthill.drawAnts(deltaYIfCrook);
                    deltaYIfCrook += 1;
                    if (deltaYIfCrook ==30 && !mesFlag)
                    {
                        MessageBox.Show("Муравьи украли муравейник! Жульничать плохо");
                        mesFlag = true;
                    }
                }
                   
                if (!salut)
                {
                    boom.SetNewPosition(-95, 180, 10);
                    boom.SetNewPower(10);
                    boom.Boooom(global_time);
                    salut = true;
                    WMP.URL = @"app.mp3";
                    WMP.controls.play();
                }
            }
            
            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();

            if (minute >= 60)
            {
                if (hour < 12)
                {
                    hour += 1;
                }
                else hour = 1;
                minute = 0;
            }
            else minute += 0.9;
            if (hour == 1) deltaColor = 0;
            else
                if (hour > 9) deltaColor = 0.3f;
            else
                if (hour > 6) deltaColor = 0.2f;
            else
                if (hour > 3) deltaColor = 0.1f;


        }

        public void text()
        {
            switch (status)
            {
                case Status.dough:
                    label8.Text = "Смешайте ингредиенты для теста";
                    break;
                case Status.grinder1:
                    label8.Text = "Измельчите тесто в мясорубке";
                    break;
                case Status.oven:
                    label8.Text = "Отправьте тесто в печь";
                    button1.Text = "В печь";
                    break;
                case Status.cream:
                    button1.Visible = false;
                    label8.Text = "Нужно сделать крем (к столу)";
                    break;
                case Status.oven2:
                    button1.Text = "Достать из печи";
                    label8.Text = "Тесто готово! К печи!";
                    break;
                case Status.mixing:
                    button1.Text = "Смешать";
                    if (comboBox2.SelectedIndex == 3) button1.Visible = true; else button1.Visible = false;
                    label8.Text = "Пора смешать тесто и крем";
                    break;
                case Status.modeling:
                    button1.Text = "Сжульничать";
                    if (comboBox2.SelectedIndex == 3) button1.Visible = true; else button1.Visible = false;
                    label8.Text = "Слепите торт";
                    label9.Visible = true;
                    break;
                case Status.ready:
                    label9.Visible = false;
                    label8.Text = "МУРАВЕЙНИК ГОТОВ!";
                    button1.Visible = false;
                    break;
            }
        }
        void drawFractal(double x, double y, double angle, double len, int deph)
        {
            Gl.glPushMatrix();
            Gl.glRotated(90, 0, 0, 1);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glTranslated(154, 19, -99);

            Gl.glBegin(Gl.GL_LINES);
            drawBinaryTree(x, y, angle, len, deph);
            Gl.glEnd();
            Gl.glPopMatrix();
        }

        void drawBinaryTree(double x, double y, double angle, double len, int deph)
        {
            Gl.glColor3f(0, 0, 0);
            double angp = 0.5; //изменение угла
            for (int i = -1; i < 5; i += 2)
            {
                //если не достигнута глубина рекурсии - продолжить построение фрактала
                if (deph > 0)
                    drawBinaryTree(x + Math.Cos(angle + i * angp) * len / 2, y + Math.Sin(angle + i * angp) * len / 2, angle + i * angp, len / 2, deph - 1);
                /* В буфер записываются вершины. Эти две вершины будут соединены в прямые между собой*/
                Gl.glVertex2d(x, y);
                Gl.glVertex2d(x + Math.Cos(angle + i * angp) * len / 2, y + Math.Sin(angle + i * angp) * len / 2);
            }
        }
    }
}
