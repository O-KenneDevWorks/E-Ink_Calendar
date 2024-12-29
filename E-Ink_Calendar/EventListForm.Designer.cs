namespace E_Ink_Calendar
{
    partial class EventListForm
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
            listBoxEvents = new ListBox();
            button1 = new Button();
            button2 = new Button();
            listBox2 = new ListBox();
            SuspendLayout();
            // 
            // listBoxEvents
            // 
            listBoxEvents.FormattingEnabled = true;
            listBoxEvents.ItemHeight = 25;
            listBoxEvents.Location = new Point(395, 187);
            listBoxEvents.Name = "listBoxEvents";
            listBoxEvents.Size = new Size(180, 129);
            listBoxEvents.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(782, 597);
            button1.Name = "button1";
            button1.Size = new Size(152, 50);
            button1.TabIndex = 1;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new EventHandler(buttonAdd_Click);
            // 
            // button2
            // 
            button2.Location = new Point(953, 597);
            button2.Name = "button2";
            button2.Size = new Size(143, 50);
            button2.TabIndex = 2;
            button2.Text = "Close";
            button2.UseVisualStyleBackColor = true;
            button2.Click += new EventHandler(buttonClose_Click);
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 25;
            listBox2.Location = new Point(12, 47);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(1149, 254);
            listBox2.TabIndex = 3;
            // 
            // EventListForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 659);
            Controls.Add(listBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "EventListForm";
            Text = "EventListForm";
            Load += EventListForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private Button button2;
        private ListBox listBox2;
    }
}