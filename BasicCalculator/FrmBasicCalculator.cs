using System;
using System.Windows.Forms;
using CalculatorPrivateAssembly; 

namespace BasicCalculator
{
    public partial class FrmBasicCalculator : Form
    {
        public FrmBasicCalculator()
        {
            InitializeComponent();
            cboOperator.SelectedIndex = 0; 
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            float num1;
            float num2;

            if (!float.TryParse(txtNumber1.Text, out num1) ||
                !float.TryParse(txtNumber2.Text, out num2))
            {
                MessageBox.Show("Please enter valid numbers.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float result = 0;

            switch (cboOperator.Text)
            {
                case "+":
                    result = BasicComputation.Addition(num1, num2);
                    break;
                case "-":
                    result = BasicComputation.Subtraction(num1, num2);
                    break;
                case "*":
                    result = BasicComputation.Multiplication(num1, num2);
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        MessageBox.Show("Cannot divide by zero.", "Math Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    result = BasicComputation.Division(num1, num2);
                    break;
                default:
                    MessageBox.Show("Please select an operator.", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            lblTotal.Text = result.ToString();
        }
    }
}
