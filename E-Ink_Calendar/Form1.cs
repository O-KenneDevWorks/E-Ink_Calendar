namespace E_Ink_Calendar
{
    public partial class Form1 : Form
    {
        // private Dictionary<DateTime, List<string>> events = new Dictionary<DateTime, List<string>>();
        // private int currentMonth = 10;
        // private int currentYear = 2024;

        private ComboBox comboBoxMonth;
        private ComboBox comboBoxYear;


        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Form1
            // 
            ClientSize = new Size(1254, 807);
            Name = "Form1";
            ResumeLayout(false);
        }

        //public Form1()
        //{
        //    InitializeComponent();
        //    this.Text = "Calendar";
        //    this.ClientSize = new System.Drawing.Size(600, 550);

        //    // Create month and year dropdowns and navigation buttons
        //    InitializeMonthYearControls();
        //    DrawCalendar(currentMonth, currentYear);
        //}

        private void InitializeMonthYearControls()
        {
            // ComboBox for Month Selection
            comboBoxMonth = new ComboBox();
            comboBoxMonth.Items.AddRange(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.Take(12).ToArray());
            comboBoxMonth.SelectedIndex = currentMonth - 1;  // October (index starts at 0)
            comboBoxMonth.SelectedIndexChanged += ComboBoxMonth_SelectedIndexChanged;
            comboBoxMonth.Location = new System.Drawing.Point(240, 10);
            comboBoxMonth.Width = 100;
            this.Controls.Add(comboBoxMonth);

            // ComboBox for Year Selection
            comboBoxYear = new ComboBox();
            for (int year = 2020; year <= 2030; year++)  // Populate years between 2020 and 2030
            {
                comboBoxYear.Items.Add(year);
            }
            comboBoxYear.SelectedItem = currentYear;
            comboBoxYear.SelectedIndexChanged += ComboBoxYear_SelectedIndexChanged;
            comboBoxYear.Location = new System.Drawing.Point(360, 10);
            comboBoxYear.Width = 70;
            this.Controls.Add(comboBoxYear);

            // Button for Previous Month (<<)
            Button buttonPrevious = new Button();
            buttonPrevious.Text = "<<";
            buttonPrevious.Click += ButtonPrevious_Click;
            buttonPrevious.Location = new System.Drawing.Point(120, 10);
            buttonPrevious.Height = 40;
            this.Controls.Add(buttonPrevious);

            // Button for Next Month (>>)
            Button buttonNext = new Button();
            buttonNext.Text = ">>";
            buttonNext.Click += ButtonNext_Click;
            buttonNext.Location = new System.Drawing.Point(480, 10);
            buttonNext.Height = 40;
            this.Controls.Add(buttonNext);
        }

        // Handle Month selection change
        private void ComboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMonth = comboBoxMonth.SelectedIndex + 1;  // +1 because index starts at 0
            DrawCalendar(currentMonth, currentYear);
        }

        // Handle Year selection change
        private void ComboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentYear = int.Parse(comboBoxYear.SelectedItem.ToString());
            DrawCalendar(currentMonth, currentYear);
        }

        // Handle Previous Month Button Click
        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            currentMonth--;
            if (currentMonth < 1)
            {
                currentMonth = 12;
                currentYear--;
            }
            comboBoxMonth.SelectedIndex = currentMonth - 1;  // Update ComboBox
            comboBoxYear.SelectedItem = currentYear;         // Update ComboBox
            DrawCalendar(currentMonth, currentYear);
        }

        // Handle Next Month Button Click
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            currentMonth++;
            if (currentMonth > 12)
            {
                currentMonth = 1;
                currentYear++;
            }
            comboBoxMonth.SelectedIndex = currentMonth - 1;  // Update ComboBox
            comboBoxYear.SelectedItem = currentYear;         // Update ComboBox
            DrawCalendar(currentMonth, currentYear);
        }

        // Method to draw the calendar for the selected month/year
        private void DrawCalendar(int month, int year)
        {
            // Clear previous calendar
            this.Controls.OfType<Button>().Where(b => b.Tag != null).ToList().ForEach(b => this.Controls.Remove(b));

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;  // Sunday = 0

            // Draw calendar days
            int dayCounter = 1;
            for (int row = 0; row < 6; row++)  // 6 rows max for calendar
            {
                for (int col = 0; col < 7; col++)
                {
                    if (row == 0 && col < startDayOfWeek) continue;  // Skip days before 1st of the month

                    if (dayCounter > daysInMonth) break;

                    Button dayButton = new Button();
                    dayButton.Text = dayCounter.ToString();
                    dayButton.Size = new System.Drawing.Size(60, 60);
                    dayButton.Location = new System.Drawing.Point(50 + col * 70, 50 + row * 70 + 40);
                    dayButton.Tag = new DateTime(year, month, dayCounter);  // Store the date in Tag
                    dayButton.Click += DayButton_Click;
                    this.Controls.Add(dayButton);

                    dayCounter++;
                }
            }
        }

        // Event handler for day button click
        private void DayButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            DateTime selectedDate = (DateTime)clickedButton.Tag;

            // Get or initialize the events for the selected date
            if (!events.ContainsKey(selectedDate))
            {
                events[selectedDate] = new List<Event>();  // Initialize with an empty list if no events exist
            }

            // Open the EventListForm to display events for the selected day
            using (EventListForm eventListForm = new EventListForm(selectedDate, events[selectedDate]))
            {
                if (eventListForm.ShowDialog() == DialogResult.OK)
                {
                    // If there were changes, save the updated events to file
                    SaveEventsToFile();
                }
            }
        }

        // Open modal for adding/viewing/editing events
        private void OpenEventModal(DateTime date)
        {
            // Pass the correct list of events to the modal
            using (EventDetailForm eventModal = new EventDetailForm())
            {
                if (eventModal.ShowDialog() == DialogResult.OK)
                {
                    // Ensure that the event data is correctly stored in the dictionary
                    if (events.ContainsKey(date))
                    {
                        events[date].Add(eventModal.EventData);
                    }
                    else
                    {
                        events[date] = new List<Event> { eventModal.EventData };
                    }
                    SaveEventsToFile(); // Save after the event is added or modified
                }
            }
        }



    }
}
