using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsGL.OpenGL;

namespace DemoOpenGLBasicsCS
{
    class TKran
    {
        private System.Drawing.Color color = System.Drawing.Color.Gray;
        private double height = 4;
        //private double armLength = 2;

        private int angle = 0;
        private double armLength = 0;
        private double ropeLength = 1.0;
        private double bowlDiameter = 0.5;

        public int targetAngle;
        public double targetArmLength = 1.5;
        public double targetRopeLength = 1.5;
        public double targetBowlDiameter = 0.1;
        

        public TKran()
        {

        }

        /// <summary>
        /// Zeichnet die Objekte
        /// </summary>
        public void draw()
        {
            // Verschieben des Koordinatensystems um -6 in Z-Richtung
            // also "nach hinten"
            // und kippen nach Oben
            GL.glTranslated(0.0, 0.0, -6.0);


            //---------------
            //BLAUER ZYLINDER1
            //Vorgabe der Perspektive (90° auf die X-Achse) für das im folgenden erzeugte Objekt
            GL.glRotated(90, 1, 0, 0);
            
            //lässt den Zylinder (blau) rotieren mithilfe des Schiebereglers
            GL.glRotated(targetAngle, 0, 0, 1);
            
            // Zylinderobjekt erzeugen
            GLUquadric zylinder = GL.gluNewQuadric();
            
            // Zeicheneigenschaften einstellen:
            // Drahtgittermodell
            GLU.gluQuadricDrawStyle(zylinder, GLU.GLU_LINE);
            
            // ab jetzt in blau zeichnen
            GL.glColor3f(0.0f, 0.0f, 1.0f);
            
            // Zeichnen des eigentlichen Zylinders
            // bottom-Durchmesser, top-Durchmesser, Höhe,
            // Anzahl der Linien-Segmente
            // Anzahl der Linien in der Höhe
            GLU.gluCylinder(zylinder, 0.2, 0.2, 2, 200, 100);
            //---------------

            //MAGENTA ZYLINDER2
            GL.glTranslated(0.0, 0.0, 0.0);
            GL.glRotated(120, 0, 1, 0);
            GL.glColor3f(1.0f, 0.0f, 1.0f);
            GLUquadric zylinder2 = GL.gluNewQuadric();
            GLU.gluCylinder(zylinder2, 0.1, 0.1, 1.5, 20, 10);

            //GRÜNER ZYLINDER3
            GL.glTranslated(0.0, 0.0, 1.5);
            GL.glRotated(-60, 0, 1, 0);
            GL.glColor3f(0.0f, 1.0f, 0.0f);
            GLUquadric zylinder3 = GL.gluNewQuadric();
            GLU.gluCylinder(zylinder3, 0.1, 0.1, targetArmLength, 20, 10);

            //ROTER ZYLINDER4
            //GL.glTranslated(0.0, 0.0, targetArmLength); targetArmLength bezieht sich hier auf die Position des Vorgängerobjekts
            GL.glTranslated(0.0, 0.0, targetArmLength);
            GL.glRotated(-60, 0, 1, 0);
            GL.glColor3f(1.0f, 0.0f, 0.0f);
            GLUquadric zylinder4 = GL.gluNewQuadric();
            GLU.gluCylinder(zylinder4, 0.01, 0.01, targetRopeLength, 20, 10);

            //GELBE KUGEL
            //GL.glTranslated(0.0, 0.0, targetRopeLength); targetRopeLength bezieht sich hier auf die Position des Vorgängerobjekts
            GL.glTranslated(0.0, 0.0, targetRopeLength);
            GL.glRotated(0, 0, 0, 0);
            GL.glColor3f(1.0f, 1.00f, 0.00f);
            GLUT.glutWireSphere(targetBowlDiameter, 100, 150);



        }

        //wird zur Zeit noch nicht benutzt - hier würde eine Bodenplatte erzeugt
        //public void createBase(double radius, double height, System.Drawing.Color color)
        //{
        //    float red = (float)color.R / 255;
        //    float green = (float)color.G / 255;
        //    float blue = (float)color.B / 255;

        //    GL.glColor3f(red * 1.15f, green * 1.15f, blue * 1.15f);
        //    GLUquadric ground = GL.gluNewQuadric();
        //    GLU.gluCylinder(ground, radius, radius, height, 64, 1);
        //    GLU.gluQuadricDrawStyle(ground, GLU.GLU_FILL);

        //    GL.glColor3f(red, green, blue);

        //    GLUquadric groundpanel = GL.gluNewQuadric();
        //    GLU.gluQuadricDrawStyle(groundpanel, GLU.GLU_FILL);
        //    GLU.gluDisk(groundpanel, 0, radius, 64, 2);

        //    GL.glTranslated(0.0, 0.0, height);

        //    GL.glColor3f(red / 1.15f, green / 1.15f, blue / 1.15f);

        //    GLUquadric groundpanel2 = GL.gluNewQuadric();
        //    GLU.gluQuadricDrawStyle(groundpanel2, GLU.GLU_FILL);
        //    GLU.gluDisk(groundpanel2, height, radius, 64, 2);
        //}

        //public void drawBeispielcode()
        //{
        //    armLength = targetArmLength;
        //    angle = targetAngle;

        //    float red = (float)color.R / 255;
        //    float green = (float)color.G / 255;
        //    float blue = (float)color.B / 255;
        //    GL.glColor3f(red, green, blue);

        //    GL.glRotated(angle, 0, 0, 1);
        //    GLUquadric tower = GL.gluNewQuadric();
        //    GLU.gluQuadricDrawStyle(tower, GLU.GLU_FILL);
        //    GLU.gluCylinder(tower, 0.2, 0.1, height+0.2, 64, 1);

        //    GL.glColor3f(red / 1.1f, green / 1.1f, blue / 1.1f);

        //    GL.glTranslated(0.0, 0.0, height+0.3);
        //    GLUquadric cabin = GL.gluNewQuadric();
        //    GLU.gluQuadricDrawStyle(cabin, GLU.GLU_FILL);
        //    GLUT.glutSolidCube(0.2);

        //    GL.glColor3f(red / 1.2f, green / 1.2f, blue / 1.2f);
        //    GL.glRotated(90, 1, 0, 0);
        //    GL.glTranslated(0.0, 0.0, 0.1);

        //    GLU.glPushMatrix();
        //    GLU.glPushMatrix();
        //    GLU.glPushMatrix();
        //    GLU.glPushMatrix();

        //    GL.glTranslated(0.04, -0.04, 0);
        //    GLUquadric link1 = GL.gluNewQuadric();
        //    GLU.gluQuadricDrawStyle(link1, GLU.GLU_FILL);
        //    GLU.gluCylinder(link1, 0.02, 0.02, armLength + 0.2, 64, 1);

        //    GLU.glPopMatrix();
        //    GL.glTranslated(-0.04, -0.04, 0);
        //    GLUquadric link2 = GL.gluNewQuadric();
        //    GLU.gluQuadricDrawStyle(link2, GLU.GLU_FILL);
        //    GLU.gluCylinder(link2, 0.02, 0.02, armLength + 0.2, 64, 1);

        //    GLU.glPopMatrix();
        //    GL.glTranslated(0, 0.04, 0);
        //    GLUquadric link3 = GL.gluNewQuadric();
        //    GLU.gluQuadricDrawStyle(link3, GLU.GLU_FILL);
        //    GLU.gluCylinder(link3, 0.02, 0.02, armLength + 0.2, 64, 1);

        //    GLU.glPopMatrix();
        //    GL.glTranslated(0.0, 0.0, armLength + 0.3);
        //    GL.glColor3f(red / 1.1f, green / 1.1f, blue / 1.1f);
        //    GLUquadric endLink = GL.gluNewQuadric();
        //    GLU.gluQuadricDrawStyle(endLink, GLU.GLU_FILL);
        //    GLUT.glutSolidCube(0.2);
            
        //    GLU.glPopMatrix();
        //    GL.glTranslated(0.0, 0.0, armLength + 0.1);
        //    GL.glColor3f(red * 1.15f, green * 1.15f, blue * 1.15f);
        //    GLUquadric link = GL.gluNewQuadric();
        //    GLU.gluQuadricDrawStyle(link, GLU.GLU_FILL);
        //    GLUT.glutSolidCube(0.2);
            
        //    GL.glRotated(90, 1, 0, 0);
        //    GL.glTranslated(0.0, 0.0, 0.1);
        //    GLUquadric rope = GL.gluNewQuadric();
        //    GLU.gluQuadricDrawStyle(rope, GLU.GLU_FILL);
        //    GLU.gluCylinder(rope, 0.02, 0.02, 1, 64, 1);
        //}
    }
}
