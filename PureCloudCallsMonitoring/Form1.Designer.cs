namespace PureCloudCallsMonitoring
{
	partial class Form1
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.cmbEnvironment = new System.Windows.Forms.ComboBox();
			this.lblEnvironment = new System.Windows.Forms.Label();
			this.txtClientSecret = new System.Windows.Forms.TextBox();
			this.lblClientSecret = new System.Windows.Forms.Label();
			this.txtClientId = new System.Windows.Forms.TextBox();
			this.lblClientId = new System.Windows.Forms.Label();
			this.gbQueues = new System.Windows.Forms.GroupBox();
			this.btnDisconnectSelectedConversations = new System.Windows.Forms.Button();
			this.tvConversations = new System.Windows.Forms.TreeView();
			this.cmbQueues = new System.Windows.Forms.ComboBox();
			this.lblQueues = new System.Windows.Forms.Label();
			this.lstLog = new System.Windows.Forms.ListBox();
			this.btnClearLog = new System.Windows.Forms.Button();
			this.btnSaveLog = new System.Windows.Forms.Button();
			this.chkVerboseLogging = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.gbQueues.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnDisconnect);
			this.groupBox1.Controls.Add(this.btnConnect);
			this.groupBox1.Controls.Add(this.cmbEnvironment);
			this.groupBox1.Controls.Add(this.lblEnvironment);
			this.groupBox1.Controls.Add(this.txtClientSecret);
			this.groupBox1.Controls.Add(this.lblClientSecret);
			this.groupBox1.Controls.Add(this.txtClientId);
			this.groupBox1.Controls.Add(this.lblClientId);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(313, 128);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "PureCloud Settings";
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Enabled = false;
			this.btnDisconnect.Location = new System.Drawing.Point(229, 96);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
			this.btnDisconnect.TabIndex = 7;
			this.btnDisconnect.Text = "Logout";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(84, 96);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(75, 23);
			this.btnConnect.TabIndex = 6;
			this.btnConnect.Text = "Login";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// cmbEnvironment
			// 
			this.cmbEnvironment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEnvironment.FormattingEnabled = true;
			this.cmbEnvironment.Items.AddRange(new object[] {
            "mypurecloud.ie",
            "mypurecloud.de",
            "mypurecloud.com",
            "mypurecloud.com.au",
            "mypurecloud.jp"});
			this.cmbEnvironment.Location = new System.Drawing.Point(84, 17);
			this.cmbEnvironment.Name = "cmbEnvironment";
			this.cmbEnvironment.Size = new System.Drawing.Size(220, 21);
			this.cmbEnvironment.TabIndex = 5;
			// 
			// lblEnvironment
			// 
			this.lblEnvironment.AutoSize = true;
			this.lblEnvironment.Location = new System.Drawing.Point(9, 20);
			this.lblEnvironment.Name = "lblEnvironment";
			this.lblEnvironment.Size = new System.Drawing.Size(69, 13);
			this.lblEnvironment.TabIndex = 4;
			this.lblEnvironment.Text = "Environment:";
			// 
			// txtClientSecret
			// 
			this.txtClientSecret.Location = new System.Drawing.Point(84, 70);
			this.txtClientSecret.Name = "txtClientSecret";
			this.txtClientSecret.PasswordChar = '*';
			this.txtClientSecret.Size = new System.Drawing.Size(220, 20);
			this.txtClientSecret.TabIndex = 3;
			this.txtClientSecret.Text = "GO9O9SFvV-BrmbZbp8e-DKGJtJXiKdw7r1c-f0AivCY";
			// 
			// lblClientSecret
			// 
			this.lblClientSecret.AutoSize = true;
			this.lblClientSecret.Location = new System.Drawing.Point(8, 73);
			this.lblClientSecret.Name = "lblClientSecret";
			this.lblClientSecret.Size = new System.Drawing.Size(70, 13);
			this.lblClientSecret.TabIndex = 2;
			this.lblClientSecret.Text = "Client Secret:";
			// 
			// txtClientId
			// 
			this.txtClientId.Location = new System.Drawing.Point(84, 44);
			this.txtClientId.Name = "txtClientId";
			this.txtClientId.Size = new System.Drawing.Size(220, 20);
			this.txtClientId.TabIndex = 1;
			this.txtClientId.Text = "1ce88282-9bc8-4ef9-97ca-5d28cda8373a";
			// 
			// lblClientId
			// 
			this.lblClientId.AutoSize = true;
			this.lblClientId.Location = new System.Drawing.Point(30, 47);
			this.lblClientId.Name = "lblClientId";
			this.lblClientId.Size = new System.Drawing.Size(48, 13);
			this.lblClientId.TabIndex = 0;
			this.lblClientId.Text = "Client Id:";
			// 
			// gbQueues
			// 
			this.gbQueues.Controls.Add(this.btnDisconnectSelectedConversations);
			this.gbQueues.Controls.Add(this.tvConversations);
			this.gbQueues.Controls.Add(this.cmbQueues);
			this.gbQueues.Controls.Add(this.lblQueues);
			this.gbQueues.Enabled = false;
			this.gbQueues.Location = new System.Drawing.Point(331, 12);
			this.gbQueues.Name = "gbQueues";
			this.gbQueues.Size = new System.Drawing.Size(485, 368);
			this.gbQueues.TabIndex = 1;
			this.gbQueues.TabStop = false;
			this.gbQueues.Text = "PureCloud Queues";
			// 
			// btnDisconnectSelectedConversations
			// 
			this.btnDisconnectSelectedConversations.Enabled = false;
			this.btnDisconnectSelectedConversations.Location = new System.Drawing.Point(9, 339);
			this.btnDisconnectSelectedConversations.Name = "btnDisconnectSelectedConversations";
			this.btnDisconnectSelectedConversations.Size = new System.Drawing.Size(205, 23);
			this.btnDisconnectSelectedConversations.TabIndex = 4;
			this.btnDisconnectSelectedConversations.Text = "Disconnect Selected Conversations";
			this.btnDisconnectSelectedConversations.UseVisualStyleBackColor = true;
			this.btnDisconnectSelectedConversations.Click += new System.EventHandler(this.btnDisconnectSelectedConversations_Click);
			// 
			// tvConversations
			// 
			this.tvConversations.CheckBoxes = true;
			this.tvConversations.FullRowSelect = true;
			this.tvConversations.Location = new System.Drawing.Point(9, 47);
			this.tvConversations.Name = "tvConversations";
			this.tvConversations.Size = new System.Drawing.Size(470, 286);
			this.tvConversations.TabIndex = 3;
			this.tvConversations.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvConversations_AfterCheck);
			// 
			// cmbQueues
			// 
			this.cmbQueues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbQueues.FormattingEnabled = true;
			this.cmbQueues.Location = new System.Drawing.Point(59, 20);
			this.cmbQueues.Name = "cmbQueues";
			this.cmbQueues.Size = new System.Drawing.Size(420, 21);
			this.cmbQueues.TabIndex = 1;
			this.cmbQueues.SelectedIndexChanged += new System.EventHandler(this.cmbQueues_SelectedIndexChanged);
			// 
			// lblQueues
			// 
			this.lblQueues.AutoSize = true;
			this.lblQueues.Location = new System.Drawing.Point(6, 23);
			this.lblQueues.Name = "lblQueues";
			this.lblQueues.Size = new System.Drawing.Size(47, 13);
			this.lblQueues.TabIndex = 0;
			this.lblQueues.Text = "Queues:";
			// 
			// lstLog
			// 
			this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstLog.FormattingEnabled = true;
			this.lstLog.Location = new System.Drawing.Point(2, 415);
			this.lstLog.Name = "lstLog";
			this.lstLog.Size = new System.Drawing.Size(825, 108);
			this.lstLog.TabIndex = 2;
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(588, 386);
			this.btnClearLog.Name = "btnClearLog";
			this.btnClearLog.Size = new System.Drawing.Size(81, 23);
			this.btnClearLog.TabIndex = 3;
			this.btnClearLog.Text = "Clear Log";
			this.btnClearLog.UseVisualStyleBackColor = true;
			this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
			// 
			// btnSaveLog
			// 
			this.btnSaveLog.Location = new System.Drawing.Point(675, 386);
			this.btnSaveLog.Name = "btnSaveLog";
			this.btnSaveLog.Size = new System.Drawing.Size(81, 23);
			this.btnSaveLog.TabIndex = 14;
			this.btnSaveLog.Text = "Save Log";
			this.btnSaveLog.UseVisualStyleBackColor = true;
			this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
			// 
			// chkVerboseLogging
			// 
			this.chkVerboseLogging.AutoSize = true;
			this.chkVerboseLogging.Location = new System.Drawing.Point(762, 390);
			this.chkVerboseLogging.Name = "chkVerboseLogging";
			this.chkVerboseLogging.Size = new System.Drawing.Size(65, 17);
			this.chkVerboseLogging.TabIndex = 15;
			this.chkVerboseLogging.Text = "Verbose";
			this.chkVerboseLogging.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(828, 526);
			this.Controls.Add(this.chkVerboseLogging);
			this.Controls.Add(this.btnSaveLog);
			this.Controls.Add(this.btnClearLog);
			this.Controls.Add(this.lstLog);
			this.Controls.Add(this.gbQueues);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "PureCloud Calls Monitoring - Use with Caution!";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gbQueues.ResumeLayout(false);
			this.gbQueues.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbEnvironment;
		private System.Windows.Forms.Label lblEnvironment;
		private System.Windows.Forms.TextBox txtClientSecret;
		private System.Windows.Forms.Label lblClientSecret;
		private System.Windows.Forms.TextBox txtClientId;
		private System.Windows.Forms.Label lblClientId;
		private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.GroupBox gbQueues;
		private System.Windows.Forms.ComboBox cmbQueues;
		private System.Windows.Forms.Label lblQueues;
		private System.Windows.Forms.ListBox lstLog;
		private System.Windows.Forms.Button btnClearLog;
		private System.Windows.Forms.Button btnSaveLog;
		private System.Windows.Forms.CheckBox chkVerboseLogging;
		private System.Windows.Forms.TreeView tvConversations;
		private System.Windows.Forms.Button btnDisconnectSelectedConversations;
	}
}

