using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void BtnAdd_Click(object sender, EventArgs e)
    {
        string lang = txtLanguage.Text.Trim();

        if (string.IsNullOrEmpty(lang))
        {
            MessageBox.Show("Input cannot be empty.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Case-insensitive duplicate check
        foreach (var item in lstLanguages.Items)
        {
            if (item.ToString().Equals(lang, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"'{lang}' already exists in the list.", "Duplicate",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        lstLanguages.Items.Add(lang);
        lblStatus.Text = $"Added '{lang}' at {DateTime.Now:dd MMM yyyy HH:mm:ss}";
        txtLanguage.Clear();
        txtLanguage.Focus();
    }   

    private void BtnRemove_Click(object sender, EventArgs e)
    {
        if (lstLanguages.SelectedItem == null)
        {
            MessageBox.Show("Please select a language to remove.", "Nothing Selected",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        string lang = lstLanguages.SelectedItem.ToString();
        lstLanguages.Items.Remove(lstLanguages.SelectedItem);
        lblStatus.Text = $"Removed '{lang}' at {DateTime.Now:dd MMM yyyy HH:mm:ss}";
    }
}