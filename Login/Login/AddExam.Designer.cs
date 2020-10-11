namespace Login
{
    partial class AddExam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btncancel = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnaddexam = new MaterialSkin.Controls.MaterialFlatButton();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(52, 85);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(80, 29);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Date :";
            // 
            // btncancel
            // 
            this.btncancel.AutoSize = true;
            this.btncancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btncancel.Depth = 0;
            this.btncancel.Icon = null;
            this.btncancel.Location = new System.Drawing.Point(224, 364);
            this.btncancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btncancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btncancel.Name = "btncancel";
            this.btncancel.Primary = false;
            this.btncancel.Size = new System.Drawing.Size(87, 36);
            this.btncancel.TabIndex = 6;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // btnaddexam
            // 
            this.btnaddexam.AutoSize = true;
            this.btnaddexam.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnaddexam.Depth = 0;
            this.btnaddexam.Icon = null;
            this.btnaddexam.Location = new System.Drawing.Point(143, 364);
            this.btnaddexam.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnaddexam.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnaddexam.Name = "btnaddexam";
            this.btnaddexam.Primary = false;
            this.btnaddexam.Size = new System.Drawing.Size(56, 36);
            this.btnaddexam.TabIndex = 7;
            this.btnaddexam.Text = "Add";
            this.btnaddexam.UseVisualStyleBackColor = true;
            this.btnaddexam.Click += new System.EventHandler(this.btnaddexam_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(157, 96);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // AddExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 461);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.btnaddexam);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddExam";
            this.Text = "AddExam";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private MaterialSkin.Controls.MaterialFlatButton btncancel;
        private MaterialSkin.Controls.MaterialFlatButton btnaddexam;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}