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
    public partial class EventListForm : Form
    {
        private ListBox listBoxEvents;
        private Button buttonAdd;
        private Button buttonClose;

        private void EventListForm_Load(object sender, EventArgs e)
        {

        }

        private DateTime selectedDate;
        private List<Event> dayEvents;
        public Event SelectedEvent { get; private set; }  // Store selected event for editing

        public EventListForm(DateTime date, List<Event> eventsForDay)
        {
            InitializeComponent();
            selectedDate = date;
            dayEvents = eventsForDay.OrderBy(e => e.StartTime).ToList(); // Sort events chronologically
            this.Text = $"Events for {selectedDate.ToShortDateString()}";
            PopulateEventList();
        }

        // Populate the ListBox with the day's events
        private void PopulateEventList()
        {
            listBoxEvents.Items.Clear();  // Clear any existing items

            if (dayEvents == null || dayEvents.Count == 0)
            {
                listBoxEvents.Items.Add("No events for this day.");  // Add a placeholder if no events
                return;  // Exit if there are no events
            }

            foreach (var ev in dayEvents)
            {
                listBoxEvents.Items.Add($"{ev.StartTime.ToShortTimeString()} - {ev.Title}");
            }
        }

        // Event handler for the Add button to create a new event
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (EventDetailForm eventDetailForm = new EventDetailForm())
            {
                if (eventDetailForm.ShowDialog() == DialogResult.OK)
                {
                    dayEvents.Add(eventDetailForm.EventData); // Add the new event
                    dayEvents = dayEvents.OrderBy(ev => ev.StartTime).ToList(); // Keep them sorted
                    PopulateEventList();  // Refresh the event list in the ListBox
                }
            }
        }

        // Event handler for double-clicking on an event to edit it
        private void listBoxEvents_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedIndex == -1) return;  // No item selected

            // Get the selected event
            Event selectedEvent = dayEvents[listBoxEvents.SelectedIndex];

            // Open the EventDetailForm to edit the selected event
            using (EventDetailForm eventDetailForm = new EventDetailForm(selectedEvent))
            {
                if (eventDetailForm.ShowDialog() == DialogResult.OK)
                {
                    // Update the event details
                    dayEvents[listBoxEvents.SelectedIndex] = eventDetailForm.EventData;
                    dayEvents = dayEvents.OrderBy(ev => ev.StartTime).ToList(); // Keep them sorted
                    PopulateEventList();  // Refresh the event list
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
