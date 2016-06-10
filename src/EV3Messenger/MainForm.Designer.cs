namespace EV3MessengerApp
{
    partial class MainForm
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
            this.connectionBox = new System.Windows.Forms.GroupBox();
            this.connectedDeviceLabel = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.scanForSerialPortsButton = new System.Windows.Forms.Button();
            this.selectComPortLabel = new System.Windows.Forms.Label();
            this.serialPortSelectionBox = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.receivedMessagesBox = new System.Windows.Forms.GroupBox();
            this.clearReceivedMessagesButton = new System.Windows.Forms.Button();
            this.receivedMessagesListBox = new System.Windows.Forms.ListBox();
            this.sendMessageBox = new System.Windows.Forms.GroupBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.messageTypeComboBox = new System.Windows.Forms.ComboBox();
            this.mailboxTitleTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.mailboxLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ev3MEssengerLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.connectionBox.SuspendLayout();
            this.receivedMessagesBox.SuspendLayout();
            this.sendMessageBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionBox
            // 
            this.connectionBox.Controls.Add(this.connectedDeviceLabel);
            this.connectionBox.Controls.Add(this.disconnectButton);
            this.connectionBox.Controls.Add(this.scanForSerialPortsButton);
            this.connectionBox.Controls.Add(this.selectComPortLabel);
            this.connectionBox.Controls.Add(this.serialPortSelectionBox);
            this.connectionBox.Controls.Add(this.connectButton);
            this.connectionBox.Location = new System.Drawing.Point(13, 13);
            this.connectionBox.Margin = new System.Windows.Forms.Padding(4);
            this.connectionBox.Name = "connectionBox";
            this.connectionBox.Padding = new System.Windows.Forms.Padding(4);
            this.connectionBox.Size = new System.Drawing.Size(899, 102);
            this.connectionBox.TabIndex = 4;
            this.connectionBox.TabStop = false;
            this.connectionBox.Text = "EV3 connection setup";
            // 
            // connectedDeviceLabel
            // 
            this.connectedDeviceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectedDeviceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectedDeviceLabel.Location = new System.Drawing.Point(685, 22);
            this.connectedDeviceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectedDeviceLabel.Name = "connectedDeviceLabel";
            this.connectedDeviceLabel.Size = new System.Drawing.Size(193, 57);
            this.connectedDeviceLabel.TabIndex = 6;
            this.connectedDeviceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(455, 52);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(100, 28);
            this.disconnectButton.TabIndex = 4;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // scanForSerialPortsButton
            // 
            this.scanForSerialPortsButton.Location = new System.Drawing.Point(564, 22);
            this.scanForSerialPortsButton.Margin = new System.Windows.Forms.Padding(4);
            this.scanForSerialPortsButton.Name = "scanForSerialPortsButton";
            this.scanForSerialPortsButton.Size = new System.Drawing.Size(107, 28);
            this.scanForSerialPortsButton.TabIndex = 3;
            this.scanForSerialPortsButton.Text = "Rescan Ports";
            this.scanForSerialPortsButton.UseVisualStyleBackColor = true;
            this.scanForSerialPortsButton.Click += new System.EventHandler(this.scanForSerialPortsButton_Click);
            // 
            // selectComPortLabel
            // 
            this.selectComPortLabel.AutoSize = true;
            this.selectComPortLabel.Location = new System.Drawing.Point(115, 43);
            this.selectComPortLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectComPortLabel.Name = "selectComPortLabel";
            this.selectComPortLabel.Size = new System.Drawing.Size(144, 17);
            this.selectComPortLabel.TabIndex = 2;
            this.selectComPortLabel.Text = "Select EV3 serial port";
            // 
            // serialPortSelectionBox
            // 
            this.serialPortSelectionBox.FormattingEnabled = true;
            this.serialPortSelectionBox.Location = new System.Drawing.Point(285, 39);
            this.serialPortSelectionBox.Margin = new System.Windows.Forms.Padding(4);
            this.serialPortSelectionBox.Name = "serialPortSelectionBox";
            this.serialPortSelectionBox.Size = new System.Drawing.Size(160, 24);
            this.serialPortSelectionBox.TabIndex = 0;
            this.serialPortSelectionBox.Leave += new System.EventHandler(this.serialPortSelectionBox_Leave);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(455, 22);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(100, 28);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // receivedMessagesBox
            // 
            this.receivedMessagesBox.Controls.Add(this.clearReceivedMessagesButton);
            this.receivedMessagesBox.Controls.Add(this.receivedMessagesListBox);
            this.receivedMessagesBox.Location = new System.Drawing.Point(468, 123);
            this.receivedMessagesBox.Margin = new System.Windows.Forms.Padding(4);
            this.receivedMessagesBox.Name = "receivedMessagesBox";
            this.receivedMessagesBox.Padding = new System.Windows.Forms.Padding(4);
            this.receivedMessagesBox.Size = new System.Drawing.Size(444, 392);
            this.receivedMessagesBox.TabIndex = 5;
            this.receivedMessagesBox.TabStop = false;
            this.receivedMessagesBox.Text = "Received messages";
            // 
            // clearReceivedMessagesButton
            // 
            this.clearReceivedMessagesButton.Location = new System.Drawing.Point(172, 347);
            this.clearReceivedMessagesButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearReceivedMessagesButton.Name = "clearReceivedMessagesButton";
            this.clearReceivedMessagesButton.Size = new System.Drawing.Size(100, 28);
            this.clearReceivedMessagesButton.TabIndex = 1;
            this.clearReceivedMessagesButton.Text = "Clear";
            this.clearReceivedMessagesButton.UseVisualStyleBackColor = true;
            this.clearReceivedMessagesButton.Click += new System.EventHandler(this.clearReceivedMessagesButton_Click);
            // 
            // receivedMessagesListBox
            // 
            this.receivedMessagesListBox.FormattingEnabled = true;
            this.receivedMessagesListBox.ItemHeight = 16;
            this.receivedMessagesListBox.Location = new System.Drawing.Point(19, 26);
            this.receivedMessagesListBox.Margin = new System.Windows.Forms.Padding(4);
            this.receivedMessagesListBox.Name = "receivedMessagesListBox";
            this.receivedMessagesListBox.Size = new System.Drawing.Size(404, 308);
            this.receivedMessagesListBox.TabIndex = 0;
            // 
            // sendMessageBox
            // 
            this.sendMessageBox.Controls.Add(this.sendMessageButton);
            this.sendMessageBox.Controls.Add(this.messageTypeComboBox);
            this.sendMessageBox.Controls.Add(this.mailboxTitleTextBox);
            this.sendMessageBox.Controls.Add(this.messageTextBox);
            this.sendMessageBox.Controls.Add(this.messageLabel);
            this.sendMessageBox.Controls.Add(this.mailboxLabel);
            this.sendMessageBox.Location = new System.Drawing.Point(14, 123);
            this.sendMessageBox.Margin = new System.Windows.Forms.Padding(4);
            this.sendMessageBox.Name = "sendMessageBox";
            this.sendMessageBox.Padding = new System.Windows.Forms.Padding(4);
            this.sendMessageBox.Size = new System.Drawing.Size(445, 162);
            this.sendMessageBox.TabIndex = 6;
            this.sendMessageBox.TabStop = false;
            this.sendMessageBox.Text = "Send message to mailbox";
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Location = new System.Drawing.Point(348, 99);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(90, 23);
            this.sendMessageButton.TabIndex = 7;
            this.sendMessageButton.Text = "Send";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // messageTypeComboBox
            // 
            this.messageTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.messageTypeComboBox.FormattingEnabled = true;
            this.messageTypeComboBox.Location = new System.Drawing.Point(96, 71);
            this.messageTypeComboBox.Name = "messageTypeComboBox";
            this.messageTypeComboBox.Size = new System.Drawing.Size(90, 24);
            this.messageTypeComboBox.TabIndex = 6;
            // 
            // mailboxTitleTextBox
            // 
            this.mailboxTitleTextBox.Location = new System.Drawing.Point(96, 43);
            this.mailboxTitleTextBox.Name = "mailboxTitleTextBox";
            this.mailboxTitleTextBox.Size = new System.Drawing.Size(342, 22);
            this.mailboxTitleTextBox.TabIndex = 5;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(192, 71);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(246, 22);
            this.messageTextBox.TabIndex = 4;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(8, 74);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(65, 17);
            this.messageLabel.TabIndex = 3;
            this.messageLabel.Text = "Message";
            // 
            // mailboxLabel
            // 
            this.mailboxLabel.AutoSize = true;
            this.mailboxLabel.Location = new System.Drawing.Point(8, 46);
            this.mailboxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mailboxLabel.Name = "mailboxLabel";
            this.mailboxLabel.Size = new System.Drawing.Size(81, 17);
            this.mailboxLabel.TabIndex = 2;
            this.mailboxLabel.Text = "Mailbox title";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ev3MEssengerLinkLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 293);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 225);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Project site:";
            // 
            // ev3MEssengerLinkLabel
            // 
            this.ev3MEssengerLinkLabel.AutoSize = true;
            this.ev3MEssengerLinkLabel.Location = new System.Drawing.Point(9, 86);
            this.ev3MEssengerLinkLabel.Name = "ev3MEssengerLinkLabel";
            this.ev3MEssengerLinkLabel.Size = new System.Drawing.Size(227, 17);
            this.ev3MEssengerLinkLabel.TabIndex = 1;
            this.ev3MEssengerLinkLabel.TabStop = true;
            this.ev3MEssengerLinkLabel.Text = "http://ev3messenger.codeplex.com";
            this.ev3MEssengerLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ev3MEssengerLinkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "EV3Messenger by Joeri van Belle";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 530);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sendMessageBox);
            this.Controls.Add(this.receivedMessagesBox);
            this.Controls.Add(this.connectionBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "EV3 Messenger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.connectionBox.ResumeLayout(false);
            this.connectionBox.PerformLayout();
            this.receivedMessagesBox.ResumeLayout(false);
            this.sendMessageBox.ResumeLayout(false);
            this.sendMessageBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox connectionBox;
        private System.Windows.Forms.Label connectedDeviceLabel;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button scanForSerialPortsButton;
        private System.Windows.Forms.Label selectComPortLabel;
        private System.Windows.Forms.ComboBox serialPortSelectionBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.GroupBox receivedMessagesBox;
        private System.Windows.Forms.Button clearReceivedMessagesButton;
        private System.Windows.Forms.ListBox receivedMessagesListBox;
        private System.Windows.Forms.GroupBox sendMessageBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label mailboxLabel;
        private System.Windows.Forms.ComboBox messageTypeComboBox;
        private System.Windows.Forms.TextBox mailboxTitleTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel ev3MEssengerLinkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

