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

    public partial class EventDetailForm : Form
    {
        public Event EventData { get; private set; }

        private TextBox textBoxTitle;
        private TextBox textBoxNotes;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Label TitleLabel;
        private Label NoteLabel;
        private Label StartLabel;
        private Label EndLabel;


        public EventDetailForm(Event eventToEdit = null)
        {
            InitializeComponent();

            if (eventToEdit != null)
            {
                // Editing an existing event, so fill the fields
                textBoxTitle.Text = eventToEdit.Title;
                dateTimePickerStart.Value = eventToEdit.StartTime;
                dateTimePickerEnd.Value = eventToEdit.EndTime;
                textBoxNotes.Text = eventToEdit.Notes;
                EventData = eventToEdit;
            }
            else
            {
                // Creating a new event, so leave fields empty
                EventData = new Event();
            }
        }

        private void EventDetailForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Validate and save the event data
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.");
                return;
            }

            // Create or update the event data
            EventData.Title = textBoxTitle.Text;
            EventData.StartTime = dateTimePickerStart.Value;
            EventData.EndTime = dateTimePickerEnd.Value;
            EventData.Notes = textBoxNotes.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}
