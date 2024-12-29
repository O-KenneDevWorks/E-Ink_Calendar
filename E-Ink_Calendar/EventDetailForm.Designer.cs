namespace E_Ink_Calendar
{
    partial class EventDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTitle = new TextBox();  // Changed from textBox1 to textBoxTitle
            this.dateTimePickerStart = new DateTimePicker();  // Changed from dateTimePicker1
            this.dateTimePickerEnd = new DateTimePicker();  // Changed from dateTimePicker2
            this.textBoxNotes = new TextBox();  // Changed from textBox2
            this.label1 = new Label();  // Can rename the labels appropriately
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.button1 = new Button();
            this.button2 = new Button();

            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new Point(198, 41);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new Size(300, 31);
            this.textBoxTitle.TabIndex = 0;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new Point(198, 117);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new Size(300, 31);
            this.dateTimePickerStart.TabIndex = 1;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new Point(198, 183);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new Size(300, 31);
            this.dateTimePickerEnd.TabIndex = 2;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new Point(198, 249);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new Size(300, 165);
            this.textBoxNotes.TabIndex = 3;
            // 
            // label1, label2, label3, label4
            // (Assign location, size, and text to labels)
            // 
            // button1 (Save)
            // 
            this.button1.Location = new Point(198, 420);
            this.button1.Name = "button1";
            this.button1.Size = new Size(139, 61);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.buttonSave_Click);
            // 
            // button2 (Cancel)
            // 
            this.button2.Location = new Point(358, 420);
            this.button2.Name = "button2";
            this.button2.Size = new Size(140, 61);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.buttonCancel_Click);
            // 
            // EventDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 617);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EventDetailForm";
            this.Text = "EventDetailForm";
            this.Load += new EventHandler(this.EventDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }