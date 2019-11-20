using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCRTasksTool.AppCode;

namespace DCRTasksTool
{
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
            this.ActiveControl = textBoxId;
        }
        private void LoadTaskListForm(string graphId)
        {
            this.Hide();
            var taskList = new TaskList(graphId);            
            taskList.Closed += (s, args) => this.Close();
            taskList.Show();
        }

        private void buttonID_Click(object sender, EventArgs e)
        {
            onclick();
        }

        private void onclick()
        {
            if (string.IsNullOrEmpty(textBoxId.Text) == false)
            {
                string graphId = textBoxId.Text.Trim();
                int n;
                bool isNumeric = int.TryParse(graphId, out n);
                if (isNumeric == true)
                {
                    LoadTaskListForm(graphId);
                }
                else
                {
                    MessageBox.Show("Please write correct id , id must be in integer ");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please write id of graph , it can not be empty ");
                return;
            }
        }

        private void textBoxId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                onclick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
