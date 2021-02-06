using System.Linq;

using Autodesk.Internal.Windows;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Windows;


namespace TestEditModeChecker
{
	/// <summary>
	/// Revit ExternalApplication which subscribes to the DocumentChanged event to check if Revit is in Edit mode.
	/// </summary>
	class App : IExternalApplication
	{
		private EditModeChecker _editModeChecker;


		public Result OnStartup(UIControlledApplication application)
		{
			Globals.UiControlledApplication = application;

			_editModeChecker = new EditModeChecker();

			application.ControlledApplication.DocumentChanged += OnDocumentChanged;

			ComponentManager.ItemExecuted += OnItemExecuted;
			ComponentManager.UIElementActivated += OnUiElementActivated;

			return Result.Succeeded;
		}


		public Result OnShutdown(UIControlledApplication application)
		{
			application.ControlledApplication.DocumentChanged -= OnDocumentChanged;

			ComponentManager.ItemExecuted -= OnItemExecuted;
			ComponentManager.UIElementActivated -= OnUiElementActivated;

			return Result.Succeeded;
		}


		private static void OnUiElementActivated(object sender, UIElementActivatedEventArgs e)
		{
			if (e?.Item == null)
			{
				return;
			}
			Globals.LogForm?.WriteLine($"OnUiElementActivated: {e.Item}");
			Globals.LogForm?.WriteLine($"- Item.Id:{e.Item.Id}");
			Globals.LogForm?.WriteLine($"- Item.Id:{e.Item.Id}");
			Globals.LogForm?.WriteLine($"- Item.Name:{e.Item.Name}");
			Globals.LogForm?.WriteLine($"- Item.GroupName:{e.Item.GroupName}");
			Globals.LogForm?.WriteLine($"- Item.AutomationName:{e.Item.AutomationName}");
		}


		private static void OnItemExecuted(object sender, RibbonItemExecutedEventArgs e)
		{
			if (e == null)
			{
				return;
			}

			Globals.LogForm?.WriteLine("OnItemExecuted");

			if (e.Item != null)
			{
				Globals.LogForm?.WriteLine($"Item: {e.Item}");
				Globals.LogForm?.WriteLine($"- Item.Id: {e.Item.Id}");
				Globals.LogForm?.WriteLine($"- Item.Name: {e.Item.Name}");
				Globals.LogForm?.WriteLine($"- Item.GroupName: {e.Item.GroupName}");
				Globals.LogForm?.WriteLine($"- Item.AutomationName: {e.Item.AutomationName}");
			}

			if (e.Panel != null)
			{
				Globals.LogForm?.WriteLine($"Panel: {e.Panel}");
				Globals.LogForm?.WriteLine($"- Panel.Id: {e.Panel.Id}");
				Globals.LogForm?.WriteLine($"- Panel.UID.Name: {e.Panel.UID}");
			}

			if (e.Tab != null)
			{
				Globals.LogForm?.WriteLine($"Tab: {e.Tab}");
				Globals.LogForm?.WriteLine($"- Tab.Id: {e.Tab.Id}");
				Globals.LogForm?.WriteLine($"- Tab.UID: {e.Tab.UID}");
				Globals.LogForm?.WriteLine($"- Tab.Name: {e.Tab.Name}");
				Globals.LogForm?.WriteLine($"- Tab.Title: {e.Tab.Title}");
				Globals.LogForm?.WriteLine($"- Tab.AutomationName: {e.Tab.AutomationName}");
			}
		}


		private void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
		{
			string transactionName = e.GetTransactionNames().FirstOrDefault();

			if (transactionName == null)
			{
				return;
			}

			// show the transaction on the LogForm
			Globals.LogForm?.WriteLine(transactionName);

			// Show if Revit is in Edit Mode
			bool editModeOn = _editModeChecker.CheckIfRevitIsInEditMode(transactionName);

			Globals.LogForm?.ShowIfRevitIsInEditMode(editModeOn);
		}
	}
}