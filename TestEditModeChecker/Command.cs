using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using static TestEditModeChecker.Globals;


namespace TestEditModeChecker
{
	[Transaction(TransactionMode.Manual)]
	public class Command : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			// initialize global properties
			Initialize(commandData.Application);


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
				revitMainWindowHandle = new WindowHandle(UiApplication.MainWindowHandle);
#endif
				Globals.LogForm.Show(revitMainWindowHandle);
			}


			return Result.Succeeded;
		}
	}
}