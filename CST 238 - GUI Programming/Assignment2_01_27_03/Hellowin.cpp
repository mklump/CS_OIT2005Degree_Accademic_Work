   /*------------------------------------------------------------------
	' Author:         Matthew Klump
	' Date Created:   January 17, 2003
	' Last Change Date: January 18, 2003
	' Project:        Lab 2, CST 238 Winter 2003
	' Filename:       Hellowin.c
	'
	' Overview:
	'       This program presents a single window that demonstrates
	'		creating and drawing a window to the screen as well as
	'		updating it.
	'
	' Input:
	'       Input is accepted for the user by pressing one of two
	'		buttons to draw random rectangles or a clover.
	' Output:
	'       The output of this program is a window displayed on the
	'		screen that demonstrates practicing a number of techniques
	'		related to creating a simple window, displaying text and
	'		graphics, and processing some simple mouse messages.
	'------------------------------------------------------------------*/

#include <windows.h>
#include <math.h>   // For the clover portion of this program.
#include <stdlib.h> // For the rand function used with DrawRectangle();

#define TWO_PI (2.0 * 3.14159) // For the clover portion of this program.

LRESULT CALLBACK WndProc (HWND, UINT, WPARAM, LPARAM) ;
void DrawRectangle( HWND );

static int cxClient, cyClient; // For the width and height of client area

int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
                    PSTR szCmdLine, int iCmdShow)
{
     static TCHAR szAppName[] = TEXT ("Matthew Klump - Lab 2 ")
								TEXT ("Text and Graphics") ;
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
	 // Wanted windows to paint the background gray.
     wndclass.hbrBackground = (HBRUSH) GetStockObject (LTGRAY_BRUSH) ;
     wndclass.lpszMenuName  = NULL ;
     wndclass.lpszClassName = szAppName ;

     if (!RegisterClass (&wndclass))
     {
          MessageBox (NULL, TEXT ("This program requires Windows NT!"), 
                      szAppName, MB_ICONERROR) ;
          return 0 ;
     }
     
     hwnd = CreateWindow (szAppName,                  // window class name
                          TEXT ("Matthew Klump - Lab 2 ")
						  TEXT ("Text and Graphics"), // window caption
                          WS_OVERLAPPEDWINDOW |		  // window style
								WS_HSCROLL |		  // Include horizontal
								WS_VSCROLL,			  // and vertical scroll bars.
                          CW_USEDEFAULT,              // initial x position
                          CW_USEDEFAULT,              // initial y position
                          CW_USEDEFAULT,              // initial x size
                          CW_USEDEFAULT,              // initial y size
                          NULL,                       // parent window handle
                          NULL,                       // window menu handle
                          hInstance,                  // program instance handle
                          NULL) ;                     // creation parameters
     
     ShowWindow (hwnd, iCmdShow) ;
     UpdateWindow (hwnd) ;
     
     while( TRUE )
	 {
		 if( PeekMessage( &msg, NULL, 0, 0, PM_REMOVE ) )
		 {
			 if( msg.message == WM_QUIT )
				 break;

			 TranslateMessage( &msg );
			 DispatchMessage( &msg );
		 }
		 else
			 DrawRectangle( hwnd );
	 }
     return msg.wParam ;
}

LRESULT CALLBACK WndProc (HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
     static int  cxChar, cyChar, cxCaps, // For the character height and width
				 imbStatus1, imbStatus2; // For the status returned by the MessageBox()
	 static HRGN hRgnClip ; // For the clover portion of this program.
	 double fAngle, fRadius;// "
	 HCURSOR hCursor;		// "
	 HRGN hRgnTemp[6];		// "
	 int i;					// Loop Variablet
	 TCHAR buffer[1024];
     HDC         hdc ;
     PAINTSTRUCT ps ;
     RECT        rect ;
	 TEXTMETRIC  tm ;
     
     switch (message)
     {
     case WM_CREATE:
		  hdc = GetDC (hwnd) ;

		  // Calculate the character height and width of lowercase letters
		  // as well as the width of uppercase letters
          GetTextMetrics (hdc, &tm) ;
          cxChar = tm.tmAveCharWidth ;
          cxCaps = (tm.tmPitchAndFamily & 1 ? 3 : 2) * cxChar / 2 ;
          cyChar = tm.tmHeight + tm.tmExternalLeading ;

		  imbStatus2 = MessageBox(hwnd,TEXT("Press OKAY to draw a clover.\n")
			  TEXT("Press CANCEL to draw random rectangles."),
			  TEXT("What do I display?"),
			  MB_OKCANCEL | MB_ICONQUESTION | MB_DEFBUTTON1);

          ReleaseDC( hwnd, hdc );
		  return 0;
          
     case WM_PAINT:
          hdc = BeginPaint( hwnd, &ps );
          
          GetClientRect (hwnd, &rect) ;
          
		  // Print the source TCHAR literal into the buffer and 
		  // print the the buffer to the screen at position x = 0 and y = 0.
		  TextOut(hdc, 0, 0, buffer, wsprintf(buffer, TEXT("Average ")
						TEXT("character width = %i, height = %i."), cxChar, cyChar));

		  // Print the width and height of the client area
		  TextOut(hdc, 0, cyChar, buffer,
						wsprintf(buffer, TEXT("Client area is %i by %i."),
						cxClient, cyClient)) ;

		  // Print the number of lines that can be displayed
		  TextOut(hdc, 0, cyChar * 2, buffer, wsprintf(buffer, TEXT("This window ")
					  TEXT("can dispaly %i lines of text."), cyClient / cyChar));
		  TextOut(hdc, 0, cyChar * 3, buffer, wsprintf(buffer, TEXT("Resize me.")));

          if( imbStatus2 == IDOK )
		  {
			  SetViewportOrgEx(hdc, cxClient / 2, cyClient / 2, NULL);
			  SelectClipRgn(hdc, hRgnClip);

			  fRadius = _hypot(cxClient / 2.0, cyClient / 2.0);

			  for( fAngle = 0.0; fAngle < TWO_PI; fAngle += TWO_PI / 360)
			  {
				  MoveToEx( hdc, 0, 0, NULL);
				  LineTo( hdc, (int)(fRadius * cos( fAngle ) + 0.5),
							   (int)(-fRadius * sin( fAngle ) + 0.5));
			  }
		  }
		  else
		  {
			  imbStatus2 = IDCANCEL;
		  }

          EndPaint (hwnd, &ps) ;
          return 0 ;

	 case WM_SIZE:
		 cxClient = LOWORD( lParam );
		 cyClient = HIWORD( lParam );
		 
		 if( imbStatus2 == IDOK )
		 {
			hCursor = SetCursor (LoadCursor(NULL, IDC_WAIT));
			ShowCursor( TRUE );

			if (hRgnClip)
				 DeleteObject( hRgnClip );

			hRgnTemp[0] = CreateEllipticRgn(0, cyClient / 3,
										 cxClient / 2, 2 * cyClient / 3);
			hRgnTemp[1] = CreateEllipticRgn(cxClient / 2, cyClient / 3,
										 cxClient, 2 * cyClient / 3);
			hRgnTemp[2] = CreateEllipticRgn(cxClient / 3, 0,
										 2 * cxClient / 3, cyClient / 2);
			hRgnTemp[3] = CreateEllipticRgn(cxClient / 3, cyClient / 2,
										 2 * cxClient / 3, cyClient);
			hRgnTemp[4] = CreateRectRgn(0, 0, 1, 1);
			hRgnTemp[5] = CreateRectRgn(0, 0, 1, 1);
			hRgnClip    = CreateRectRgn(0, 0, 1, 1);

			CombineRgn(hRgnTemp[4], hRgnTemp[0], hRgnTemp[1], RGN_OR);
			CombineRgn(hRgnTemp[5], hRgnTemp[2], hRgnTemp[3], RGN_OR);
			CombineRgn(hRgnClip, hRgnTemp[4], hRgnTemp[5], RGN_XOR);

			for( i = 0; i < 6; ++i )
				 DeleteObject( hRgnTemp[i] );

			SetCursor( hCursor );
			ShowCursor( FALSE );
		 }
		 else
			 DrawRectangle( hwnd );

		 return 0 ;

	 case WM_CLOSE:
		 imbStatus1 = MessageBox(hwnd, TEXT("The WM_CLOSE message has been handled."),
									  TEXT("WS_CLOSE"), MB_OKCANCEL) ;

		 if(imbStatus1 == IDOK)
			 break; 
		 else
			 return 0;

     case WM_DESTROY:
		 if( imbStatus2 == IDOK )
			 DeleteObject( hRgnClip );
		 else
			 break;

         PostQuitMessage (0) ;
		 return 0 ;
     }
     return DefWindowProc (hwnd, message, wParam, lParam) ;
}

void DrawRectangle( HWND hwnd )
{
	HBRUSH hBrush;
	HDC hdc;
	RECT rect;

	if( cxClient == 0 || cyClient == 0)
		return;

	SetRect( &rect, rand() % cxClient, rand() % cyClient,
					rand() % cxClient, rand() & cyClient);

	hBrush = CreateSolidBrush( RGB( rand() % 256,
						rand() % 256, rand() % 256));
	hdc = GetDC( hwnd );

	FillRect( hdc, &rect, hBrush );
	ReleaseDC( hwnd, hdc );
	DeleteObject( hBrush );
}