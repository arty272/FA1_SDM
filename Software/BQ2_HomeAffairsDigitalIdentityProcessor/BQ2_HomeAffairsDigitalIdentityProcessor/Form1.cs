using BQ2_HomeAffairsDigitalIdentityProcessor;
using System;
using System.Windows.Forms;

namespace BQ2_HomeAffairsDigitalIdentityProcessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Validate ID Button – shows result in separate notification label
        private void BtnValidateID_Click(object sender, EventArgs e)
        {
            // Clear previous validation message
            lblValidationResult.Text = "";
            txtProfileSummary.Clear();

            string name = txtFullName.Text.Trim();
            string id = txtIDNumber.Text.Trim();
            string citizenship = cmbCitizenship.SelectedItem?.ToString();

            // Basic empty checks
            if (string.IsNullOrWhiteSpace(name))
            {
                lblValidationResult.Text = "Error: Full Name is required.";

                return;
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                lblValidationResult.Text = "Error: ID Number is required.";

                return;
            }
            if (string.IsNullOrWhiteSpace(citizenship))
            {
                lblValidationResult.Text = "Error: Please select Citizenship status.";

                return;
            }

            // Create profile and validate
            CitizenProfile profile = new CitizenProfile(name, id, citizenship);
            string validationMsg = profile.ValidateID();

            // Display validation result in the separate notification window
            lblValidationResult.Text = validationMsg;
            if (validationMsg.StartsWith("Valid"))
                lblValidationResult.ForeColor = System.Drawing.Color.DarkGreen;
            else
                lblValidationResult.ForeColor = System.Drawing.Color.DarkRed;
        }

        // Generate Profile Button – builds complete summary with timestamp
        private void BtnGenerateProfile_Click(object sender, EventArgs e)
        {
            txtProfileSummary.Clear();

            string name = txtFullName.Text.Trim();
            string id = txtIDNumber.Text.Trim();
            string citizenship = cmbCitizenship.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(citizenship))
            {
                txtProfileSummary.Text = "Please fill in all fields and validate the ID first.";
                return;
            }

            CitizenProfile profile = new CitizenProfile(name, id, citizenship);
            string validationResult = profile.ValidateID();
            string timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            // Build formatted profile summary exactly like the screenshot example
            string summary = "***** DIGITAL CITIZEN SUMMARY *****\r\n" +
                             $"Name: {profile.FullName}\r\n" +
                             $"ID Number: {profile.IDNumber}\r\n" +
                             $"Age: {(profile.Age > 0 ? profile.Age.ToString() : "Invalid")}\r\n" +
                             $"Citizenship: {profile.CitizenshipStatus}\r\n" +
                             $"Validation: {validationResult}\r\n" +
                             "Processed at: Home Affairs Digital Desk\r\n" +
                             $"Timestamp: {timestamp}\r\n" +
                             "*************************************";

            txtProfileSummary.Text = summary;
        }
    }
}