using System.Linq;

using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;


namespace TestEditModeChecker
{
	class App : IExternalApplication
	{
		private EditModeChecker _editModeChecker;


		public Result OnStartup(UIControlledApplication application)
		{
			_editModeChecker = new EditModeChecker();

			application.ControlledApplication.DocumentChanged += OnDocumentChanged;

			return Result.Succeeded;
		}


		public Result OnShutdown(UIControlledApplication application)
		{
			application.ControlledApplication.DocumentChanged -= OnDocumentChanged;

			return Result.Succeeded;
		}


		private void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
		{
			string transactionName = e.GetTransactionNames().FirstOrDefault();

			if (transactionName == null)
			{
				return;
			}

			Globals.LogForm?.WriteLine(transactionName);

			bool editModeOn = _editModeChecker.CheckIfRevitIsInEditMode(transactionName);

			Globals.LogForm?.ShowIfRevitIsInEditMode(editModeOn);
		}
	}
}