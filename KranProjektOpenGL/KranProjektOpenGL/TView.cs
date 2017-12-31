using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CsGL.OpenGL;
using System.Windows.Forms;

namespace KranProjektOpenGL
{
    public partial class TView : OpenGLControl
    {
        TKran kran = new TKran();

        /// <summary>
        /// hier wird gezeichnet
        /// </summary>
        public void drawScene()
        {
            // Verschieben des Koordinatensystems um -6 in Z-Richtung
            // also "nach hinten"
            // und kippen nach Oben

            //coordinateSystem(2);

            GL.glTranslated(0.0, 0.0, -6.0);

            coordinateSystem(1);
            
            createBase(3, 0.2, System.Drawing.ColorTranslator.FromHtml("#44DD44"));
            kran.draw();

            /*
            GL.glRotated(arm1rot[0], 1, 0, 0);
            GL.glRotated(arm1rot[1], 0, 1, 0);
            GL.glRotated(arm1rot[2], 0, 0, 1);
            GL.glColor3f(0.4f, 0.4f, 1.0f);
            GLUquadric link3 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(link3, GLU.GLU_LINE);
            GLU.gluSphere(link3, 0.2, 8, 8);

            GL.glTranslated(0.0, 0.0, -1.0);

            // Zylinderobjekt erzeugen
            GL.glColor3f(0.0f, 0.0f, 1.0f);
            GLUquadric arm1 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(arm1, GLU.GLU_LINE);
            GLU.gluCylinder(arm1, 0.2, 0.2, 1, 20, 10);

            // Zylinderobjekt erzeugen
            GL.glRotated(arm2rot[0], 1, 0, 0);
            GL.glRotated(arm2rot[1], 0, 1, 0);
            GL.glRotated(arm2rot[2], 0, 0, 1);
            GL.glColor3f(0.4f, 0.4f, 1.0f);
            GLUquadric link1 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(link1, GLU.GLU_LINE);
            GLU.gluSphere(link1, 0.2, 8, 8);

            GL.glRotated(-120, 1, 0, 0);
            GL.glColor3f(0.0f, 0.0f, 1.0f);
            GLUquadric arm2 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(arm2, GLU.GLU_LINE);
            GLU.gluCylinder(arm2, 0.2, 0.2, 1, 20, 10);

            GL.glTranslated(0.0, 0.0, 1.0);

            GL.glColor3f(0.4f, 0.4f, 1.0f);
            GLUquadric link2 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(link2, GLU.GLU_LINE);
            GLU.gluSphere(link2, 0.2, 8, 8);

            GLU.glPushMatrix();
            GLU.glPushMatrix();
            GLU.glPushMatrix();
            GLU.glPushMatrix();
            GLU.glPushMatrix();

            double fingerswidth = 0.03;

            GLU.glPopMatrix();
            GL.glRotated(45, 1, 0, 0);
            GL.glColor3f(1.0f, 0.4f, 0.4f);
            GLUquadric finger1 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(finger1, GLU.GLU_LINE);
            GLU.gluCylinder(finger1, fingerswidth, fingerswidth, 0.3, 20, 10);

            GL.glTranslated(0.0, 0.0, 0.3);
            GL.glColor3f(0.4f, 0.4f, 1.0f);
            GLUquadric fingerlink1 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(fingerlink1, GLU.GLU_LINE);
            GLU.gluSphere(fingerlink1, fingerswidth, 8, 8);
            
            GL.glColor3f(1.0f, 0.4f, 0.4f);
            GLUquadric finger1p2 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(finger1p2, GLU.GLU_LINE);
            GLU.gluCylinder(finger1p2, fingerswidth, fingerswidth, 0.1, 20, 10);

            GL.glTranslated(0.0, 0.0, 0.1);
            GL.glColor3f(0.4f, 0.4f, 1.0f);
            GLUquadric fingerlink1p2 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(fingerlink1p2, GLU.GLU_LINE);
            GLU.gluSphere(fingerlink1p2, fingerswidth, 8, 8);

            for (int i = 0; i < 4; i++)
            {
                int startdegree = -15;
                int degree = startdegree + 15 * i;

                GLU.glPopMatrix();
                GL.glRotated(degree, 1, 0, 0);
                GL.glColor3f(1.0f, 0.4f, 0.4f);
                GLUquadric finger2 = GL.gluNewQuadric();
                GLU.gluQuadricDrawStyle(finger2, GLU.GLU_LINE);
                GLU.gluCylinder(finger2, fingerswidth, fingerswidth, 0.3, 20, 10);

                GL.glTranslated(0.0, 0.0, 0.3);
                GL.glRotated(finger1rot[i], 0, 1, 0);
                GL.glColor3f(0.4f, 0.4f, 1.0f);
                GLUquadric fingerlink2 = GL.gluNewQuadric();
                GLU.gluQuadricDrawStyle(fingerlink2, GLU.GLU_LINE);
                GLU.gluSphere(fingerlink2, fingerswidth, 8, 8);

                GL.glRotated(-degree, 1, 0, 0);
                GL.glColor3f(1.0f, 0.4f, 0.4f);
                GLUquadric finger2p2 = GL.gluNewQuadric();
                GLU.gluQuadricDrawStyle(finger2p2, GLU.GLU_LINE);
                GLU.gluCylinder(finger2p2, fingerswidth, fingerswidth, 0.1, 20, 10);

                GL.glTranslated(0.0, 0.0, 0.1);
                GL.glRotated(finger2rot[i], 0, 1, 0);
                GL.glColor3f(0.4f, 0.4f, 1.0f);
                GLUquadric fingerlink2p2 = GL.gluNewQuadric();
                GLU.gluQuadricDrawStyle(fingerlink2p2, GLU.GLU_LINE);
                GLU.gluSphere(fingerlink2p2, fingerswidth, 8, 8);

                GL.glColor3f(1.0f, 0.4f, 0.4f);
                GLUquadric finger2p3 = GL.gluNewQuadric();
                GLU.gluQuadricDrawStyle(finger2p3, GLU.GLU_LINE);
                GLU.gluCylinder(finger2p3, fingerswidth, fingerswidth, 0.1, 20, 10);

                GL.glTranslated(0.0, 0.0, 0.1);
                GL.glColor3f(0.4f, 0.4f, 1.0f);
                GLUquadric fingerlink2p3 = GL.gluNewQuadric();
                GLU.gluQuadricDrawStyle(fingerlink2p3, GLU.GLU_LINE);
                GLU.gluSphere(fingerlink2p3, fingerswidth, 8, 8);
            }
            */
        }

        private void createBase(double radius, double height, System.Drawing.Color color)
        {
            float red = (float)color.R / 255;
            float green = (float)color.G / 255;
            float blue = (float)color.B / 255;

            GL.glColor3f(red * 1.15f, green * 1.15f, blue * 1.15f);
            GLUquadric ground = GL.gluNewQuadric();
            GLU.gluCylinder(ground, radius, radius, height, 64, 1);
            GLU.gluQuadricDrawStyle(ground, GLU.GLU_FILL);

            GL.glColor3f(red, green, blue);

            GLUquadric groundpanel = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(groundpanel, GLU.GLU_FILL);
            GLU.gluDisk(groundpanel, 0, radius, 64, 2);

            GL.glTranslated(0.0, 0.0, height);

            GL.glColor3f(red / 1.15f, green / 1.15f, blue / 1.15f);

            GLUquadric groundpanel2 = GL.gluNewQuadric();
            GLU.gluQuadricDrawStyle(groundpanel2, GLU.GLU_FILL);
            GLU.gluDisk(groundpanel2, height, radius, 64, 2);
        }

        /// <summary>
        /// OpenGL View
        /// </summary>
        public TView()
        {
            InitializeComponent();

            // zum Navigieren mit der Maus
            matrix = new float[16];
            matrixNavi = new float[16];
            matrixNaviStart = new float[16];
            noClear = false;

            MouseWheel += new MouseEventHandler(this.specialOGLControl_MouseWheel);
            MouseMove += new MouseEventHandler(this.specialOGLControl_MouseMove);
            MouseDown += new MouseEventHandler(this.specialOGLControl_MouseDown);
            MouseUp += new MouseEventHandler(this.specialOGLControl_MouseUp);

            KeyDown += new KeyEventHandler(specialOGLControl_KeyDown);

        }

        public TView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void InitGLContext()
        {
            // ein paar Einstellungen
            GL.glClearColor(0, 0, 0, 0);
            GL.glEnable(GL.GL_DEPTH_TEST);
            GL.glDepthFunc(GL.GL_LESS);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();
            GL.glGetFloatv(GL.GL_MODELVIEW_MATRIX, matrix);
            Refresh();
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            GL.glViewport(0, 0, this.Bounds.Width, this.Bounds.Height);
            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glLoadIdentity();
            GL.gluPerspective(45.0f, (float)this.Bounds.Width / (float)this.Bounds.Height, 0.1f, 500.0f);
            GL.glMatrixMode(GL.GL_MODELVIEW);
        }

        public override void glDraw()
        {
            if (!noClear)
            {
                clear();
                noClear = false;
            }

            GL.glLoadMatrixf(matrix);

            drawNoClear();

            OnSizeChanged(null);
        }

        void coordinateSystem(double faktor)
        {
            if (drawCoordinateSystem)
            {
                double triangleFaktor = faktor * 0.1;
                // X - Axis red
                GL.glBegin(GL.GL_LINES);
                GL.glColor3d(1.0, 0.0, 0.0);
                GL.glVertex3d(0.0, 0.0, 0.0);
                GL.glVertex3d(faktor, 0.0, 0.0);
                GL.glEnd();

                GL.glBegin(GL.GL_TRIANGLES);
                GL.glVertex3d(faktor + triangleFaktor, 0.0, 0.0);
                GL.glVertex3d(faktor, triangleFaktor, 0.0);
                GL.glVertex3d(faktor, -triangleFaktor, 0.0);
                GL.glEnd();


                // Y - Axis green
                GL.glBegin(GL.GL_LINES);
                GL.glColor3d(0.0, 1.0, 0.0);
                GL.glVertex3d(0.0, 0.0, 0.0);
                GL.glVertex3d(0.0, faktor, 0.0);
                GL.glEnd();

                GL.glBegin(GL.GL_TRIANGLES);
                GL.glVertex3d(0.0, faktor + triangleFaktor, 0.0);
                GL.glVertex3d(0.0, faktor, triangleFaktor);
                GL.glVertex3d(0.0, faktor, -triangleFaktor);
                GL.glEnd();


                // Z - Axis blue
                GL.glBegin(GL.GL_LINES);
                GL.glColor3d(0.0, 0.0, 1.0);
                GL.glVertex3d(0.0, 0.0, 0.0);
                GL.glVertex3d(0.0, 0.0, faktor);
                GL.glEnd();

                GL.glBegin(GL.GL_TRIANGLES);
                GL.glVertex3d(0.0, 0.0, faktor + triangleFaktor);
                GL.glVertex3d(0.0, triangleFaktor, faktor);
                GL.glVertex3d(0.0, -triangleFaktor, faktor);
                GL.glEnd();
            }
        }

        public void changeVal(int obj, int val)
        {
            if (obj == 1) { kran.targetAngle = val; };
            if (obj == 2) { kran.targetArmPosition = (double)val / 20; };
            Refresh();
        }

        // Attribute für den "Drehwürfel"
        int xAngle, yAngle, xDelta, yDelta, zDelta;
        bool noClear;

        float[] matrix;
        float[] matrixNavi;
        float[] matrixNaviStart;

        bool drawCoordinateSystem = false;

        void clear()
        {
            GL.glClearColor(0.2f, 0.2f, 0.2f, 1.0f);
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.glMatrixMode(GL.GL_MODELVIEW);
        }

        void drawNoClear()
        {
            drawScene();
        }

        void specialOGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            xAngle = e.X;
            yAngle = e.Y;
            xDelta = e.X;
            yDelta = e.Y;
            zDelta = e.Y;

            // komplette Transformationsmatrix laden (History)
            GL.glLoadMatrixf(matrix);

            // in NaviStart kopieren
            GL.glGetFloatv(GL.GL_MODELVIEW_MATRIX, matrixNaviStart);

            // für die aktuelle Transformation zurück auf 0
            GL.glLoadIdentity();

            if (e.Button == MouseButtons.Middle)
            {
                // Reset der History

                GL.glGetFloatv(GL.GL_MODELVIEW_MATRIX, matrix);
                noClear = false;
                Refresh();
            }

        }

        // Abhier die Mouse-Events zum Transformieren der Szene

        void specialOGLControl_MouseWheel(object sender, MouseEventArgs e)
        {
            GL.glLoadIdentity();

            // Delta ist Mausradbewegung
            GL.glTranslated(0, 0, e.Delta / 200.0);

            // Verschiebung ist jetzt in der MVM
            // MVM nach History
            GL.glMultMatrixf(matrix);

            // neue Transformation in die History schreiben
            GL.glGetFloatv(GL.GL_MODELVIEW_MATRIX, matrix);

            noClear = false;
            Refresh();
        }

        void specialOGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            // Zurück auf Null
            GL.glLoadIdentity();

            // Verschiebung
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // alte Szene löschen
                clear();

                // Schritt nach hinten
                GL.glTranslated(0, 0, -6);

                // Absolute Verschiebung rel zu MouseDown
                GL.glTranslated((e.X - xDelta) / 100.0, 0, 0);
                GL.glTranslated(0, -(e.Y - yDelta) / 100.0, 0);

                // Orientierungswürfel und wieder Schritt vor
                mouseRotateCube();
                GL.glTranslated(0, 0, 6);
            }
            // Rotieren
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // alte Szene löschen
                clear();

                // Schritt nach hinten
                GL.glTranslated(0, 0, -6);

                // Rotieren rel zu MouseDown
                GL.glRotated((e.X - xAngle), 0, 1, 0);
                GL.glRotated((e.Y - yAngle), 1, 0, 0);

                // Orientierungswürfel und Schritt vor
                mouseRotateCube();
                GL.glTranslated(0, 0, +6);
            }

            // Wenn links oder rechts gedrückt wurde
            if (e.Button == System.Windows.Forms.MouseButtons.Right
                ||
                e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Matrix, die durch die Gesamttransformation bisher entstanden ist
                // in matrixNavi speichern
                GL.glGetFloatv(GL.GL_MODELVIEW_MATRIX, matrixNavi);

                // MNavi nach MNaviStart
                GL.glMultMatrixf(matrixNaviStart);

                // und alles in der History sichern
                GL.glGetFloatv(GL.GL_MODELVIEW_MATRIX, matrix);

                // Szene nicht löschen, da sonst Orientierungswürfel weg
                noClear = true;
                Refresh();
            }
        }

        void specialOGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            // Am Ende der Transformation Szene ohne Würfel neu zeichnen
            noClear = false;
            Refresh();
        }

        void specialOGLControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                drawCoordinateSystem = !drawCoordinateSystem;

            Refresh();
        }

        void mouseRotateCube()
        {
            double d = 0.5;
            byte[] raster =
                new byte[128];

            // Rastert die Fronflaeche des Wuerfels
            // Initialisieren mit 	01010101...
            //						10101010...

            GL.glColor3f(0.5f, 0.5f, 0.3f);
            GLUT.glutWireCube(2.0 * d);

            for (int i = 0; i < 128; i++)
            {
                raster[i] = ((i / 4) % 2 != 0) ? (byte)85 : (byte)170;
            }


            GL.glPolygonStipple(raster);
            GL.glEnable(GL.GL_POLYGON_STIPPLE);

            GL.glBegin(GL.GL_QUADS);
            GL.glVertex3d(-d, -d, d);
            GL.glVertex3d(-d, d, d);
            GL.glVertex3d(d, d, d);
            GL.glVertex3d(d, -d, d);
            GL.glEnd();

            GL.glDisable(GL.GL_POLYGON_STIPPLE);
        }
    }
}
