
namespace TestEditModeChecker
{
	partial class LogForm
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
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.rtbLog = new System.Windows.Forms.RichTextBox();
		this.optOn = new System.Windows.Forms.RadioButton();
		this.optOff = new System.Windows.Forms.RadioButton();
		this.tableLayoutPanel1.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.SuspendLayout();
		// 
		// tableLayoutPanel1
		// 
		this.tableLayoutPanel1.ColumnCount = 1;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 2;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 219);
		this.tableLayoutPanel1.TabIndex = 0;
		// 
		// groupBox1
		// 
		this.groupBox1.Controls.Add(this.optOff);
		this.groupBox1.Controls.Add(this.optOn);
		this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox1.Enabled = false;
		this.groupBox1.Location = new System.Drawing.Point(3, 3);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(331, 44);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = " Edit Mode is ... ";
		// 
		// groupBox2
		// 
		this.groupBox2.Controls.Add(this.rtbLog);
		this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupBox2.Location = new System.Drawing.Point(3, 53);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(331, 163);
		this.groupBox2.TabIndex = 1;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = " Transaction Log";
		// 
		// rtbLog
		// 
		this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
		this.rtbLog.Location = new System.Drawing.Point(3, 16);
		this.rtbLog.Name = "rtbLog";
		this.rtbLog.ReadOnly = true;
		this.rtbLog.Size = new System.Drawing.Size(325, 144);
		this.rtbLog.TabIndex = 0;
		this.rtbLog.Text = "";
		// 
		// optOn
		// 
		this.optOn.AutoSize = true;
		this.optOn.Location = new System.Drawing.Point(9, 19);
		this.optOn.Name = "optOn";
		this.optOn.Size = new System.Drawing.Size(41, 17);
		this.optOn.TabIndex = 0;
		this.optOn.TabStop = true;
		this.optOn.Text = "ON";
		this.optOn.UseVisualStyleBackColor = true;
		// 
		// optOff
		// 
		this.optOff.AutoSize = true;
		this.optOff.Location = new System.Drawing.Point(72, 19);
		this.optOff.Name = "optOff";
		this.optOff.Size = new System.Drawing.Size(45, 17);
		this.optOff.TabIndex = 1;
		this.optOff.TabStop = true;
		this.optOff.Text = "OFF";
		this.optOff.UseVisualStyleBackColor = true;
		// 
		// LogForm
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(337, 219);
		this.Controls.Add(this.tableLayoutPanel1);
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "LogForm";
		this.Text = " Check Edit Mode";
		this.tableLayoutPanel1.ResumeLayout(false);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.ResumeLayout(false);

		}

	  #endregion

	  private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	  private System.Windows.Forms.GroupBox groupBox1;
	  private System.Windows.Forms.GroupBox groupBox2;
	  private System.Windows.Forms.RichTextBox rtbLog;
	  private System.Windows.Forms.RadioButton optOn;
	  private System.Windows.Forms.RadioButton optOff;
    }
}