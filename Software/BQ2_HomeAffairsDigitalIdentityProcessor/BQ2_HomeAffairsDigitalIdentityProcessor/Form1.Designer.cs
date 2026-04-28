using System.Reflection;
using System.IO;

namespace BQ2_HomeAffairsDigitalIdentityProcessor
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picSeal;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblIDNumber;
        private System.Windows.Forms.Label lblCitizenship;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtIDNumber;
        private System.Windows.Forms.ComboBox cmbCitizenship;
        private System.Windows.Forms.Button btnValidateID;
        private System.Windows.Forms.Button btnGenerateProfile;
        private System.Windows.Forms.Label lblValidationResult;  // Separate notification window
        private System.Windows.Forms.TextBox txtProfileSummary;  // Multiline profile output

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblTitle = new Label();
            picSeal = new PictureBox();
            lblFullName = new Label();
            lblIDNumber = new Label();
            lblCitizenship = new Label();
            txtFullName = new TextBox();
            txtIDNumber = new TextBox();
            cmbCitizenship = new ComboBox();
            btnValidateID = new Button();
            btnGenerateProfile = new Button();
            lblValidationResult = new Label();
            txtProfileSummary = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picSeal).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(637, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Home Affairs Digital Identity Processor";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picSeal
            // 
            picSeal.Image = (Image)resources.GetObject("picSeal.Image");
            picSeal.Location = new Point(0, -2);
            picSeal.Name = "picSeal";
            picSeal.Size = new Size(497, 638);
            picSeal.TabIndex = 1;
            picSeal.TabStop = false;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(627, 98);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(99, 15);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Enter your Name:";
            // 
            // lblIDNumber
            // 
            lblIDNumber.AutoSize = true;
            lblIDNumber.Location = new Point(627, 138);
            lblIDNumber.Name = "lblIDNumber";
            lblIDNumber.Size = new Size(78, 15);
            lblIDNumber.TabIndex = 4;
            lblIDNumber.Text = "Enter your ID:";
            // 
            // lblCitizenship
            // 
            lblCitizenship.AutoSize = true;
            lblCitizenship.Location = new Point(627, 178);
            lblCitizenship.Name = "lblCitizenship";
            lblCitizenship.Size = new Size(116, 15);
            lblCitizenship.TabIndex = 6;
            lblCitizenship.Text = "Choose your Citizen:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(787, 95);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(250, 23);
            txtFullName.TabIndex = 3;
            // 
            // txtIDNumber
            // 
            txtIDNumber.Location = new Point(787, 135);
            txtIDNumber.Name = "txtIDNumber";
            txtIDNumber.Size = new Size(250, 23);
            txtIDNumber.TabIndex = 5;
            // 
            // cmbCitizenship
            // 
            cmbCitizenship.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCitizenship.Items.AddRange(new object[] { "South African", "Permanent Resident", "Visitor" });
            cmbCitizenship.Location = new Point(787, 175);
            cmbCitizenship.Name = "cmbCitizenship";
            cmbCitizenship.Size = new Size(250, 23);
            cmbCitizenship.TabIndex = 7;
            // 
            // btnValidateID
            // 
            btnValidateID.Location = new Point(754, 216);
            btnValidateID.Name = "btnValidateID";
            btnValidateID.Size = new Size(120, 30);
            btnValidateID.TabIndex = 8;
            btnValidateID.Text = "Validate ID";
            btnValidateID.Click += BtnValidateID_Click;
            // 
            // btnGenerateProfile
            // 
            btnGenerateProfile.Location = new Point(754, 550);
            btnGenerateProfile.Name = "btnGenerateProfile";
            btnGenerateProfile.Size = new Size(140, 30);
            btnGenerateProfile.TabIndex = 9;
            btnGenerateProfile.Text = "Generate Profile";
            btnGenerateProfile.Click += BtnGenerateProfile_Click;
            // 
            // lblValidationResult
            // 

            lblValidationResult.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblValidationResult.Location = new Point(637, 261);
            lblValidationResult.Name = "lblValidationResult";
            lblValidationResult.Size = new Size(380, 40);
            lblValidationResult.TabIndex = 10;
            lblValidationResult.Text = "";
            lblValidationResult.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtProfileSummary
            // 
            txtProfileSummary.BackColor = Color.WhiteSmoke;
            txtProfileSummary.Font = new Font("Consolas", 10F);
            txtProfileSummary.Location = new Point(587, 321);
            txtProfileSummary.Multiline = true;
            txtProfileSummary.Name = "txtProfileSummary";
            txtProfileSummary.ReadOnly = true;
            txtProfileSummary.ScrollBars = ScrollBars.Vertical;
            txtProfileSummary.Size = new Size(496, 200);
            txtProfileSummary.TabIndex = 11;
            // 
            // Form1
            // 
            ClientSize = new Size(1146, 626);
            Controls.Add(lblTitle);
            Controls.Add(picSeal);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblIDNumber);
            Controls.Add(txtIDNumber);
            Controls.Add(lblCitizenship);
            Controls.Add(cmbCitizenship);
            Controls.Add(btnValidateID);
            Controls.Add(btnGenerateProfile);
            Controls.Add(lblValidationResult);
            Controls.Add(txtProfileSummary);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home Affairs Digital Identity Processor";
            ((System.ComponentModel.ISupportInitialize)picSeal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}