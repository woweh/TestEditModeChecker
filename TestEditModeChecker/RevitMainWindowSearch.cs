using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;


namespace TestEditModeChecker
{
	/// <summary>
	/// Helper class to search/get the Revit main window.
	/// </summary>
	/// <remarks>
	/// Based upon:
	/// https://thebuildingcoder.typepad.com/blog/2017/10/modeless-form-keep-revit-focus-and-on-top.html
	/// </remarks>
	public static class RevitMainWindowSearch
	{
		#region Windows API / PInvoke Methods

		// User32.dll calls used to get the Main Window for a Process Id (PID)
		private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

		[DllImport("user32.DLL")]
		private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

		[DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
		private static extern IntPtr GetParent(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

		[DllImport("user32.DLL")]
		private static extern IntPtr GetShellWindow();

		[DllImport("user32.DLL")]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		[DllImport("user32.DLL")]
		private static extern int GetWindowTextLength(IntPtr hWnd);

		[DllImport("user32.DLL")]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		#endregion


		#region Static methods

		/// <summary>
		/// Get the window handle of the Revit Main Window.
		/// </summary>
		public static WindowHandle GetWindowHandle()
		{
			Process revitProcess = Process.GetCurrentProcess();

			IntPtr revitMainWindowHandle = FindMainWindow(revitProcess.Id);

			return revitMainWindowHandle == IntPtr.Zero
				? new WindowHandle(revitProcess.MainWindowHandle)
				: new WindowHandle(revitMainWindowHandle);
		}

		/// <summary>
		/// Returns the main Window Handle for the Process Id (pid) passed in.
		/// IF the Main Window is not found then a handle value of Zero is returned, no handle.
		/// </summary>
		/// <param name="pid">The Revit Process ID.</param>
		/// <returns></returns>
		private static IntPtr FindMainWindow(int pid)
		{
			IntPtr shellWindow = GetShellWindow();

			List<IntPtr> windowsForPid = new List<IntPtr>();

			try
			{
				EnumWindows(
					// EnumWindowsProc Function, does the work on each window.
					// ReSharper disable once UnusedParameter.Local
					delegate(IntPtr hWnd, int lParam)
					{
						if (hWnd == shellWindow)
						{
							return true;
						}

						if (!IsWindowVisible(hWnd))
						{
							return true;
						}

						GetWindowThreadProcessId(hWnd, out uint windowPid);

						// if window is from Pid of interest, see if it's the Main Window
						if (windowPid == pid)
						{
							// By default Main Window has a Parent Window of Zero, no parent.
							IntPtr parentHWnd = GetParent(hWnd);

							if (parentHWnd == IntPtr.Zero)
							{
								windowsForPid.Add(hWnd);
							}
						}

						return true;
					}
					// lParam, nothing, null...
				     ,
					0
					);
			}
			catch (Exception)
			{
				// ignored
			}

			return DetermineMainWindow(windowsForPid);
		}

		/// <summary>
		/// Find the Revit Main Window from the list of window handles passed in.
		/// If the Main Window for Revit is not found then a Null (IntPtr.Zero) handle is returned.
		/// </summary>
		/// <param name="handles">The list with window handles to examine</param>
		/// <returns></returns>
		private static IntPtr DetermineMainWindow(IReadOnlyList<IntPtr> handles)
		{
			// Safety conditions, bail if not met.
			if (handles == null || handles.Count <= 0)
			{
				return IntPtr.Zero;
			}

			// only one window so return it, must be the Main Window??
			if (handles.Count == 1)
			{
				return handles[0];
			}

			// more than one candidate for Main Window so find the Main Window by its Title,
			// it will contain "Autodesk Revit"
			foreach (IntPtr hWnd in handles)
			{
				int length = GetWindowTextLength(hWnd);

				if (length == 0)
				{
					continue;
				}

				StringBuilder builder = new StringBuilder(length);

				GetWindowText(hWnd, builder, length + 1);

				// Depending on the Title of the Main Window 
				// to have "Autodesk Revit" in it.
				if (builder.ToString().ToLower().Contains("autodesk revit"))
				{
					// found Main Window stop and return it.
					return hWnd;
				}
			}

			return IntPtr.Zero;
		}

		#endregion
	}
}