    /*----------------------------------------------------------------
	' Author:         Matthew Klump
	' Date Created:   Feburary 16, 2003
	' Last Change Date: Feburary 16, 2003
	' Project:        Lab 5, CST 238 Winter 2003
	' Filename:       Lab5ControlsMenus.c
	'
	' Overview:
	'       This program displays a variety of controls it the client
	'	   area for demonstration such as icons, listboxes, and menus.
	'
	' Input:
	'       Input is accepted for the user by way of using the mouse
	'	   and keyboard with the GUI controls.
	'
	' Output:
	'       The output of this program is display a child window to
	'	   the screen in various child windows
	'---------------------------------------------------------------*/

#include <windows.h>
#include "resource.h"

LRESULT CALLBACK WndProc (HWND, UINT, WPARAM, LPARAM) ;

HMENU	   hMenu;  // For the time being need for Modulus access
static HWND hStaticText1, hAddButton,
		  hDeleteButton, hStaticText2,
		  hDisableButton, hwndChild;

int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
                    PSTR szCmdLine, int iCmdShow)
{
     static TCHAR szAppName[] = TEXT ("Lab5ControlsMenus") ;
     HWND         hwnd ;
	HANDLE hAccel;
     MSG          msg ;
     WNDCLASS     wndclass ;

	hMenu = LoadMenu( hInstance, MAKEINTRESOURCE(IDR_MENU1) );

     wndclass.style         = CS_HREDRAW | CS_VREDRAW ;
     wndclass.lpfnWndProc   = WndProc ;
     wndclass.cbClsExtra    = 0 ;
     wndclass.cbWndExtra    = 0 ;
     wndclass.hInstance     = hInstance ;
     wndclass.hIcon         = LoadIcon (NULL, IDI_APPLICATION) ;
     wndclass.hCursor       = LoadCursor (NULL, IDC_ARROW) ;
     wndclass.hbrBackground = (HBRUSH) GetStockObject (WHITE_BRUSH) ;
     wndclass.lpszMenuName  = NULL ;
     wndclass.lpszClassName = szAppName ;

     if (!RegisterClass (&wndclass))
     {
          MessageBox (NULL, TEXT ("This program requires Windows NT!"), 
                      szAppName, MB_ICONERROR) ;
          return 0 ;
     }
     
     hwnd = CreateWindow (szAppName,                  // window class name
                          TEXT ("Lab 5 - Child Window ")
					 TEXT ("Controls and Menus"),// window caption
                          WS_OVERLAPPEDWINDOW,        // window style
                          CW_USEDEFAULT,              // initial x position
                          CW_USEDEFAULT,              // initial y position
                          CW_USEDEFAULT,              // initial x size
                          CW_USEDEFAULT,              // initial y size
                          NULL,                       // parent window handle
                          hMenu,                      // window menu handle
                          hInstance,                  // program instance handle
                          NULL) ;                     // creation parameters
     
     ShowWindow (hwnd, iCmdShow) ;
     UpdateWindow (hwnd) ;

	SetMenu(hwnd, hMenu);
	hAccel = LoadAccelerators(hInstance, TEXT("IDR_ACCELERATOR1"));
     
     while (GetMessage (&msg, NULL, 0, 0))
     {
		if(!TranslateAccelerator(hwnd, hAccel, &msg))
		{
			TranslateMessage (&msg) ;
			DispatchMessage (&msg) ;
		}
     }
     return msg.wParam ;
}

LRESULT CALLBACK WndProc (HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
     HDC         hdc ;
     PAINTSTRUCT ps ;
     RECT        rect ;

	int cxChar, cyChar;
	LONG id;

     switch (message)
     {
     case WM_CREATE:
		cxChar = LOWORD( GetDialogBaseUnits() );
		cyChar = HIWORD( GetDialogBaseUnits() );

		hStaticText1 = CreateWindow( TEXT("static"), TEXT("Main menu:"),
							   WS_CHILD | WS_VISIBLE | SS_CENTER,
							   cxChar, cyChar, cxChar * 13,
							   cyChar + 3, hwnd, NULL, NULL,
							   NULL );

		hAddButton = CreateWindow( TEXT("button"), TEXT("Add"),
							   WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
							   cxChar, cyChar * 3, cxChar * 13,
							   cyChar + 3, hwnd, NULL, NULL,
							   NULL );

		hDeleteButton = CreateWindow( TEXT("button"), TEXT("Delete"),
							   WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
							   cxChar * 15, cyChar * 3, cxChar * 13,
							   cyChar + 3, hwnd, NULL, NULL,
							   NULL );

		hStaticText2 = CreateWindow( TEXT("static"), TEXT("Buttons:"),
							   WS_CHILD | WS_VISIBLE | SS_CENTER,
							   cxChar, cyChar * 5, cxChar * 13,
							   cyChar + 3, hwnd, NULL, NULL,
							   NULL );

		hDisableButton = CreateWindow( TEXT("button"), TEXT("Disable"),
							   WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
							   cxChar, cyChar * 7, cxChar * 13,
							   cyChar + 3, hwnd, NULL, NULL,
							   NULL );
          return 0 ;

	case WM_COMMAND:
		id = GetDlgCtrlID( hwnd );
		/*hwndChild = GetDlgItem(hwnd, id);

		switch ( HIWORD(wParam) )
		{
		case id:
			SendMessage(hwnd, WM_COMMAND, ID_MAIN_ADD, hwndChild);
			return 0;

		case id:
			SendMessage(hwnd, WM_COMMAND, ID_MAIN_DELETE, hwndChild);
			return 0;
		}*/

		switch ( LOWORD(wParam) )
		{
		case ID_MAIN_ADD:
			
			InsertMenu(hMenu, ID_MAIN_PRECEDE, MF_STRING,
				ID_MAIN_OPTION, TEXT("&Option \tCtrl+O"));
			
			DrawMenuBar( hwnd );
			return 0;

		case ID_MAIN_DELETE:

			DeleteMenu(hMenu, ID_MAIN_OPTION, NULL);

			DrawMenuBar( hwnd );
			return 0;
		}
          
     case WM_PAINT:
          hdc = BeginPaint (hwnd, &ps) ;          
          GetClientRect (hwnd, &rect) ;
          EndPaint (hwnd, &ps) ;
          return 0 ;
          
     case WM_DESTROY:
          PostQuitMessage (0) ;
          return 0 ;
     }
     return DefWindowProc (hwnd, message, wParam, lParam) ;
}