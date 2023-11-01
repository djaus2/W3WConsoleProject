namespace W3WFormApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;



    /// <summary>
    ///  Clean up any resources being used.
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

    private TextBox txtLatitude;
    private Button convertButton;
    private Label wordsValueLabel;

    private Button button1;
    private TextBox txtLongitude;
    private Label urlValueLabel;
    private Label latitudeLabel;
    private Label longitudeLabel;
    private Label labelMap;
    private Label locationValueLabel;
    private Label label2;
    private Label label3;

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtLatitude = new TextBox();
        convertButton = new Button();
        wordsValueLabel = new Label();
        button1 = new Button();
        txtLongitude = new TextBox();
        urlValueLabel = new Label();
        latitudeLabel = new Label();
        longitudeLabel = new Label();
        labelMap = new Label();
        locationValueLabel = new Label();
        label2 = new Label();
        label3 = new Label();
        label1 = new Label();
        SuspendLayout();
        // 
        // txtLatitude
        // 
        txtLatitude.Location = new Point(166, 123);
        txtLatitude.Name = "txtLatitude";
        txtLatitude.Size = new Size(340, 43);
        txtLatitude.TabIndex = 0;
        txtLatitude.TextChanged += inputTextBox_TextChanged;
        // 
        // convertButton
        // 
        convertButton.Location = new Point(22, 230);
        convertButton.Name = "convertButton";
        convertButton.Size = new Size(230, 100);
        convertButton.TabIndex = 1;
        convertButton.Text = "Get What3Words";
        convertButton.Click += convertButton_Click;
        // 
        // wordsValueLabel
        // 
        wordsValueLabel.BackColor = Color.Yellow;
        wordsValueLabel.Location = new Point(151, 337);
        wordsValueLabel.Name = "wordsValueLabel";
        wordsValueLabel.Size = new Size(594, 33);
        wordsValueLabel.TabIndex = 2;
        // 
        // button1
        // 
        button1.Location = new Point(270, 234);
        button1.Name = "button1";
        button1.Size = new Size(230, 100);
        button1.TabIndex = 3;
        button1.Text = "Display In Browser";
        button1.Click += button1_Click;
        // 
        // txtLongitude
        // 
        txtLongitude.Location = new Point(166, 181);
        txtLongitude.Name = "txtLongitude";
        txtLongitude.Size = new Size(340, 43);
        txtLongitude.TabIndex = 4;
        txtLongitude.TextChanged += textBox1_TextChanged;
        // 
        // urlValueLabel
        // 
        urlValueLabel.BackColor = Color.Yellow;
        urlValueLabel.Location = new Point(151, 490);
        urlValueLabel.Name = "urlValueLabel";
        urlValueLabel.Size = new Size(594, 33);
        urlValueLabel.TabIndex = 5;
        // 
        // latitudeLabel
        // 
        latitudeLabel.AutoSize = true;
        latitudeLabel.Location = new Point(33, 129);
        latitudeLabel.Name = "latitudeLabel";
        latitudeLabel.Size = new Size(114, 37);
        latitudeLabel.TabIndex = 6;
        latitudeLabel.Text = "Latitude";
        // 
        // longitudeLabel
        // 
        longitudeLabel.AutoSize = true;
        longitudeLabel.Location = new Point(22, 181);
        longitudeLabel.Name = "longitudeLabel";
        longitudeLabel.Size = new Size(138, 37);
        longitudeLabel.TabIndex = 7;
        longitudeLabel.Text = "Longitude";
        // 
        // labelMap
        // 
        labelMap.AutoSize = true;
        labelMap.Location = new Point(22, 333);
        labelMap.Name = "labelMap";
        labelMap.Size = new Size(99, 37);
        labelMap.TabIndex = 8;
        labelMap.Text = "Words:";
        // 
        // locationValueLabel
        // 
        locationValueLabel.BackColor = Color.Yellow;
        locationValueLabel.Location = new Point(151, 410);
        locationValueLabel.Name = "locationValueLabel";
        locationValueLabel.Size = new Size(594, 33);
        locationValueLabel.TabIndex = 9;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(22, 406);
        label2.Name = "label2";
        label2.Size = new Size(114, 37);
        label2.TabIndex = 10;
        label2.Text = "Nearest:";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(63, 490);
        label3.Name = "label3";
        label3.Size = new Size(58, 37);
        label3.TabIndex = 11;
        label3.Text = "Url:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point);
        label1.ForeColor = SystemColors.Highlight;
        label1.Location = new Point(48, 26);
        label1.Name = "label1";
        label1.Size = new Size(852, 112);
        label1.TabIndex = 12;
        label1.Text = "GPS to What3Words";
        // 
        // Form1
        // 
        ClientSize = new Size(1000, 800);
        Controls.Add(label1);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(locationValueLabel);
        Controls.Add(labelMap);
        Controls.Add(longitudeLabel);
        Controls.Add(latitudeLabel);
        Controls.Add(urlValueLabel);
        Controls.Add(txtLongitude);
        Controls.Add(button1);
        Controls.Add(txtLatitude);
        Controls.Add(convertButton);
        Controls.Add(wordsValueLabel);
        Name = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion


    private Label label1;
}
