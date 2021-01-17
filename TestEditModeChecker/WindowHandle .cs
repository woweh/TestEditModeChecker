using System;
using System.Windows.Forms;

namespace TestEditModeChecker
{
	/// <summary>
	/// Wrapper for Win32 HWND handles.
	/// </summary>
	/// <remarks>
	/// Based upon:
	/// https://thebuildingcoder.typepad.com/blog/2010/06/revit-parent-window.html
	/// </remarks>
	public class WindowHandle : IWin32Window
	{
		public WindowHandle(IntPtr hWnd)
		{
			Handle = hWnd;
		}

		/// <summary>Gets the handle to the window represented by the implementer.</summary>
		/// <returns>A handle to the window represented by the implementer.</returns>
		public IntPtr Handle { get; }
	}
}