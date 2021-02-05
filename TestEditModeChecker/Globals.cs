namespace TestEditModeChecker
{
	/// <summary>
	/// Provides global static properties which can be used/shared between all components
	/// of the Revit plugin (App/ExternalApplication and Command).
	/// </summary>
	public static class Globals
	{
		private static LogForm _logForm;

		/// <summary>
		/// Gets an instance of the LogForm which shows if Revit is in Edit Mode
		/// and a log of transactions (updated from the OnDocumentChanged event, see App.cs).
		/// </summary>
		public static LogForm LogForm
		{
			get
			{
				if (_logForm == null || _logForm.IsDisposed)
				{
					_logForm = new LogForm();
				}

				return _logForm;
			}
		}
	}
}