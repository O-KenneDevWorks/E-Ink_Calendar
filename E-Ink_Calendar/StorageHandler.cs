using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace E_Ink_Calendar
{
    internal class StorageHandler
    {
    }

    public partial class Form1 : Form
    {
        private Dictionary<DateTime, List<Event>> events = new Dictionary<DateTime, List<Event>>();
        private int currentMonth = 10;
        private int currentYear = 2024;
        private const string eventFilePath = "events.json"; // Path to store events

        public Form1()
        {
            InitializeComponent();
            this.Text = "Calendar";
            this.ClientSize = new System.Drawing.Size(600, 550);

            // Create month/year controls and buttons for navigation
            InitializeMonthYearControls();

            // Load events from persistent storage
            LoadEventsFromFile();

            // Draw the initial calendar
            DrawCalendar(currentMonth, currentYear);
        }

        // Save events to local file (JSON format)
        private void SaveEventsToFile()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(events);
                File.WriteAllText(eventFilePath, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save events: {ex.Message}");
            }
        }

        // Load events from local file (JSON format)
        private void LoadEventsFromFile()
        {
            try
            {
                if (File.Exists(eventFilePath))
                {
                    string jsonString = File.ReadAllText(eventFilePath);
                    events = JsonSerializer.Deserialize<Dictionary<DateTime, List<Event>>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load events: {ex.Message}");
            }
        }

        // Other methods remain unchanged...
    }

    // Event class to hold event data
    public class Event
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }
    }

}
