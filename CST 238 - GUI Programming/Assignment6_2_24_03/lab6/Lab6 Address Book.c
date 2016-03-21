    /*----------------------------------------------------------------
	' Author:         Matthew Klump
	' Date Created:   Feburary 21, 2003
	' Last Change Date: Feburary 21, 2003
	' Project:        Lab 6, CST 238 Winter 2003
	' Filename:       Lab6 Address Book.c
	'
	' Overview:
	'       This program is a rudimentary address book containing eight
	'		controls within the main app window for functionality.
	'
	' Input:
	'       Input is accepted from the user by way of two EDIT class
	'		controls along with three button controls for the main
	'		address book functionality.
	'
	' Output:
	'       The output of this program is display to a LISTBOX class
	'		control.
	'---------------------------------------------------------------*/

#include <windows.h>

// hard-coded maximum size for number of entries, and the 
// length of the name & number text in each entry
#define MAX_SIZE 100

// a structure to hold the information for a single entry
typedef struct
{
     TCHAR   szName[MAX_SIZE] ;
     TCHAR   szNumber[MAX_SIZE] ;
} ABentry;

// an array of entries
ABentry entry[MAX_SIZE];

// store the application instance variable so the wndproc 
// doesn't have to recreate it.
HINSTANCE hInst;

// a unique ID for each child window control (except static text)
enum {IDS_NAME=50000, IDE_NAME, IDS_NUMBER, IDE_NUMBER,
		IDB_ADD, IDB_REPLACE, IDB_CLEAR, IDL_LIST, IDB_DELETE};


LRESULT CALLBACK WndProc (HWND, UINT, WPARAM, LPARAM) ;

int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
                    PSTR szCmdLine, int iCmdShow)
{
     static TCHAR szAppName[] = TEXT ("Lab6-AddressBook") ;
     HWND         hwnd ;
     MSG          msg ;
     WNDCLASS     wndclass ;

     wndclass.style         = CS_HREDRAW | CS_VREDRAW ;
     wndclass.lpfnWndProc   = WndProc ;
     wndclass.cbClsExtra    = 0 ;
     wndclass.cbWndExtra    = 0 ;
     wndclass.hInstance     = hInstance ;
     wndclass.hIcon         = LoadIcon (NULL, IDI_APPLICATION) ;
     wndclass.hCursor       = LoadCursor (NULL, IDC_ARROW) ;
     wndclass.hbrBackground = (HBRUSH) (COLOR_BTNFACE + 1); 
	 wndclass.lpszMenuName  = NULL ;
     wndclass.lpszClassName = szAppName ;

     if (!RegisterClass (&wndclass))
     {
          MessageBox (NULL, TEXT ("This program requires Windows NT!"), 
                      szAppName, MB_ICONERROR) ;
          return 0 ;
     }

	 hInst = hInstance;
     
     hwnd = CreateWindow (szAppName,					// window class name
                          TEXT ("Matthew Klump Lab6 - Address Book"),	// window caption
                          WS_OVERLAPPEDWINDOW,			// window style
                          CW_USEDEFAULT,				// initial x position
                          CW_USEDEFAULT,				// initial y position
                          500,							// initial x size
                          300,							// initial y size
                          NULL,							// parent window handle
                          NULL,							// window menu handle
                          hInstance,					// program instance handle
                          NULL) ;						// creation parameters
     
     ShowWindow (hwnd, iCmdShow) ;
     UpdateWindow (hwnd) ;
     
     while (GetMessage (&msg, NULL, 0, 0))
     {
          TranslateMessage (&msg) ;
          DispatchMessage (&msg) ;
     }
     return msg.wParam ;
}

LRESULT CALLBACK WndProc (HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
     HDC         hdc ;
     PAINTSTRUCT ps ;
     UINT        msg ;
     TCHAR       buffer1[MAX_SIZE], buffer2[MAX_SIZE] ;
	 static int cxChar, cyChar,     // Character dimentions
                cTab = -1,          // Attempted to use for tab index order
                iIndex = 0,         // For the listbox entries
                i ;                 // Loop variable

     // Below, I've included handles to all eight controls we'll need for
     // the enumerated control ID's you have provided - MJK
     static HWND hwndSName, hwndSNumber, hwndEName, hwndENumber,
                 hwndBAdd, hwndBReplace, hwndBClear, hwndLList,
                 hwndBDelete ;

     switch (message)
     {
     case WM_CREATE:
         cxChar = LOWORD( GetDialogBaseUnits() );
         cyChar = HIWORD( GetDialogBaseUnits() );

         hwndSName = CreateWindow( TEXT("static"), TEXT("Name:"),
                            WS_CHILD | WS_VISIBLE | SS_LEFT,
                            cxChar * 1.5, cyChar * 1.5, cxChar * 15.0, cyChar * 1.5,
                            hwnd, (HMENU) IDS_NAME,
                            (HINSTANCE) GetWindowLong( hwnd, GWL_HINSTANCE ),
                            NULL ) ;

         hwndSNumber = CreateWindow( TEXT("static"), TEXT("Number:"),
                            WS_CHILD | WS_VISIBLE | SS_LEFT,
                            cxChar * 1.5, cyChar * 3.5, cxChar * 15.0, cyChar * 1.5,
                            hwnd, (HMENU) IDS_NUMBER,
                            (HINSTANCE) GetWindowLong( hwnd, GWL_HINSTANCE ),
                            NULL ) ;

         hwndEName = CreateWindow( TEXT("edit"), NULL,
                            WS_CHILD | WS_VISIBLE | WS_BORDER | ES_LEFT,
                            cxChar * 16.0, cyChar * 1.5, cxChar * 15.0, cyChar * 1.5,
                            hwnd, (HMENU) IDE_NAME,
                            (HINSTANCE) GetWindowLong( hwnd, GWL_HINSTANCE ),
                            NULL ) ;

         hwndENumber = CreateWindow( TEXT("edit"), NULL,
                            WS_CHILD | WS_VISIBLE | WS_BORDER | ES_LEFT,
                            cxChar * 16.0, cyChar * 3.5, cxChar * 15.0, cyChar * 1.5,
                            hwnd, (HMENU) IDE_NUMBER,
                            (HINSTANCE) GetWindowLong( hwnd, GWL_HINSTANCE ),
                            NULL ) ;

         hwndBAdd = CreateWindow( TEXT("button"), TEXT("Add"),
                            WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
                            cxChar * 1.5, cyChar * 6.5, cxChar * 11.0, cyChar * 2.0,
                            hwnd, (HMENU) IDB_ADD,
                            (HINSTANCE) GetWindowLong( hwnd, GWL_HINSTANCE ),
                            NULL ) ;

         hwndBReplace = CreateWindow( TEXT("button"), TEXT("Replace"),
                            WS_CHILD | WS_VISIBLE | WS_DISABLED | BS_PUSHBUTTON,
                            cxChar * 13.0, cyChar * 6.5, cxChar * 11.0, cyChar * 2.0,
                            hwnd, (HMENU) IDB_REPLACE,
                            (HINSTANCE) GetWindowLong( hwnd, GWL_HINSTANCE ),
                            NULL ) ;

         hwndBClear = CreateWindow( TEXT("button"), TEXT("Clear"),
                            WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
                            cxChar * 24.5, cyChar * 6.5, cxChar * 11.0, cyChar * 2.0,
                            hwnd, (HMENU) IDB_CLEAR,
                            (HINSTANCE) GetWindowLong( hwnd, GWL_HINSTANCE ),
                            NULL ) ;
         
         hwndBDelete = CreateWindow( TEXT("button"), TEXT("Delete"),
                            WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
                            cxChar * 1.5, cyChar * 9.0, cxChar * 11.0, cyChar * 2.0,
                            hwnd, (HMENU) IDB_DELETE,
                            (HINSTANCE) GetWindowLong( hwnd, GWL_HINSTANCE ),
                            NULL ) ;

         hwndLList = CreateWindow( TEXT("listbox"), NULL,
                            WS_CHILD | WS_VISIBLE | LBS_STANDARD,
                            cxChar * 38.0, cyChar * 1.5, cxChar * 20.0, cyChar * 15.0,
                            hwnd, (HMENU) IDL_LIST,
                            (HINSTANCE) GetWindowLong( hwnd, GWL_HINSTANCE ),
                            NULL ) ;
         return 0 ;

     case WM_KEYDOWN :
		if( wParam == VK_TAB )  // i.e. the Tab Key
		{
            cTab <= 5 ? cTab++ : (cTab = 0) ;

            switch( cTab )
            {
            case 0:
                SetFocus( hwndEName ) ;
                return 0 ;
            case 1:
                SetFocus( hwndENumber ) ;
                return 0 ;
            case 2:
                SetFocus( hwndBAdd ) ;
                return 0 ;
            case 3:
                SetFocus( hwndBReplace ) ;
                return 0 ;
            case 4:
                SetFocus( hwndBClear ) ;
                return 0 ;
            case 5:
                SetFocus( hwndLList ) ;
                return 0 ;
            }
		}

	 case WM_COMMAND:

		switch (LOWORD(wParam))
        {

		case IDB_ADD :	//add/edit button
            SendMessage( hwndEName, WM_GETTEXT, (WPARAM)100, (LPARAM)buffer1 ) ;
            SendMessage( hwndENumber, WM_GETTEXT, (WPARAM)100, (LPARAM)buffer2 ) ;
            if( strcmp((const char*)buffer1, "" ) == 0 || strcmp((const char*)buffer2, "" ) == 0 )
            {
                MessageBox( hwnd, TEXT("Enter a name and a number."),
			            TEXT("ERROR"), MB_ICONERROR | MB_DEFBUTTON1);
                return 0;
            }
            
            for( i = MAX_SIZE - 1; i > iIndex; --i )
            {
                wsprintf( entry[i].szName, entry[i - 1].szName ) ;
                wsprintf( entry[i].szNumber, entry[i - 1].szNumber ) ;
            }

            SendMessage( hwndEName, WM_GETTEXT, (WPARAM)100, (LPARAM)entry[iIndex].szName ) ;
            SendMessage( hwndENumber, WM_GETTEXT, (WPARAM)100, (LPARAM)entry[iIndex].szNumber ) ;
            SendMessage( hwndLList, LB_INSERTSTRING, (WPARAM)iIndex, (LPARAM)entry[iIndex].szName ) ;
            SendMessage( hwndLList, LB_SETCURSEL, (WPARAM)iIndex, (LPARAM)0 ) ;
			return 0 ;

		case IDB_REPLACE : //replace button

            SendMessage( hwndEName, WM_GETTEXT, (WPARAM)100, (LPARAM)buffer1 ) ;
            SendMessage( hwndENumber, WM_GETTEXT, (WPARAM)100, (LPARAM)buffer2 ) ;
            if( strcmp((const char*)buffer1, "" ) == 0 || strcmp((const char*)buffer2, "" ) == 0 )
            {
                MessageBox( hwnd, TEXT("Enter a name and a number."),
			            TEXT("ERROR"), MB_ICONERROR | MB_DEFBUTTON1);
                return 0 ;
            }

            SendMessage( hwndEName, WM_GETTEXT, (WPARAM)100, (LPARAM)entry[iIndex].szName ) ;
            SendMessage( hwndENumber, WM_GETTEXT, (WPARAM)100, (LPARAM)entry[iIndex].szNumber ) ;
            SendMessage( hwndLList, LB_DELETESTRING, (WPARAM)iIndex, (LPARAM)0 ) ;
            SendMessage( hwndLList, LB_INSERTSTRING, (WPARAM)iIndex, (LPARAM)entry[iIndex].szName ) ;
            SendMessage( hwndLList, LB_SETCURSEL, (WPARAM)iIndex, (LPARAM)0 ) ;
			return 0 ;

		case IDB_CLEAR : //clear button
            SendMessage( hwndEName, WM_SETTEXT, (WPARAM)0, (LPARAM)TEXT("") ) ;
            SendMessage( hwndENumber, WM_SETTEXT, (WPARAM)0, (LPARAM)TEXT("") ) ;
            SendMessage( hwndLList, LB_SETCURSEL, (WPARAM)-1, (LPARAM)0 ) ;
            EnableWindow( hwndBReplace, FALSE ) ;
			return 0 ;

		case IDL_LIST :	// listbox
            msg = SendMessage( hwndLList, LB_GETCURSEL, (WPARAM)0, (LPARAM)0 ) ;
            iIndex = (int) msg ;
            SendMessage( hwndEName, WM_SETTEXT, (WPARAM)0, (LPARAM)entry[iIndex].szName ) ;
            SendMessage( hwndENumber, WM_SETTEXT, (WPARAM)0, (LPARAM)entry[iIndex].szNumber ) ;
            EnableWindow( hwndBReplace, TRUE ) ;
			return 0 ;

        case IDB_DELETE : // delete button
            SendMessage( hwndLList, LB_DELETESTRING, (WPARAM)iIndex, (LPARAM)0 ) ;
            for( i = iIndex; i < MAX_SIZE; ++i )
            {
                wsprintf( entry[i].szName, entry[i + 1].szName ) ;
                wsprintf( entry[i].szNumber, entry[i + 1].szNumber ) ;
            }
            SendMessage( hwndLList, LB_SETCURSEL, (WPARAM)iIndex, (LPARAM)0 ) ;

            SendMessage( hwndEName, WM_SETTEXT, (WPARAM)0, (LPARAM)TEXT("") ) ;
            SendMessage( hwndENumber, WM_SETTEXT, (WPARAM)0, (LPARAM)TEXT("") ) ;
            
            return 0 ;
		}
		break;


     case WM_PAINT:
        hdc = BeginPaint (hwnd, &ps) ;          
        EndPaint (hwnd, &ps) ;
        return 0 ;
          
     case WM_DESTROY:
        PostQuitMessage (0) ;
        return 0 ;
     }

     return DefWindowProc (hwnd, message, wParam, lParam) ;
}