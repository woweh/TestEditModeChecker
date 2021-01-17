namespace TestEditModeChecker
{
	  public static class Globals
	  {
		  private static LogForm _logForm;

		  /// <summary>
		  /// Gets an instance of the LogForm which shows if Revit is in Edit Mode
		  /// and a log of transactions (updated from the DocumentChanged event).
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
