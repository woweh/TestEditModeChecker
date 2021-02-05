using System.Collections.Generic;


namespace TestEditModeChecker
{
	/// <summary>
	/// Helper class to check if Revit is in Edit Mode
	/// </summary>
	public class EditModeChecker
	{
		/// <summary>
		/// The active edit mode transaction - or null if Revit is not in Edit Mode
		/// </summary>
		private TransactionInfo _activeTransaction;


		/// <summary>
		/// Provides information about Revit 'edit mode' transactions.
		/// </summary>
		private class TransactionInfo
		{
			public TransactionInfo(string start, string cancel, string finish)
			{
				Start = start;
				Cancel = cancel;
				Finish = finish;
			}

			/// <summary>
			/// The name of the start edit mode transaction.
			/// </summary>
			public string Start { get; }

			/// <summary>
			/// The name of the cancel edit mode transaction.
			/// </summary>
			private string Cancel { get; }

			/// <summary>
			/// The name of the finish edit mode transaction.
			/// </summary>
			private string Finish { get; }

			/// <summary>
			/// Returns if this 'edit' transaction is cancelled or finished.
			/// </summary>
			/// <param name="transactionName">The transaction name to check.</param>
			/// <returns>True if the transaction is cancelled or finished, otherwise False.</returns>
			public bool CancelledOrFinished(string transactionName)
			{
				return Cancel == transactionName ||
					   Finish == transactionName;
			}
		}

		/// <summary>
		/// List with Revit edit mode transaction infos.
		/// </summary>
		private readonly List<TransactionInfo> _transactionInfos;


		public EditModeChecker()
		{
			// TODO:
			// - Check if there are more transactions and edit modes
			// - Add non-English transaction names
			_transactionInfos = new List<TransactionInfo>
			{
				new("Edit Group", "Cancel Edit Group", "Finish Edit Group"),
				new("Edit Sketch", "Edit Sketch", "Finish sketch"),
				new("Edit Assembly", "Edit Assembly", "Finish Assembly Edit"),
				new("Stairs System", "Stairs System", "Finish mode"),
				new("Modify", "Modify", "Finish Surface"),
				new("Edit Elevation Profile", "Edit Elevation Profile", "Finish sketch")
			};
		}


		/// <summary>
		/// Checks if Revit is in edit mode.
		/// </summary>
		/// <param name="transactionName">The name of the Revit transaction to check.</param>
		/// <returns>True if Revit is in 'edit mode', otherwise False.</returns>
		public bool CheckIfRevitIsInEditMode(string transactionName)
		{
			if (ActiveTransactionExists())
			{
				CheckIfTransactionIsCancelledOrFinished();
			}

			// Revit is in Edit Mode if _activeTransaction != null
			return _activeTransaction != null;


			/*
			* Check if an _activeTransaction object exists (=> Revit is in 'edit mode').
			* If not, check if the transactionName is an 'edit mode' transaction.
			*/
			bool ActiveTransactionExists()
			{
				if (_activeTransaction != null)
				{
					return true;
				}

				// no active transaction => Revit isn't in Edit mode yet
				_activeTransaction = _transactionInfos.Find(x => x.Start == transactionName);

				return false;
			}

			/*
			* Check if the active "edit" transaction is Cancelled or Finished
			*/
			void CheckIfTransactionIsCancelledOrFinished()
			{
				if (_activeTransaction.CancelledOrFinished(transactionName))
				{
					// edit mode has ended
					_activeTransaction = null;
				}
			}
		}
	}
}