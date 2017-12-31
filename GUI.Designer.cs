namespace DemoOpenGLBasicsCS
{
   partial class GUI
   {
      /// <summary>
      /// Erforderliche Designervariable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Verwendete Ressourcen bereinigen.
      /// </summary>
      /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Vom Windows Form-Designer generierter Code

      /// <summary>
      /// Erforderliche Methode für die Designerunterstützung.
      /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
      /// </summary>
      private void InitializeComponent()
      {
          this.panel = new System.Windows.Forms.Panel();
          this.SuspendLayout();
          // 
          // panel
          // 
          this.panel.Location = new System.Drawing.Point(12, 12);
          this.panel.Name = "panel";
          this.panel.Size = new System.Drawing.Size(741, 480);
          this.panel.TabIndex = 0;
          // 
          // GUI
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(765, 504);
          this.Controls.Add(this.panel);
          this.Name = "GUI";
          this.Text = "OpenGL Demo";
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel;
   }
}

