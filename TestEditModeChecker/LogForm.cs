using System;
using System.Windows.Forms;


namespace TestEditModeChecker
{
	public partial class LogForm : Form
	{
		public LogForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Write a text line into log text box.
		/// </summary>
		/// <param name="textToLog">The line of text which shall be logged.</param>
		public void WriteLine(string textToLog)
		{
			if (!IsHandleCreated)
			{
				return;
			}

			rtbLog.AppendText(textToLog);
			rtbLog.AppendText(Environment.NewLine);

			if (Visible)
			{
				rtbLog.SelectionStart = rtbLog.TextLength;
				rtbLog.ScrollToCaret();
			}
		}


		/// <summary>
		/// Update the radio buttons which show if Revit is in Edit mode.
		/// </summary>
		/// <param name="editModeOn"></param>
		public void ShowIfRevitIsInEditMode(bool editModeOn)
		{
			if (!IsHandleCreated)
			{
				return;
			}

			optOn.Checked = editModeOn;
			optOff.Checked = !editModeOn;
		}
	}
}
