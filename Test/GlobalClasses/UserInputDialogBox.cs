using System;
using System.Windows.Forms;
using System.Drawing;

namespace Test.GlobalClasses
{
    class UserInputDialogBox
    {

        // Initialize the boxInput variable which will be referenced by the custom boxInput dialog box
        public static string boxInput = ".....";


        public static System.Windows.Forms.DialogResult ShowInputDialogBox (
                                                        string userInput = " ",
                                                        string boxTitle = " ", 
                                                        int boxWidth = 0,
                                                        int boxHeight = 0, 
                                                        string boxPrompt = " "
                                                       )
        {
            if (userInput is null)
            {
                throw new ArgumentNullException(nameof(userInput));
            }

            if (string.IsNullOrEmpty(boxPrompt))
            {
                throw new ArgumentException($"'{nameof(boxPrompt)}' cannot be null or empty.", nameof(boxPrompt));
            }

            if (string.IsNullOrEmpty(boxTitle))
            {
                throw new ArgumentException($"'{nameof(boxTitle)}' cannot be null or empty.", nameof(boxTitle));
            }
            // creates the different boxInput elements and adds them to the dialog box

            System.Console.WriteLine("Show Input Dialog Box method begins");

            // Specify the boxSize of the window using the parameters passed
            Size boxSize = new Size(boxWidth, boxHeight);

            // Create a new form using a System.Windows Form
            Form inputBox = new Form();

            inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputBox.ClientSize = boxSize;

            // Set the window boxTitle 
            inputBox.Text = boxTitle;

            // Create a new boxLabel to hold the boxPrompt
            Label boxLabel = new Label();
            boxLabel.Text = boxPrompt;
            boxLabel.Location = new Point(5, 5);
            boxLabel.Width = boxSize.Width - 10;
            inputBox.Controls.Add(boxLabel);

            // Create a textbox to accept the user's boxInput
            System.Windows.Forms.TextBox textField = new System.Windows.Forms.TextBox();
            textField.Size = new Size(boxSize.Width - 10, 23);
            textField.Location = new Point(5, boxLabel.Location.Y + 20);
            textField.Text = boxInput;
            inputBox.Controls.Add(textField);

            // Create an OK Button
            Button okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new Point(boxSize.Width - 80 - 80, boxSize.Height - 30);
            inputBox.Controls.Add(okButton);

            // Create a Cancel Button
            Button cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new Point(boxSize.Width - 80, boxSize.Height - 30);
            inputBox.Controls.Add(cancelButton);

            // Set the boxInput box's buttons to the created OK and Cancel Buttons respectively so the window appropriately behaves with the button clicks
            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            // Show the window dialog box
            DialogResult result = inputBox.ShowDialog();
            boxInput = textField.Text;

            // After boxInput has been submitted, return the boxInput value
            return result;
        }

    }
}
