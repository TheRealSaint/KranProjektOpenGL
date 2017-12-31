using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsGL.OpenGL;

namespace KranProjektOpenGL
{
    class TKran
    {
        private System.Drawing.Color color = System.Drawing.Color.Gray;
        private double height = 4;
        private double armLength = 2;

        private int angle = 0;
        private double armPosition = 0;
        private double ropePosition = 0;

        public int targetAngle;
        public double targetArmPosition;
        public double targetRopePosition;

        public TKran()
        {

        }

        public void draw()
        {
            armPosition = targetArmPosition;
            angle = targetAngle;

            float red = (float)color.R / 255;
            float green = (float)color.G / 255;
            float blue = (float)color.B / 255;
            GL.glColor3f(red, green, blue);

            GL.glRotated(angle, 0, 0, 1);
            GLUquadric tower = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(tower, GLU.GLU_FILL);
            GLU.gluCylinder(tower, 0.2, 0.1, height+0.2, 64, 1);

            GL.glColor3f(red / 1.1f, green / 1.1f, blue / 1.1f);

            GL.glTranslated(0.0, 0.0, height+0.3);
            GLUquadric cabin = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(cabin, GLU.GLU_FILL);
            GLUT.glutSolidCube(0.2);

            GL.glColor3f(red / 1.2f, green / 1.2f, blue / 1.2f);
            GL.glRotated(90, 1, 0, 0);
            GL.glTranslated(0.0, 0.0, 0.1);

            GLU.glPushMatrix();
            GLU.glPushMatrix();
            GLU.glPushMatrix();
            GLU.glPushMatrix();

            GL.glTranslated(0.04, -0.04, 0);
            GLUquadric link1 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(link1, GLU.GLU_FILL);
            GLU.gluCylinder(link1, 0.02, 0.02, armLength + 0.2, 64, 1);

            GLU.glPopMatrix();
            GL.glTranslated(-0.04, -0.04, 0);
            GLUquadric link2 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(link2, GLU.GLU_FILL);
            GLU.gluCylinder(link2, 0.02, 0.02, armLength + 0.2, 64, 1);

            GLU.glPopMatrix();
            GL.glTranslated(0, 0.04, 0);
            GLUquadric link3 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(link3, GLU.GLU_FILL);
            GLU.gluCylinder(link3, 0.02, 0.02, armLength + 0.2, 64, 1);

            GLU.glPopMatrix();
            GL.glTranslated(0.0, 0.0, armLength + 0.3);
            GL.glColor3f(red / 1.1f, green / 1.1f, blue / 1.1f);
            GLUquadric endLink = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(endLink, GLU.GLU_FILL);
            GLUT.glutSolidCube(0.2);
            
            GLU.glPopMatrix();
            GL.glTranslated(0.0, 0.0, armPosition + 0.1);
            GL.glColor3f(red * 1.15f, green * 1.15f, blue * 1.15f);
            GLUquadric link = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(link, GLU.GLU_FILL);
            GLUT.glutSolidCube(0.2);
            
            GL.glRotated(90, 1, 0, 0);
            GL.glTranslated(0.0, 0.0, 0.1);
            GLUquadric rope = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(rope, GLU.GLU_FILL);
            GLU.gluCylinder(rope, 0.02, 0.02, 1, 64, 1);
        }
    }
}
