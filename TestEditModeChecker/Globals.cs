using Autodesk.Revit.UI;

using Application = Autodesk.Revit.ApplicationServices.Application;
using Document = Autodesk.Revit.DB.Document;


namespace TestEditModeChecker
{
	  public static class Globals
	  {
		  private static LogForm _logForm;

		  /// <summary>
		  /// Gets an instance of the LogForm.
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
		

		  /// <summary>
		  /// Initialize global static properties.
		  /// </summary>
		  /// <param name="uiApplication">An active session of the Autodesk Revit user interface,
		  /// providing access to UI customization methods, events, and the active document.</param>
		  public static void Initialize(UIApplication uiApplication)
		  {
			  UiApplication = uiApplication;


		  }

		  /// <summary>
		  /// The active session of the Autodesk Revit user interface,
		  /// providing access to UI customization methods, events, and the active document.
		  /// </summary>
		  public static UIApplication UiApplication { get; private set; }

		  /// <summary>
		  /// Represents the Autodesk Revit Application, providing access to documents, options
		  /// and other application wide data and settings.
		  /// </summary>
		  public static Application Application => UiApplication?.Application;

		  /// <summary>
		  /// An object that represents an Autodesk Revit project opened in the Revit user interface.
		  /// </summary>
		  public static UIDocument ActiveUiDocument => UiApplication?.ActiveUIDocument;

		  /// <summary>
		  /// An object that represents an open Autodesk Revit project.
		  /// </summary>
		  public static Document ActiveDocument => ActiveUiDocument?.Document;
	  }
}
