using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Rumyantsev_Gennadiy_PRI_120_PKG_KP
{
    class Anthill
    {
        public void drawFloor(float deltaColor)
        {
            double deltaYFloor = 100;
            Gl.glPushMatrix();

            //пол
            Gl.glPushMatrix();
            Gl.glColor3f(0.92f - deltaColor, 0.57f - deltaColor, 0.13f - deltaColor);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(0, 200, 0);
            Gl.glVertex3d(-100, 200, 0);
            Gl.glVertex3d(-100, 100, 0);
            Gl.glVertex3d(0, 100, 0);
            Gl.glEnd();
            Gl.glPopMatrix();

            //дощечки
            Gl.glPushMatrix();
            Gl.glColor3f(0.26f - deltaColor, 0.13f - deltaColor, 0.07f - deltaColor);
            Gl.glTranslated(0, 0, 0.1);

            for (int j = 0; j < 21; j++)
            {
                if (deltaYFloor == 220) deltaYFloor = 0;
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3d(-100, deltaYFloor, 0);
                Gl.glVertex3d(0, deltaYFloor, 0);
                Gl.glEnd();
                deltaYFloor += 5;
            };

            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }

        public void drawWalls(float deltaColor, uint catSign)
        {
            float wallR = 0.67f;
            float wallG = 0.84f;
            float wallB = 0.87f;

            Gl.glPushMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(wallR - deltaColor, wallG - deltaColor, wallB - deltaColor);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(-100, 100, 0);
            Gl.glVertex3d(-100, 200, 0);
            Gl.glVertex3d(-100, 200, 100);
            Gl.glVertex3d(-100, 100, 100);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(0, 200, 0);
            Gl.glVertex3d(-100, 200, 0);
            Gl.glVertex3d(-100, 200, 100);
            Gl.glVertex3d(0, 200, 100);
            Gl.glEnd();
            Gl.glPopMatrix();

            //picture

            Gl.glPushMatrix();
            Gl.glColor3f(1 - deltaColor, 1 - deltaColor, 1 - deltaColor);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(-99.85, 195, 15);
            Gl.glVertex3d(-99.85, 173, 15);
            Gl.glVertex3d(-99.85, 173, 30);
            Gl.glVertex3d(-99.85, 195, 30);
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glLineWidth(4f);
            Gl.glColor3f(0,0,0);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(-99.85, 194, 15);
            Gl.glVertex3d(-99.85, 196, 15);
            Gl.glVertex3d(-99.85, 196, 30);
            Gl.glVertex3d(-99.85, 194, 30);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(-99.85, 172, 15);
            Gl.glVertex3d(-99.85, 174, 15);
            Gl.glVertex3d(-99.85, 172, 30);
            Gl.glVertex3d(-99.85, 174, 30);
            Gl.glEnd();

            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, catSign);
            Gl.glPushMatrix();
            Gl.glTranslated(-20, -10, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-79, 170, 20);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(-79, 160, 20);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-79, 160, 30);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-79, 170, 30);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();

            Gl.glColor3f(0.22f - deltaColor, 0.32f - deltaColor, 0.64f - deltaColor);
            Gl.glTranslated(-99.5, 199.5, 0);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, 0, 100);
            Gl.glEnd();

            Gl.glTranslated(0, 0, 1);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, -100, 0);
            Gl.glEnd();

            Gl.glTranslated(0, 0, 0);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(100, 0, 0);
            Gl.glEnd();

            Gl.glPopMatrix();


        }

        public void drawTable(float deltaColor)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-60, 80, 0);
            Gl.glScaled(0.75, 0.8, 0.75);

            Gl.glPushMatrix();
            Gl.glTranslated(-40, 130, 15);
            Gl.glScaled(2, 3, 0.5);
            Gl.glColor3f(0.7f - deltaColor, 0.7f - deltaColor, 0.7f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-32, 118, 9.5);
            Gl.glScaled(0.2, 0.2, 1.5);
            Gl.glColor3f(0.7f - deltaColor, 0.7f - deltaColor, 0.7f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-47, 118, 9.5);
            Gl.glScaled(0.2, 0.2, 1.5);
            Gl.glColor3f(0.7f - deltaColor, 0.7f - deltaColor, 0.7f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-32, 142, 9.5);
            Gl.glScaled(0.2, 0.2, 1.5);
            Gl.glColor3f(0.7f - deltaColor, 0.7f - deltaColor, 0.7f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-47, 142, 9.5);
            Gl.glScaled(0.2, 0.2, 1.5);
            Gl.glColor3f(0.7f - deltaColor, 0.7f - deltaColor, 0.7f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }

        public void drawSourCream(float deltaColor, uint creamSign)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-94, 177, 15);
            Gl.glScaled(0.75, 0.8, 0.85);
            //cream
            Gl.glPushMatrix();

            Gl.glTranslated(10, 0, -2.5);
            Gl.glScaled(0.4, 0.3, 0.2);
            Gl.glTranslated(0, 0, 8.5);
            Gl.glColor3f(0 - deltaColor, 0 - deltaColor, 1 - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);

            Gl.glPushMatrix();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, creamSign);
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 5);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(5, -5, 0);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(5, 5, 0);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-5, 5, 0);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-5, -5, 0);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(5, 5, 1);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(5, -5, 1);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-5, -5, 1);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-5, 5, 1);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();

            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        public void drawFlour(float deltaColor, uint flourSign)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-94, 177, 15);
            Gl.glScaled(0.75, 0.8, 0.85);
            //flour
            Gl.glPushMatrix();
            Gl.glTranslated(10, 4, -2.5);
            Gl.glScaled(0.4, 0.3, 0.2);
            Gl.glTranslated(0, 0, 8.5);
            Gl.glColor3f(0.89f - deltaColor, 0.95f - deltaColor, 0.11f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);

            Gl.glPushMatrix();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, flourSign);
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 5);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(5, 5, 1);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(5, -5, 1);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-5, -5, 1);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-5, 5, 1);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glTranslated(0, 0, 0.5);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(5, 5, 1);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(5, -5, 1);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-5, -5, 1);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-5, 5, 1);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        public void drawSoda(float deltaColor, uint sodaSign)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-94, 177, 15);
            Gl.glScaled(0.75, 0.8, 0.85);
            //soda
            Gl.glPushMatrix();
            Gl.glTranslated(10, 8, -2.5);
            Gl.glScaled(0.4, 0.3, 0.2);
            Gl.glTranslated(0, 0, 8.5);
            Gl.glColor3f(1 - deltaColor, 0 - deltaColor, 0 - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);

            Gl.glPushMatrix();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, sodaSign);
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 5);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(5, 5, 1);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(5, -5, 1);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-5, -5, 1);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-5, 5, 1);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glTranslated(0, 0, 0.5);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(5, 5, 1);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(5, -5, 1);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-5, -5, 1);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-5, 5, 1);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        public void drawDishes(float deltaColor, bool[] ingredients)
        {
            float teapotR = 0.3f;
            float teapotG = 0.13f;
            float teapotB = 0.6f;
            
            Gl.glPushMatrix();

            Gl.glTranslated(-94, 177, 15);
            Gl.glScaled(0.75, 0.8, 0.85);

            //teapot
            Gl.glPushMatrix();
            Gl.glRotated(90, 0, 0, 1);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glColor3f(teapotR - deltaColor, teapotG - deltaColor, teapotB - deltaColor);
            Glut.glutSolidTeapot(3);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(2f);
            Glut.glutWireTeapot(3);
            Gl.glPopMatrix();

            //dish
            Gl.glPushMatrix();
            Gl.glTranslated(10, 18, -1.6);
            Gl.glRotated(180, 1, 0, 0);
            Gl.glScaled(0.35, 0.35, 0.000005);
            Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1 - deltaColor);
            Glut.glutSolidSphere(12, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireSphere(12, 32, 20);
            Gl.glPopMatrix();

            int count = Array.FindAll(ingredients, ingr => ingr.Equals(true)).Length;
            Gl.glPushMatrix();
            Gl.glTranslated(10, 18, -2);
            if (ingredients[3]) 
                Gl.glColor3f(0.96f - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor); else
            Gl.glColor3f(1 - deltaColor, 1 - deltaColor, 1 - deltaColor);
            Glut.glutSolidCone(0.8 * count, count, 32, 10);
            Gl.glColor3f(0, 0, 0);

            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }



        public void drawButter(float deltaColor)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-94, 177, 15);
            Gl.glScaled(0.75, 0.8, 0.85);
            //butter
            Gl.glPushMatrix();
            Gl.glTranslated(0, 10, -2);
            Gl.glScaled(1, 1, 1);
            Gl.glColor3f(0.9f - deltaColor, 0.9f - deltaColor, 0.9f - deltaColor);
            Glut.glutSolidCylinder(3, 0.5, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(3, 0.5, 32, 32);

            Gl.glScaled(0.2, 0.2, 0.2);
            Gl.glTranslated(0, 0, 8.5);
            Gl.glColor3f(0.89f - deltaColor, 0.95f - deltaColor, 0.11f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        public void drawSugar(float deltaColor)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-94, 177, 15);
            Gl.glScaled(0.75, 0.8, 0.85);
            //sugar
            Gl.glPushMatrix();
            Gl.glTranslated(0, 18, -2);
            Gl.glScaled(1, 1, 1);
            Gl.glColor3f(0.48f - deltaColor, 0.49f - deltaColor, 0.5f - deltaColor);
            Glut.glutSolidCylinder(3, 0.5, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(3, 0.5, 32, 32);

            Gl.glTranslated(0, 0, 0);
            Gl.glColor3f(1 - deltaColor, 1 - deltaColor, 1 - deltaColor);
            Glut.glutSolidCone(2.5, 5, 10, 1);
            Gl.glColor3f(0, 0, 0);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        public void drawPedistal(float deltaColor)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-95, 162, 0);
            Gl.glScaled(0.85, 1, 2.8);
            Gl.glColor3f(0.3f - deltaColor, 0 - deltaColor, 0 - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);

            Gl.glTranslated(9.5, 0, 0);
            Gl.glScaled(0.85, 1, 0.5);
            Gl.glColor3f(0.3f - deltaColor, 0 - deltaColor, 0 - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);

            Gl.glPopMatrix();

        }

        public void drawGrinder(float deltaColor)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-95, 162, 12);
            Gl.glScaled(2, 2, 2);
            Gl.glColor3f(0.5f - deltaColor, 0.5f - deltaColor, 0.5f - deltaColor);
            Glut.glutSolidCube(3);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(3);

            Gl.glTranslated(0,0,3);
            Gl.glScaled(0.8, 0.8, 0.85);
            Gl.glColor3f(0.5f - deltaColor, 0.5f - deltaColor, 0.5f - deltaColor);
            Glut.glutSolidCube(3);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(3);

            Gl.glTranslated(2.2, 0, 0.4);
            Gl.glScaled(0.45, 0.3, 0.3);
            Gl.glColor3f(0.5f - deltaColor, 0.5f - deltaColor, 0.5f - deltaColor);
            Glut.glutSolidCube(3);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(3);

            Gl.glPushMatrix();
            Gl.glTranslated(1.8, 0, 0);
            Gl.glRotated(180, 1, 0, 0);
            Gl.glScaled(0.03, 0.2, 0.2);
            Gl.glColor3f(0.5f - deltaColor, 0.5f - deltaColor, 0.5f - deltaColor);
            Glut.glutSolidSphere(12, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireSphere(12, 32, 20);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(5.8, 0, -22);
            Gl.glScaled(0.8, 2.2, 0.01);
            Gl.glColor3f(0, 0, 0);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-5, 0, 5);
            Gl.glScaled(0.5, 1, 0.7);
            Gl.glColor3f(0.5f - deltaColor, 0.5f - deltaColor, 0.5f - deltaColor);
            Glut.glutSolidCube(5);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(5);

            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-5, -18, -25);
            Gl.glScaled(1,1.5,1.5);
            Gl.glColor3f(0.3f - deltaColor, 0, 0);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);

            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        public void drawOven(float deltaColor, bool flag)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(-65, 182, 3);

            Gl.glPushMatrix(); 
            Gl.glTranslated(0, 10, -2);
            Gl.glScaled(1.2, 0.8, 1.2);
            Gl.glColor3f(0.2f - deltaColor, 0f, 0f);
            Glut.glutSolidCylinder(8, 1.5, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(8, 1.5, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0, 10, 0);
            Gl.glScaled(1.2, 0.8, 1.2);
            Gl.glColor3f(0.8f - deltaColor, 0.8f - deltaColor, 0.8f - deltaColor);
            Glut.glutSolidCylinder(7, 15, 6, 2);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(7, 15, 6, 2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0, 10, 18);
            Gl.glScaled(1.2, 0.8, 1.2);
            Gl.glColor3f(0.8f - deltaColor, 0.8f - deltaColor, 0.8f - deltaColor);
            Glut.glutSolidCylinder(3, 5, 6, 2);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(3, 5, 6, 2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0, 10, 23.5);
            Gl.glScaled(1.2, 0.8, 0.5);
            Gl.glColor3f(0, 0, 0);
            Glut.glutSolidCylinder(3.5, 2, 6, 2);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(3.5, 2, 6, 2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            if (flag) Gl.glColor3f(0.7f, 0.25f, 0); else Gl.glColor3f(0,0,0);
            Gl.glTranslated(0, 0, -1);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(3, 5, 5);
            Gl.glVertex3d(-3, 5, 5);
            Gl.glVertex3d(-3, 5, 13);
            Gl.glVertex3d(3, 5, 13);
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }

        public void drawClock(float deltaColor, uint hour, double minute)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(-85, 182, 3);

            Gl.glPushMatrix();
            Gl.glTranslated(0, 18, 18);
            Gl.glScaled(1, 0.8, 1);
            Gl.glColor3f(0,0,0);
            Gl.glRotated(90, 1, 0, 0);
            Glut.glutSolidCylinder(3, 1, 32, 22);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(3, 1, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0, 17.6, 18);
            Gl.glScaled(1, 0.8, 1);
            Gl.glColor3f(1 - deltaColor, 1 - deltaColor, 1 - deltaColor);
            Gl.glRotated(90, 1, 0, 0);
            Glut.glutSolidCylinder(2.3, 1, 32, 22);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(2.3, 1, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0, 17.4, 18);
            Gl.glScaled(1, 0.8, 1);
            Gl.glColor3f(0, 0, 0);
            Gl.glRotated(90, 1, 0, 0);
            Glut.glutSolidCylinder(0.2, 1, 32, 22);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(0.2, 1, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0, 16, 18);
            Gl.glLineWidth(5f);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0, 0, 0);

            if (minute <=10)
                    Gl.glVertex3d(1.3, 0, 1.3);
            else if (minute<=20)
                    Gl.glVertex3d(1.3, 0, -1.3);
                   else if (minute<= 30)
                    Gl.glVertex3d(0, 0, -1.8);
           else if (minute <=40)
                    Gl.glVertex3d(-1.3, 0, -1.3);
           else if (minute <=50)
                    Gl.glVertex3d(-1.3, 0, 1.3);
                 else
                    Gl.glVertex3d(0, 0, 1.8);
           
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0, 16, 18);
            Gl.glLineWidth(10f);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0, 0, 0);
            switch (hour)
            {
                case 1:
                    Gl.glVertex3d(0.75, 0, 1.5);
                    break;
                case 2:
                    Gl.glVertex3d(1.3, 0, 1);
                    break;
                case 3:
                    Gl.glVertex3d(1.8, 0, 0);
                    break;
                case 4:
                    Gl.glVertex3d(1.3, 0, -1);
                    break;
                case 5:
                    Gl.glVertex3d(0.75, 0, -1.5);
                    break;
                case 6:
                    Gl.glVertex3d(0, 0, -1.8);
                    break;
                case 7:
                    Gl.glVertex3d(-0.75, 0, -1.5);
                    break;
                case 8:
                    Gl.glVertex3d(-1.3, 0, -1);
                    break;
                case 9:
                    Gl.glVertex3d(-1.8, 0, 0);
                    break;
                case 10:
                    Gl.glVertex3d(-1.3, 0, 1);
                    break;
                case 11:
                    Gl.glVertex3d(-0.75, 0, 1.5);
                    break;
                case 12:
                    Gl.glVertex3d(0, 0, 1.8);
                    break;
            }
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glPopMatrix();

        }

        public void drawDough(Status s, float deltaColor)
        {
            Gl.glPushMatrix();
            switch (s)
            {
                case Status.grinder1:
                    Gl.glTranslated(-93, 138, 12);
                    Gl.glScaled(0.75, 0.8, 0.85);
                    Gl.glPushMatrix();
                    Gl.glTranslated(0, 18, -2);
                    Gl.glScaled(1, 1, 1);
                    Gl.glColor3f(0.48f - deltaColor, 0.49f - deltaColor, 0.5f - deltaColor);
                    Glut.glutSolidCylinder(3, 0.5, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCylinder(3, 0.5, 32, 32);

                    Gl.glTranslated(0, 0, 1.5);
                    Gl.glColor3f(0.96f - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glColor3f(0.56f - deltaColor, 0.2f - deltaColor, 0.27f - deltaColor);
                    Glut.glutWireSphere(3, 32, 4);
                    Gl.glPopMatrix();
                    break;
                case Status.oven:
                    Gl.glTranslated(-84, 160, 10);
                    Gl.glScaled(0.2, 5.6, 0.1);
                    for (int i = 0; i < 5; i++)
                    {
                        Gl.glTranslated(-3, 0, 0);

                        Gl.glColor3f(0.96f - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
                        Glut.glutSolidCube(1);
                        Gl.glLineWidth(0.5f);
                        Gl.glColor3f(0.56f - deltaColor, 0.2f - deltaColor, 0.27f - deltaColor);
                        Glut.glutWireCube(1);
                    }
                    break;
                case Status.mixing:
                    Gl.glPushMatrix();

                    Gl.glTranslated(-94, 177, 15);
                    Gl.glScaled(0.75, 0.8, 0.85);

                    //dish
                    Gl.glPushMatrix();
                    Gl.glTranslated(10, 18, -1.6);
                    Gl.glRotated(180, 1, 0, 0);
                    Gl.glScaled(0.35, 0.5, 0.000005);
                    Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1 - deltaColor);
                    Glut.glutSolidSphere(9, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireSphere(9, 32, 20);
                    Gl.glPopMatrix();

                    Gl.glTranslated(12, 18, -1.6);
                    Gl.glScaled(0.3, 7, 0.1);
                    for (int i = 0; i < 10; i++)
                    {
                        Gl.glTranslated(-1.3, 0, 0);

                        Gl.glColor3f(0.96f - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
                        Glut.glutSolidCube(1);
                    }
                    Gl.glPopMatrix();
                    break;

            }
            
            Gl.glPopMatrix();
        }

        public void drawPasta(float deltaColor, double deltaZPasta)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(-89.7, 163, 19.5-deltaZPasta*0.055);
            Gl.glScaled(0.2, 0.2, 0.1*deltaZPasta);
            for (int i = 0; i < 3; i++)
            {
                Gl.glTranslated(0, -3, 0);
                
                Gl.glColor3f(0.96f - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
                Glut.glutSolidCube(1);
                Gl.glLineWidth(0.5f);
                Gl.glColor3f(0.56f - deltaColor, 0.2f - deltaColor, 0.27f - deltaColor);
                Glut.glutWireCube(1);
            }

            Gl.glPopMatrix();
        }

        public void drawCMilk(float deltaColor, uint cMilkSign)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-94, 175, 15);
            Gl.glScaled(0.75, 0.8, 0.85);
            Gl.glPushMatrix();
            Gl.glTranslated(10, 8, -2.5);
            Gl.glScaled(0.4, 0.3, 0.2);
            Gl.glTranslated(0, 0, 8.5);
            Gl.glColor3f(0 - deltaColor, 0 - deltaColor, 1 - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);

            Gl.glPushMatrix();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, cMilkSign);
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 5);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(5, 5, 1);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(5, -5, 1);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-5, -5, 1);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-5, 5, 1);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        public void drawCream(float deltaColor, bool[] ingredients)
        {

            Gl.glPushMatrix();

            Gl.glTranslated(-94, 177, 15);
            Gl.glScaled(0.75, 0.8, 0.85);

            //dish
            Gl.glPushMatrix();
            Gl.glTranslated(10, 0, -1.6);
            Gl.glRotated(180, 1, 0, 0);
            Gl.glScaled(0.35, 0.35, 0.000005);
            Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1 - deltaColor);
            Glut.glutSolidSphere(9, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireSphere(9, 32, 20);
            Gl.glPopMatrix();

            int count = Array.FindAll(ingredients, ingr => ingr.Equals(true)).Length;
            Gl.glPushMatrix();
            Gl.glTranslated(10, 0, -2);
                Gl.glColor3f(0.96f - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
                Glut.glutSolidCone(1.5* count, 1.5* count, 32, 10);
            Gl.glColor3f(0, 0, 0);

            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }

        public void drawBalls(double deltaY, bool[] balls, float deltaColor, uint countCake)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-94, 177, 15);
            Gl.glScaled(0.75, 0.75, 0.85);

            //dish
            Gl.glPushMatrix();
            Gl.glTranslated(6, 18, -1.6);
            Gl.glRotated(180, 1, 0, 0);
            Gl.glScaled(0.7, 0.7, 0.000005);
            Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1 - deltaColor);
            Glut.glutSolidSphere(9, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireSphere(9, 32, 20);
            Gl.glPopMatrix();

            Gl.glTranslated(13, 0, -1.6);
            Gl.glScaled(0.3, 0.3, 0.1);
            bool flag = false;
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                if (balls[i])
                {
                    flag = true;
                    Gl.glTranslated(-8, deltaY, 0);
                    Gl.glColor3f(0.46f - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glTranslated(0, -deltaY, 0);
                }
                else if (flag)
                {
                    Gl.glColor3f(0.96f - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
                    Gl.glTranslated(-8, 0, 0);
                    Glut.glutSolidSphere(3, 32, 32);
                }
                else count++;
            }

            Gl.glPushMatrix();
            Gl.glTranslated(-9, 60, -1.6);
            Gl.glScaled(0.5, 0.5, 2);
            Gl.glColor3f(0.96f - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
            Glut.glutSolidSphere(3 * count, 32, 32);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        public void drawCake(float deltaColor, double deltaYIfCrook)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-94, 177 - deltaYIfCrook, 15);
            Gl.glScaled(0.75, 0.75, 0.85);

            //dish
            Gl.glPushMatrix();
            Gl.glTranslated(6, 18, -1.6);
            Gl.glRotated(180, 1, 0, 0);
            Gl.glScaled(0.7, 0.7, 0.000005);
            Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1 - deltaColor);
            Glut.glutSolidSphere(9, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireSphere(9, 32, 20);
            Gl.glPopMatrix();

            Gl.glTranslated(8.5, 12.5, -1.6);
            Gl.glScaled(0.3, 0.3, 0.5);
            Gl.glTranslated(-8, 18, 0);
            Gl.glColor3f(1 - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
            Glut.glutSolidSphere(8, 32, 32);
            Gl.glColor3f(0.4f, 0, 0);
            Glut.glutWireSphere(8, 32, 12);

            Gl.glTranslated(0, -10, 0);
            Gl.glColor3f(1 - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
            Glut.glutSolidSphere(7, 32, 32);
            Gl.glColor3f(0.4f, 0, 0);
            Glut.glutWireSphere(7, 32, 12);

            Gl.glTranslated(0, 20, 0);
            Gl.glColor3f(1 - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
            Glut.glutSolidSphere(7, 32, 32);
            Gl.glColor3f(0.4f, 0, 0);
            Glut.glutWireSphere(7, 32, 12);

            Gl.glTranslated(10, -10, 0);
            Gl.glColor3f(1 - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
            Glut.glutSolidSphere(7, 32, 32);
            Gl.glColor3f(0.4f, 0, 0);
            Glut.glutWireSphere(7, 32, 12);

            Gl.glTranslated(-20, 0, 0);
            Gl.glColor3f(1 - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
            Glut.glutSolidSphere(7, 32, 32);
            Gl.glColor3f(0.4f, 0, 0);
            Glut.glutWireSphere(7, 32, 12);

            Gl.glTranslated(4, -6, 0);
            Gl.glColor3f(1 - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
            Glut.glutSolidSphere(7, 32, 32);
            Gl.glColor3f(0.4f, 0, 0);
            Glut.glutWireSphere(7, 32, 12);

            Gl.glTranslated(12, 0, 0);
            Gl.glColor3f(1 - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
            Glut.glutSolidSphere(7, 32, 32);
            Gl.glColor3f(0.4f, 0, 0);
            Glut.glutWireSphere(7, 32, 12);

            Gl.glTranslated(0, 12, 0);
            Gl.glColor3f(1 - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
            Glut.glutSolidSphere(7, 32, 32);
            Gl.glColor3f(0.4f, 0, 0);
            Glut.glutWireSphere(7, 32, 12);

            Gl.glTranslated(-12, 0, 0);
            Gl.glColor3f(1 - deltaColor, 0.89f - deltaColor, 0.43f - deltaColor);
            Glut.glutSolidSphere(7, 32, 32);
            Gl.glColor3f(0.4f, 0, 0);
            Glut.glutWireSphere(7, 32, 12);


            Gl.glPopMatrix();
        }

        public void drawAnts(double deltaYIfCrook)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(-94, 186 - deltaYIfCrook, 15);
            Gl.glScaled(0.5, 0.5, 0.5);

            
            Gl.glPushMatrix();
            Gl.glTranslated(-3, 18, -1.6);
            for (int i = 0; i < 3; i++)
            {
                Gl.glTranslated(6, 0, 0);
                Gl.glPushMatrix();
                Gl.glColor3f(0, 0, 0);
                Glut.glutSolidSphere(0.6, 12, 12);
                Gl.glTranslated(0, 1, 0);
                Glut.glutSolidSphere(0.5, 12, 12);
                Gl.glTranslated(0, 1, 0);
                Glut.glutSolidSphere(0.6, 12, 12);
                Gl.glLineWidth(2f);
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3d(-1.2, 1, 0);
                Gl.glVertex3d(0, 0, 0);
                Gl.glEnd();
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3d(0, 0, 0);
                Gl.glVertex3d(1.2, 1, 0);
                Gl.glEnd();
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3d(-1.2, -1, 0);
                Gl.glVertex3d(0, -1, 0);
                Gl.glEnd();
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3d(1.2, -1, 0);
                Gl.glVertex3d(0, -1, 0);
                Gl.glEnd();
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3d(-1.2, -2, 0);
                Gl.glVertex3d(0, -1, 0);
                Gl.glEnd();
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3d(1.2, -2, 0);
                Gl.glVertex3d(0, -1, 0);
                Gl.glEnd();
                Gl.glPopMatrix();
            }
           

            Gl.glPopMatrix();



            Gl.glPopMatrix();
        }
    }
}
