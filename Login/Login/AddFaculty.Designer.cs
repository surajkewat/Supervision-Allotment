namespace Login
{
    partial class AddFaculty
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbfac1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtfac1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dpfac1 = new Bunifu.Framework.UI.BunifuDropdown();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtfac2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.addfacbutton = new MaterialSkin.Controls.MaterialFlatButton();
            this.bfac2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.experience_valid = new System.Windows.Forms.Label();
            this.addmorefacbutton = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // lbfac1
            // 
            this.lbfac1.AutoSize = true;
            this.lbfac1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfac1.Location = new System.Drawing.Point(77, 92);
            this.lbfac1.Name = "lbfac1";
            this.lbfac1.Size = new System.Drawing.Size(205, 29);
            this.lbfac1.TabIndex = 0;
            this.lbfac1.Text = "Name of Faculty:";
            // 
            // txtfac1
            // 
            this.txtfac1.Depth = 0;
            this.txtfac1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfac1.Hint = "FULL NAME";
            this.txtfac1.Location = new System.Drawing.Point(319, 92);
            this.txtfac1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfac1.MaxLength = 32767;
            this.txtfac1.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtfac1.Name = "txtfac1";
            this.txtfac1.PasswordChar = '\0';
            this.txtfac1.SelectedText = "";
            this.txtfac1.SelectionLength = 0;
            this.txtfac1.SelectionStart = 0;
            this.txtfac1.Size = new System.Drawing.Size(323, 28);
            this.txtfac1.TabIndex = 1;
            this.txtfac1.TabStop = false;
            this.txtfac1.UseSystemPasswordChar = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(77, 206);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(152, 29);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "Department:";
            // 
            // dpfac1
            // 
            this.dpfac1.BackColor = System.Drawing.Color.Transparent;
            this.dpfac1.BorderRadius = 3;
            this.dpfac1.DisabledColor = System.Drawing.Color.Gray;
            this.dpfac1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpfac1.ForeColor = System.Drawing.Color.Gray;
            this.dpfac1.Items = new string[] {
        "CMPN",
        "INFT",
        "EXTC",
        "ETRX",
        "BIOM"};
            this.dpfac1.Location = new System.Drawing.Point(303, 192);
            this.dpfac1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dpfac1.Name = "dpfac1";
            this.dpfac1.NomalColor = System.Drawing.Color.White;
            this.dpfac1.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.dpfac1.selectedIndex = -1;
            this.dpfac1.Size = new System.Drawing.Size(271, 43);
            this.dpfac1.TabIndex = 3;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(83, 313);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(139, 58);
            this.bunifuCustomLabel2.TabIndex = 4;
            this.bunifuCustomLabel2.Text = "Experience\r\n(in years)";
            // 
            // txtfac2
            // 
            this.txtfac2.Depth = 0;
            this.txtfac2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfac2.Hint = "";
            this.txtfac2.Location = new System.Drawing.Point(319, 322);
            this.txtfac2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfac2.MaxLength = 32767;
            this.txtfac2.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtfac2.Name = "txtfac2";
            this.txtfac2.PasswordChar = '\0';
            this.txtfac2.SelectedText = "";
            this.txtfac2.SelectionLength = 0;
            this.txtfac2.SelectionStart = 0;
            this.txtfac2.Size = new System.Drawing.Size(199, 28);
            this.txtfac2.TabIndex = 5;
            this.txtfac2.TabStop = false;
            this.txtfac2.UseSystemPasswordChar = false;
            // 
            // addfacbutton
            // 
            this.addfacbutton.AutoSize = true;
            this.addfacbutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addfacbutton.Depth = 0;
            this.addfacbutton.Icon = null;
            this.addfacbutton.Location = new System.Drawing.Point(732, 434);
            this.addfacbutton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addfacbutton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addfacbutton.Name = "addfacbutton";
            this.addfacbutton.Primary = false;
            this.addfacbutton.Size = new System.Drawing.Size(56, 36);
            this.addfacbutton.TabIndex = 6;
            this.addfacbutton.Text = "ADD";
            this.addfacbutton.UseVisualStyleBackColor = true;
            this.addfacbutton.Click += new System.EventHandler(this.addfacbutton_Click);
            // 
            // bfac2
            // 
            this.bfac2.AutoSize = true;
            this.bfac2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bfac2.Depth = 0;
            this.bfac2.Icon = null;
            this.bfac2.Location = new System.Drawing.Point(796, 434);
            this.bfac2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.bfac2.MouseState = MaterialSkin.MouseState.HOVER;
            this.bfac2.Name = "bfac2";
            this.bfac2.Primary = false;
            this.bfac2.Size = new System.Drawing.Size(87, 36);
            this.bfac2.TabIndex = 6;
            this.bfac2.Text = "CANCEL";
            this.bfac2.UseVisualStyleBackColor = true;            // 
            // experience_valid
            // 
            this.experience_valid.AutoSize = true;
            this.experience_valid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.experience_valid.ForeColor = System.Drawing.Color.Red;
            this.experience_valid.Location = new System.Drawing.Point(548, 325);
            this.experience_valid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.experience_valid.Name = "experience_valid";
            this.experience_valid.Size = new System.Drawing.Size(164, 25);
            this.experience_valid.TabIndex = 7;
            this.experience_valid.Text = "Enter no. of years";
            this.experience_valid.Visible = false;
            // 
            // addmorefacbutton
            // 
            this.addmorefacbutton.AutoSize = true;
            this.addmorefacbutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addmorefacbutton.Depth = 0;
            this.addmorefacbutton.Icon = null;
            this.addmorefacbutton.Location = new System.Drawing.Point(605, 434);
            this.addmorefacbutton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addmorefacbutton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addmorefacbutton.Name = "addmorefacbutton";
            this.addmorefacbutton.Primary = false;
            this.addmorefacbutton.Size = new System.Drawing.Size(107, 36);
            this.addmorefacbutton.TabIndex = 6;
            this.addmorefacbutton.Text = "ADD More";
            this.addmorefacbutton.UseVisualStyleBackColor = true;
            this.addmorefacbutton.Click += new System.EventHandler(this.addmorefacbutton_Click);
            // 
            // AddFaculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(997, 516);
            this.Controls.Add(this.experience_valid);
            this.Controls.Add(this.bfac2);
            this.Controls.Add(this.addmorefacbutton);
            this.Controls.Add(this.addfacbutton);
            this.Controls.Add(this.txtfac2);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.dpfac1);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.txtfac1);
            this.Controls.Add(this.lbfac1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFaculty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Faculty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel lbfac1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtfac1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuDropdown dpfac1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtfac2;
        private MaterialSkin.Controls.MaterialFlatButton addfacbutton;
        private MaterialSkin.Controls.MaterialFlatButton bfac2;
        private System.Windows.Forms.Label experience_valid;
        private MaterialSkin.Controls.MaterialFlatButton addmorefacbutton;
    }
}
