using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

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

		/// <summary>
		/// Represents the Autodesk Revit user interface, providing access to UI customization methods and events.
		/// This property is set in IExternalApplication.OnStartup.
		/// </summary>
		/// <remarks>
		/// This class does not provide access to documents because it is provided to you
		///	through the ExternalApplication OnStartup()/OnShutdown() methods, and those methods
		///	are when it is not possible to work with Revit documents. You can work with documents
		/// by getting them from the UIApplication class; that class is obtained from events
		/// and ExternalCommand callbacks.
		/// </remarks>
		public static UIControlledApplication UiControlledApplication { get; set; }

		/// <summary>
		/// Returns the database level ControlledApplication represented by the UI-level <see cref="UiControlledApplication"/>.
		/// </summary>
		public static ControlledApplication ControlledApplication => UiControlledApplication?.ControlledApplication;

		/// <summary>
		/// Retrieves an object that represents the current Application for external command.
		/// This property is set in IExternalCommand.Execute
		/// </summary>
		public static UIApplication UiApplication { get; set; }

		/// <summary>
		/// Returns the database level Application represented by the UI level <see cref="UiApplication"/>.
		/// </summary>
		public static Application Application => UiApplication?.Application;

		/// <summary>
		/// Provides access to an object that represents the currently active project.
		/// </summary>
		/// <remarks>
		/// External API commands can access this property in read-only mode only!
		/// </remarks>
		public static UIDocument ActiveUiDocument => UiApplication?.ActiveUIDocument;

		/// <summary>
		/// Returns the database level document represented by the UI-level <see cref="ActiveUiDocument"/>.
		/// </summary>
		public static Document ActiveDocument => ActiveUiDocument?.Document;
	}
}