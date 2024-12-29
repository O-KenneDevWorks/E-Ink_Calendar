using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Ink_Calendar
{
    public partial class EventModal : Form
    {
        private ListBox listBoxEvents;
        private TextBox textBoxEvent;
        private Button button1;
        private Button button2;
        private Button button3;

        private void InitializeComponent()
        {
            listBoxEvents = new ListBox();
            textBoxEvent = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBoxEvents.FormattingEnabled = true;
            listBoxEvents.ItemHeight = 25;
            listBoxEvents.Location = new Point(12, 12);
            listBoxEvents.Name = "listBox1";
            listBoxEvents.Size = new Size(976, 504);
            listBoxEvents.TabIndex = 0;
            // 
            // textBox1
            // 
            textBoxEvent.Location = new Point(12, 522);
            textBoxEvent.Name = "textBox1";
            textBoxEvent.Size = new Size(976, 31);
            textBoxEvent.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(12, 559);
            button1.Name = "buttonAdd";
            button1.Size = new Size(323, 100);
            button1.TabIndex = 2;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(341, 559);
            button2.Name = "buttonRemove";
            button2.Size = new Size(325, 100);
            button2.TabIndex = 3;
            button2.Text = "Remove";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(672, 559);
            button3.Name = "buttonSave";
            button3.Size = new Size(316, 100);
            button3.TabIndex = 4;
            button3.Text = "Save";
            button3.UseVisualStyleBackColor = true;
            // 
            // EventModal
            // 
            ClientSize = new Size(1000, 776);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBoxEvent);
            Controls.Add(listBoxEvents);
            Name = "EventModal";
            ResumeLayout(false);
            PerformLayout();
        }

        private DateTime selectedDate;
        public List<string> UpdatedEvents { get; private set; }

        public EventModal(DateTime date, Dictionary<DateTime, List<string>> events)
        {
            InitializeComponent();
            selectedDate = date;
            this.Text = $"Events for {selectedDate.ToShortDateString()}";
            UpdatedEvents = events.ContainsKey(date) ? new List<string>(events[date]) : new List<string>();
            UpdateEventList();
        }

        // Method to update the event list displayed in the ListBox
        private void UpdateEventList()
        {
            listBoxEvents.Items.Clear();
            foreach (var ev in UpdatedEvents)
            {
                listBoxEvents.Items.Add(ev);
            }
        }

        // Button to add a new event
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string newEvent = textBoxEvent.Text.Trim();
            if (!string.IsNullOrEmpty(newEvent))
            {
                UpdatedEvents.Add(newEvent);
                UpdateEventList();
                textBoxEvent.Clear();
            }
        }

        // Button to remove the selected event
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem != null)
            {
                UpdatedEvents.Remove(listBoxEvents.SelectedItem.ToString());
                UpdateEventList();
            }
        }

        // Confirm and close the modal
        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
    }
}
