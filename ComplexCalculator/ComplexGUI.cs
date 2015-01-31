using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComplexCalculator
{
    public partial class ComplexGUI : Form
    {
        // Variable declaration
        ComplexNumber n1, n2, result, result2;
        
        public ComplexGUI()
        {
            InitializeComponent();
            // Nullify result2 in case the operation is not a conjugate
            this.result2 = null; 
        }

        // On eqButton is clicked
        private void equalsButton_Click(object sender, EventArgs e)
        {
            // Check if any of the input boxes are empty
            if ((firstTextbox.Text == "") || (secondTextbox.Text == ""))
            {
                MessageBox.Show("You must fill both operand textboxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Try and parse the operands
                try
                {
                    this.n1 = ComplexNumber.ParseFromString(firstTextbox.Text);
                    this.n2 = ComplexNumber.ParseFromString(secondTextbox.Text);
                    
                    // The following logic will only be ran if the parsing has succeeded
                    switch (operatorsBox.SelectedItem.ToString())
                    {
                        case "+":
                            this.result = this.n1 + this.n2;
                            break;
                        case "-":
                            this.result = this.n1 - this.n2;
                            break;
                        case "*":
                            this.result = this.n1 * this.n2;
                            break;
                        case "conjugate":
                            this.result = this.n1.Conjugate();
                            this.result2 = this.n2.Conjugate();
                            break;
                        default:
                            this.result = null;
                            break;
                    }
                    if ((this.result != null) && (this.result2 != null))
                    {
                        resultLabel.Text = this.result + ", " + this.result2;
                    }
                    else if ((this.result != null) && (this.result2 == null))
                    {
                        resultLabel.Text = this.result.ToString();
                    }
                    else
                    {
                        resultLabel.ForeColor = Color.Red;
                        resultLabel.Text = "Error";
                    }
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Your input doesn't follow the model: a +/- bi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutComplexCalculator abDialog = new AboutComplexCalculator();
            abDialog.Show();
        }
    }
}
