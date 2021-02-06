using System.IO;
using System.Text;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;


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
			Globals.UiApplication = commandData.Application;

			DumpRibbonInfo();

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


		private static void DumpRibbonInfo()
		{
			StringBuilder sb = new();

			const string oneTab = "\t";

			const string twoTabs = "\t\t";

			foreach (RibbonTab ribbonTab in ComponentManager.Ribbon.Tabs)
			{
				sb.AppendLine($"RibbonTab: {ribbonTab}");
				AppendLine("- Id:", ribbonTab.Id);
				AppendLine("- UID: ", ribbonTab.UID);
				AppendLine("- Name: ", ribbonTab.Name);
				AppendLine("- AutomationName: ", ribbonTab.AutomationName);

				foreach (Autodesk.Windows.RibbonPanel ribbonPanel in ribbonTab.Panels)
				{
					sb.AppendLine($"{oneTab}RibbonPanel: {ribbonPanel}");
					AppendLine("- Id: ", ribbonPanel.Id, oneTab);
					AppendLine("- UID: ", ribbonPanel.UID, oneTab);
					AppendLine("- SourceId: ", ribbonPanel.SourceId, oneTab);
					AppendLine("- AutomationName: ", ribbonPanel.AutomationName, oneTab);

					foreach (Autodesk.Windows.RibbonItem ribbonItem in ribbonPanel.Source.Items)
					{
						sb.AppendLine($"{twoTabs}RibbonItem: {ribbonItem}");
						AppendLine("- Id: ", ribbonItem.Id, twoTabs);
						AppendLine("- UID: ", ribbonItem.UID, twoTabs);
						AppendLine("- Name: ", ribbonItem.Name, twoTabs);
						AppendLine("- Text: ", ribbonItem.Text, twoTabs);
						AppendLine("- GroupName: ", ribbonItem.GroupName, twoTabs);
						AppendLine("- AutomationName: ", ribbonItem.AutomationName, twoTabs);
					}
				}
			}

			const string fileName = @"D:\RevitRibbon.txt";

			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}

			File.WriteAllText(fileName, sb.ToString());


			void AppendLine(string caption, string value, string indent = "")
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					sb.AppendLine(indent + caption + value);
				}
			}
		}

	}
}