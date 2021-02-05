
# TestEditModeChecker

![Revit API 2018](https://img.shields.io/badge/Revit%20API-2018-blue.svg)
![.NET](https://img.shields.io/badge/.NET-4.6-blue.svg)
&nbsp;&nbsp;
![Revit API 2019](https://img.shields.io/badge/Revit%20API-2019-blue.svg)
![.NET](https://img.shields.io/badge/.NET-4.7-blue.svg)
&nbsp;&nbsp;
![Revit API 2020](https://img.shields.io/badge/Revit%20API-2020-blue.svg)
![.NET](https://img.shields.io/badge/.NET-4.7.1-blue.svg)
&nbsp;&nbsp;
![Revit API 2021](https://img.shields.io/badge/Revit%20API-2021-blue.svg)
![.NET](https://img.shields.io/badge/.NET-4.8-blue.svg)

![Platform](https://img.shields.io/badge/Platform-Windows-lightgray.svg)
&nbsp;&nbsp;
[![License](http://img.shields.io/:License-MIT-blue.svg)](http://opensource.org/licenses/MIT)


## C# Revit add-in to test if Revit is in Edit Mode.
This Revit add-in shows one technique how to detect if Revit is in some kind of 'Edit Mode'.
This work was inspired by the reply of Ahmed Nabil in the Revit API forums:<br>
https://forums.autodesk.com/t5/revit-api-forum/group-edit-event/m-p/9232010/highlight/true#M43668

It works not only for detecting 'Edit Group' mode, but all kinds of edit modes (Edit Assembly, Edit Profile, Edit Stairs, etc...). 
The technique uses the Revit transaction names to see if a transaction has been started, cancelled or finished.

The add-on might not yet detect all kinds of edit modes.<br>
The author hasn't tested all kinds of edit modes, 
but the list with transactions to detect edit modes can easily be extended, 
see [constructor of class EditModeChecker](TestEditModeChecker/EditModeChecker.cs#L6).

Also, this has only been tested with English language versions of Revit.<br>
The transaction names probably need translating for non-English versions.


## Use Case
Executing Revit API actions from a non-modal (modeless) dialogue, using External Events (> IExternalEventHandler), 
can produce unexpected results when Revit is in some kind of edit mode.

When starting an action from a non-modal dialogue, the action gets queued and only executed ones Revit is ready to execute the action.
When Revit is in some kind of 'edit mode' this can be some time after the action was queued, 
and the context might have changed significantly, which can render the input invalid.

In that case you might want to stop the user from executing the action in the first place.


## References
* https://forums.autodesk.com/t5/revit-api-forum/group-edit-event/m-p/9232010/highlight/true#M43668
* https://forums.autodesk.com/t5/revit-api-forum/detecting-modify-mode-aka-edit-mode/m-p/5616006
* https://thebuildingcoder.typepad.com/files/external_events_knowledgebase.html


## Sreenshots
Start the "Edit Mode Checker" addin:
![Start the "Edit Mode Checker" addin](Screenshots/0-StartEditModeChecker.png)

"Edit Group" mode detected:
!["Edit Group" mode detected](Screenshots/1-EditGroupMode.png)

"Edit Group" mode cancelled:
!["Edit Group" mode cancelled](Screenshots/2-EndEditGroupMode.png)


"Edit Stairs" mode detected:
!["Edit Stairs" mode detected:](Screenshots/3-EditStairsMode.png)

"Edit Stairs" mode cancelled:
!["Edit Stairs" mode cancelled:](Screenshots/4-EndEditStairsMode.png)


"Edit Profile" mode detected:
!["Edit Profile" mode detected:](Screenshots/5-EditProfileMode.png)

"Edit Profile" mode cancelled:
!["Edit Profile" mode cancelled:](Screenshots/6-EndEditProfileMode.png)


## Author
Wolfgang Weh,
[Neanex](https://www.neanex.com)


## License
This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT).
