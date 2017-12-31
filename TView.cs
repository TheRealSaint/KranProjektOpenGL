using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CsGL.OpenGL;
using System.Windows.Forms;

namespace DemoOpenGLBasicsCS
{
    public partial class TView : OpenGLControl
    {
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
            
            GL.glRotated(90, 1, 0, 0);
            //coordinateSystem(0.5);

            coordinateSystem(1);

            // Zylinderobjekt erzeugen
            GLUquadric zylinder = GL.gluNewQuadric();

            // Zeicheneigenschaften einstellen:
            // Drahtgittermodell
            GLU.gluQuadricDrawStyle(zylinder, GLU.GLU_LINE);

            // ab jetzt in blau zeichnen
            GL.glColor3f(0.0f, 0.0f, 1.0f);

            // Zeichnen eines Zylinders
            // bottom-Durchmesser, top-Durchmesser, Höhe,
            // Anzahl der Linien-Segmente
            // Anzahl der Linien in der Höhe

            // Hier wird die Haupt-Kran Achse gezeichnet
            GLU.gluCylinder(zylinder, 0.2, 0.2, 2, 200, 100);

            //TESTBEREICH MAGENTA ZYLINDER2
            GL.glTranslated(0.0, 0.0, 0.0);
            GL.glRotated(120, 0, 1, 0);
            GL.glColor3f(1.0f, 0.0f, 1.0f);
            GLUquadric zylinder2 = GL.gluNewQuadric();
            GLU.gluCylinder(zylinder2, 0.1, 0.1, 1.5, 20, 10);

            //TESTBEREICH GRÜNER ZYLINDER3
            GL.glTranslated(0.0, 0.0, 1.5);
            GL.glRotated(-60, 0, 1, 0);
            GL.glColor3f(0.0f, 1.0f, 0.0f);
            GLUquadric zylinder3 = GL.gluNewQuadric();
            GLU.gluCylinder(zylinder3, 0.1, 0.1, 1.5, 20, 10);
            
            //TESTBEREICH ROTER ZYLINDER4
            GL.glTranslated(0.0, 0.0, 1.5);
            GL.glRotated(-60, 0, 1, 0);
            GL.glColor3f(1.0f, 0.0f, 0.0f);
            GLUquadric zylinder4 = GL.gluNewQuadric();
            GLU.gluCylinder(zylinder4, 0.01, 0.01, 1.0, 20, 10);

            //TESTBEREICH GELBE KUGEL
            GL.glTranslated(0.0, 0.0, 1.5);
            GL.glRotated(0, 0, 0, 0);
            GL.glColor3f(0.50f, 0.50f, 0.50f);
            GLUT.glutWireSphere(0.5, 100, 150);
                        

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
