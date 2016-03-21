   /*------------------------------------------------------------------
	' Author:         Matthew Klump
	' Date Created:   Feburary 9, 2003
	' Last Change Date: Feburary 9, 2003
	' Project:        Lab 4, CST 238 Winter 2003
	' Filename:       lab.c
	'
	' Overview:
	'       This program displays a window with Child Windows, Mouse
	'	   & Keyboard events, Capturing the mouse, and Timers
	'
	' Input:
	'       Input is accepted for the user by way of using the mouse
	'	   and using the arrow keys.
	'
	' Output:
	'       The output of this program is display a child window to
	'	   test the principles of mouse and keyboard event messaging.
	'---------------------------------------------------------------*/

#include <windows.h>

LRESULT CALLBACK WndProc   (HWND, UINT, WPARAM, LPARAM) ;
LRESULT CALLBACK ChildWndProc (HWND, UINT, WPARAM, LPARAM) ;

TCHAR szChildClass[] = TEXT ("Child") ;
#define CWIDTH 50
#define CHEIGHT 50

#define ID_TIMER 1

POINT pt, pPrevious;	// Mouse position
int cxClient, cyClient ; // Size of client area height

int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
                    PSTR szCmdLine, int iCmdShow)
{
     static TCHAR szAppName[] = TEXT ("Lab4") ;
	 HWND		   hwnd ;
     MSG          msg ;
     WNDCLASS     wndclass ;
     
     wndclass.style         = CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS ;
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
          MessageBox (NULL, TEXT ("Program requires Windows NT!"), 
                      szAppName, MB_ICONERROR) ;
          return 0 ;
     }
     
     wndclass.lpfnWndProc   = ChildWndProc ;
     wndclass.hIcon         = NULL ;
     wndclass.lpszClassName = szChildClass ;
	 wndclass.hbrBackground = (HBRUSH) GetStockObject (GRAY_BRUSH) ;
     
     RegisterClass (&wndclass) ;
     
     hwnd = CreateWindow (szAppName, TEXT ("Matthew Klump - Lab4"),
                          WS_OVERLAPPEDWINDOW,
                          CW_USEDEFAULT, CW_USEDEFAULT,
                          CW_USEDEFAULT, CW_USEDEFAULT,
                          NULL, NULL, hInstance, NULL) ;
     
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
     RECT        rect ;
	
	static HWND hwndChild;

	switch (message)
     {
     case WM_CREATE :
          hwndChild = CreateWindow (szChildClass, NULL,
                              WS_CHILDWINDOW | WS_VISIBLE,
                              0, 0, CWIDTH, CHEIGHT,
                              hwnd, (HMENU) (1),
                              (HINSTANCE) GetWindowLong (hwnd, GWL_HINSTANCE),
                              NULL) ;
		return 0 ;

	case WM_SETFOCUS :
          ShowCursor (TRUE) ;
          return 0 ;
          
     case WM_KILLFOCUS :
          ShowCursor (FALSE) ;
          return 0 ;
               
     case WM_LBUTTONDOWN :		
		pPrevious.x = pt.x = LOWORD(lParam) ;
		pPrevious.y = pt.y = HIWORD(lParam) ;
		MoveWindow(hwndChild, pt.x, pt.y, CWIDTH, CHEIGHT, TRUE);
          return 0 ;

	case WM_LBUTTONDBLCLK :
		pt.x = LOWORD( lParam );
		pt.y = HIWORD( lParam );
		MoveWindow(hwndChild, pt.x, pt.y, CWIDTH, CHEIGHT, TRUE);

	case WM_MOUSEMOVE :

		if ( wParam & MK_LBUTTON )
		{
			SetCapture(hwnd) ;
			pt.x = LOWORD(lParam) ;
			pt.y = HIWORD(lParam) ;
			MoveWindow(hwndChild, pt.x, pt.y,
				CWIDTH, CHEIGHT, TRUE);
		}
		return 0;

     case WM_LBUTTONUP :

		SetTimer(hwnd, ID_TIMER, 500, NULL) ;

		ReleaseCapture() ;
		InvalidateRect(hwnd, NULL, TRUE) ;
		
		return 0;

	case WM_CHAR :
		if( wParam == '\x1B' )  // i.e. the Escape Key
		{
			ReleaseCapture() ;
			pt.y = cyClient ; // Effectively kill the timer
			MoveWindow(hwndChild, pPrevious.x, pPrevious.y,
				CWIDTH, CHEIGHT, TRUE) ;
		}
		return 0;

	case WM_TIMER :
		
		if( pt.y + CHEIGHT >= cyClient )
		{
			KillTimer(hwnd, ID_TIMER) ;
			return 0;
		}
		else
		{
			pt.y += 10 ;
			MoveWindow(hwndChild, pt.x, pt.y,
				CWIDTH, CHEIGHT, TRUE) ;
			return 0;
		}

	case WM_SIZE :
		cxClient = LOWORD( lParam ) ;
		cyClient = HIWORD( lParam ) ;
		return 0 ;

     case WM_PAINT :
          hdc = BeginPaint (hwnd, &ps) ;
          GetClientRect (hwnd, &rect) ;
          EndPaint (hwnd, &ps) ;
          return 0 ;

	case WM_KEYDOWN :
	{
		switch (wParam)
		{
		case VK_HOME :
			MoveWindow(hwndChild, 0, 0,
					CWIDTH, CHEIGHT, TRUE) ;
			return 0 ;
		case VK_END :
			MoveWindow(hwndChild, cxClient - CWIDTH,
					cyClient - CHEIGHT,
					CWIDTH, CHEIGHT, TRUE) ;
			return 0 ;
	
		case VK_LEFT :
			pt.y = cyClient ;
			if( pPrevious.x <= 0 )
				return 0 ;
			else
			{
				MoveWindow(hwndChild, pPrevious.x -= 20,
					pPrevious.y, CWIDTH, CHEIGHT, TRUE) ;
				return 0 ;
			}

		case VK_RIGHT :
			pt.y = cyClient ;
			if( pPrevious.x >= cxClient )
			{
				MoveWindow(hwndChild,
					pPrevious.x - CWIDTH,
					pPrevious.y,
					CWIDTH, CHEIGHT, TRUE) ;
				return 0 ;
			}
			else
			{
				MoveWindow(hwndChild, pPrevious.x += 20,
					pPrevious.y, CWIDTH, CHEIGHT, TRUE) ;
				return 0 ;
			}
			
		case VK_UP :
		case VK_PRIOR:
			pt.y = cyClient ;
			if( pPrevious.y <= 0 )
				return 0 ;
			else
			{
				MoveWindow(hwndChild, pPrevious.x,
					pPrevious.y -= 20, CWIDTH, CHEIGHT, TRUE) ;
				return 0 ;
			}

		case VK_DOWN :
		case VK_NEXT:
			pt.y = cyClient ;
			if( pPrevious.y >= cyClient )
			{
				MoveWindow(hwndChild, pPrevious.x,
					pPrevious.y - CHEIGHT,
					CWIDTH, CHEIGHT, TRUE) ;
				return 0 ;
			}
			else
			{
				MoveWindow(hwndChild, pPrevious.x,
					pPrevious.y += 20, CWIDTH, CHEIGHT, TRUE) ;
				return 0 ;
			}
		}
	}

     case WM_DESTROY :
          PostQuitMessage (0) ;
		KillTimer(hwnd, ID_TIMER);
          return 0 ;
     }
     return DefWindowProc (hwnd, message, wParam, lParam) ;
}


LRESULT CALLBACK ChildWndProc (HWND hwnd, UINT message, 
                               WPARAM wParam, LPARAM lParam)
{
     HDC         hdc ;
     PAINTSTRUCT ps ;
     RECT        rect ;
     
     switch (message)
     {
     case WM_CREATE :
          return 0 ;
          
     case WM_LBUTTONDOWN :
		pt.y = cyClient ; // Effectively kill the timer
		return 0 ;
          
     case WM_PAINT :
          hdc = BeginPaint (hwnd, &ps) ;
          GetClientRect (hwnd, &rect) ;
          EndPaint (hwnd, &ps) ;
          return 0 ;
     }
     return DefWindowProc (hwnd, message, wParam, lParam) ;
}
