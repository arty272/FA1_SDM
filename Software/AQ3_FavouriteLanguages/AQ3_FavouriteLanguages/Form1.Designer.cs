using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    private Label lblTitle;
    private ListBox lstLanguages;
    private TextBox txtLanguage;
    private Button btnAdd;
    private Button btnRemove;
    private Label lblStatus;

    /// <summary>
    /// Initialize form controls and layout. This mirrors the previous BuildUI method.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new Container();

        this.lblTitle = new Label();
        this.lstLanguages = new ListBox();
        this.txtLanguage = new TextBox();
        this.btnAdd = new Button();
        this.btnRemove = new Button();
        this.lblStatus = new Label();

        // 
        // Form1
        // 
        this.SuspendLayout();
        this.Text = "Favourite Programming Languages";
        this.ClientSize = new Size(520, 420);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;

        // 
        // lblTitle
        // 
        this.lblTitle.Text = "My Favourite Programming Languages";
        this.lblTitle.Font = new Font("Arial", 13F, FontStyle.Bold);
        this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        this.lblTitle.Size = new Size(480, 40);
        this.lblTitle.Location = new Point(10, 15);

        // 
        // lstLanguages
        // 
        this.lstLanguages.Size = new Size(480, 150);
        this.lstLanguages.Location = new Point(10, 65);

        // 
        // txtLanguage
        // 
        
        this.txtLanguage.Size = new Size(480, 30);
        this.txtLanguage.Location = new Point(10, 230);

        // 
        // btnAdd
        // 
        this.btnAdd.Text = "Add Language";
        this.btnAdd.BackColor = Color.Teal;
        this.btnAdd.ForeColor = Color.White;
        this.btnAdd.FlatStyle = FlatStyle.Flat;
        this.btnAdd.Size = new Size(120, 35);
        this.btnAdd.Location = new Point(10, 270);
        this.btnAdd.Click += new EventHandler(this.BtnAdd_Click);

        // 
        // btnRemove
        // 
        this.btnRemove.Text = "Remove";
        this.btnRemove.BackColor = Color.Crimson;
        this.btnRemove.ForeColor = Color.White;
        this.btnRemove.FlatStyle = FlatStyle.Flat;
        this.btnRemove.Size = new Size(100, 35);
        this.btnRemove.Location = new Point(140, 270);
        this.btnRemove.Click += new EventHandler(this.BtnRemove_Click);

        // 
        // lblStatus
        // 
        this.lblStatus.AutoSize = true;
        this.lblStatus.ForeColor = Color.DimGray;
        this.lblStatus.Location = new Point(10, 320);

        // 
        // Controls
        // 
        this.Controls.AddRange(new Control[] {
            this.lblTitle,
            this.lstLanguages,
            this.txtLanguage,
            this.btnAdd,
            this.btnRemove,
            this.lblStatus
        });

        this.ResumeLayout(false);
        this.PerformLayout();
    }

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
}
