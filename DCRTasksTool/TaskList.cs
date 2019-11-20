using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DCRTasksTool.AppCode;

namespace DCRTasksTool
{
    public partial class TaskList : Form
    {

        string GraphID = string.Empty;
        string SimID = string.Empty;
        List<Events> eveLst = new List<Events>();

        public TaskList(string id)
        {
            InitializeComponent();
            GraphID = id;
           
        }

        public void OnLoad(bool isSuccess)
        {
            if (isSuccess)
            {
                RoundButton start = new RoundButton();
                start.Name = "rb1";
                start.Location = new System.Drawing.Point(710, 100);
                start.Size = new System.Drawing.Size(50, 50);
                start.BackColor = System.Drawing.Color.Green;
                this.Controls.Add(start);
                checkIsAccepting();
            }
            else
            {

                var choice = new Choice();
                this.Hide();
                choice.Closed += (s, args) => this.Close();
                choice.Show();
            }

        }

        public TaskList()
        {
            InitializeComponent();
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("please select event to execute");
                return;
            }
            string selectItemText = listView1.SelectedItems[0].SubItems[6].Text;
            executeWithRepository(GraphID, SimID, selectItemText);
        }



        private void executeWithRepository(string graphID, string simID, string eventName)
        {
            string retrunXML = string.Empty;
            List<Events> lst = FunctionalityFromRepository.GetExecutedEvents(graphID, simID, eventName, ref retrunXML);
            if (string.IsNullOrWhiteSpace(retrunXML) == false)
            {
                string errorDetail = string.Empty;
                bool chhk = HelpingFunctions.checkSuccessExecute(retrunXML, ref errorDetail);
                if (chhk)
                {
                    MessageBox.Show("Something went wrong , please try later ");
                }
                else
                {
                    string err = HelpingFunctions.updateErrorMsgReplaceIdWithLabels(eveLst, errorDetail);
                    MessageBox.Show(err);
                    //MessageBox.Show(errorDetail);
                }

            }
            else
            {
                LoadEvent(lst);
                checkIsAccepting();
            }
        }

        private bool GetEvents(string id)
        {
            bool isSuccess = false;
            string error = string.Empty;

            List<Events> lst = FunctionalityFromRepository.GetAllEvents(id, ref SimID, ref error);
            if (string.IsNullOrWhiteSpace(error))
            {
                isSuccess = true;
                LoadEvent(lst);                
            }
            else
            {
                MessageBox.Show(error);
            }
            return isSuccess;
        }

        private void LoadEvent(List<Events> lst)
        {
            eveLst = lst;
            listView1.Items.Clear();
            foreach (Events item in lst.OrderByDescending(o => o.IsIncluded).ThenByDescending(o => o.IsPending).ThenByDescending(o => o.IsEnabled).ThenBy(o => o.IsExecuted))
            {
                string showPending = string.Empty;
                if (item.IsIncluded == "true" && item.IsPending == "true")
                {
                    showPending = "!";
                }
                else if (item.IsExecuted == "true")
                {
                    showPending = "\u2714"; //((char)0x221A).ToString();
                }
                ListViewItem lvi = new ListViewItem(showPending);
                lvi.UseItemStyleForSubItems = false;
                lvi.SubItems.Add(item.EventLabel);
                lvi.SubItems.Add(item.IsIncluded);
                lvi.SubItems.Add(item.IsEnabled);
                lvi.SubItems.Add(item.IsPending);
                lvi.SubItems.Add(item.IsExecuted);
                lvi.SubItems.Add(item.EventID);
                if (item.IsIncluded == "true" && item.IsPending == "true")
                {
                    lvi.SubItems[0].ForeColor = Color.Red;
                    lvi.SubItems[0].Font = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold);
                }
                else if (item.IsExecuted == "true")
                {
                    lvi.SubItems[0].ForeColor = Color.Green;
                    lvi.SubItems[0].Font = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold);
                }
                listView1.Items.Add(lvi);
            }

        }

        private void checkIsAccepting()
        {
            bool accepted = false;
            accepted = FunctionalityFromRepository.GetIsAccepting(GraphID, SimID);
            if (accepted)
            {
                showButton(false);
            }
            else
            {
                showButton(true);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var taskList = new Choice();
            taskList.Closed += (s, args) => this.Close();
            taskList.Show();
        }

        private void showButton(bool isred)
        {
            RoundButton rb = this.Controls.Find("rb1", true).FirstOrDefault() as RoundButton;

            if (rb != null)
            {
                if (isred)
                {
                    ColorConverter cc = new ColorConverter();
                    Color color = (Color)cc.ConvertFromString("#03A1FC");
                    rb.BackColor = color;
                }
                else
                {
                    Color result = Color.FromArgb(0, 248, 0);
                    rb.BackColor = result;
                }
            }

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            LoadEvent(FunctionalityFromRepository.GetLatestEvents(GraphID, SimID, ref error));
        }

        private void TaskList_Shown(object sender, EventArgs e)
        {
            bool isSuccess = GetEvents(GraphID);
            OnLoad(isSuccess);
        }
    }
}
