using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace TestEditModeChecker
{
	/// <summary>
	/// Command to show/hide the LogForm dialogue.
	/// </summary>
	[Transaction(TransactionMode.Manual)]
	public class Command : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			if (Globals.LogForm.Visible)
			{
				Globals.LogForm.Hide();
			}
			else
			{
				WindowHandle revitMainWindowHandle;
#if Revit2017 || Revit2018
				revitMainWindowHandle = RevitMainWindowSearch.GetWindowHandle();
#else
				revitMainWindowHandle = new WindowHandle(commandData.Application.MainWindowHandle);
#endif
				Globals.LogForm.Show(revitMainWindowHandle);
			}


			return Result.Succeeded;
		}
	}
}