using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IOA___WinForms
{
    public partial class DialogBox : Form
    {
        public DialogBox()
        {
            InitializeComponent();
        }

        public TextBox TextBoxInput
        {
            get => textBoxInput;
            set => textBoxInput = value;
        }

        public Label LabelInfo
        {
            get => labelInfo;
            set => labelInfo = value;
        }

        public Button ButtonCancel
        {
            get => buttonCancel;
            set => buttonCancel = value;
        }

        public Button ButtonAccept
        {
            get => buttonAccept;
            set => buttonAccept = value;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
