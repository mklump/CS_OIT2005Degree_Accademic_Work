   /*------------------------------------------------------------------
	' Author:         Matthew Klump
	' Date Created:   January 30, 2003
	' Last Change Date: January 30, 2003
	' Project:        Lab 3, CST 238 Winter 2003
	' Filename:       Tic_Tac_Toe.c
	'
	' Overview:
	'       This program displays a window and a 3 x 3 grid in the 
	'		client area for a game of Tic Tac Toe, enjoy!
	'
	' Input:
	'       Input is accepted for the user by pressing one of two
	'		buttons to draw random rectangles or a clover.
	' Output:
	'       The output of this program is display to a window that
	'		draws a tic-tact-toe grid for the game.
	'------------------------------------------------------------------*/

#include <windows.h>

LRESULT CALLBACK WndProc (HWND, UINT, WPARAM, LPARAM) ;

int cxClient, cyClient; // For the width and height of client area

int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
                    PSTR szCmdLine, int iCmdShow)
{
     static TCHAR szAppName[] = TEXT ("HelloWin") ;
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
                          TEXT ("Matthew Klump ")	  // window caption
						  TEXT("Lab 3 - Tic Tac Toe"),
                          WS_OVERLAPPEDWINDOW,        // window style
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
     
     while (GetMessage (&msg, NULL, 0, 0))
     {
          TranslateMessage (&msg) ;
          DispatchMessage (&msg) ;
     }
     return msg.wParam ;
}

void DrawX(HDC hdc, RECT *rect_, int index, HBRUSH hBrush)
{
	SelectObject(hdc, hBrush);

	MoveToEx(hdc, rect_[index].left, rect_[index].top, NULL);
	LineTo(hdc, rect_[index].right, rect_[index].bottom);

	MoveToEx(hdc, rect_[index].right, rect_[index].bottom, NULL);
	LineTo(hdc, rect_[index].left, rect_[index].top);
}

void DrawO(HDC hdc, RECT *rect_, int index, HBRUSH hBrush)
{
	SelectObject(hdc, hBrush);

	Ellipse(hdc, rect_[index].left, rect_[index].top,
				rect_[index].right, rect_[index].bottom);
}

void SetAllRects(RECT *rect)
{
		 SetRect(&rect[0], cxClient / 8, cyClient / 8,
				(cxClient / 8 + 7 * cxClient / 8)/3,
				(cyClient / 8 + 7 * cyClient / 8)/3);
		 
		 SetRect(&rect[1], (cxClient / 8 + 7 * cxClient / 8)/3,
			 cyClient / 8, (cxClient / 8 + 7 * cxClient / 8)*2/3,
			 (cyClient / 8 + 7 * cyClient / 8)/3);
         
		 SetRect(&rect[2], (cxClient / 8 + 7 * cxClient / 8)*2/3,
			 cyClient / 8, 7 * cxClient / 8,
			 (cyClient / 8 + 7 * cyClient / 8)/3);
         
		 SetRect(&rect[3], cxClient / 8,
			 (cyClient / 8 + 7 * cyClient / 8)/3,
			 (cxClient / 8 + 7 * cxClient / 8)/3,
			 (cyClient / 8 + 7 * cyClient / 8)*2/3);

         SetRect(&rect[4], (cxClient / 8 + 7 * cxClient / 8)/3,
			 (cyClient / 8 + 7 * cyClient / 8)/3,
			 (cxClient / 8 + 7 * cxClient / 8)*2/3,
			 (cyClient / 8 + 7 * cyClient / 8)*2/3);

		 SetRect(&rect[5], (cxClient / 8 + 7 * cxClient / 8)*2/3,
			 (cyClient / 8 + 7 * cyClient / 8)/3, 7 * cxClient / 8,
			 (cyClient / 8 + 7 * cyClient / 8)*2/3);

		 SetRect(&rect[6], cxClient / 8,
			 (cyClient / 8 + 7 * cyClient / 8)*2/3,
			 (cxClient / 8 + 7 * cxClient / 8)/3,
			 7 * cyClient / 8);

		 SetRect(&rect[7], (cxClient / 8 + 7 * cxClient / 8)/3,
			 (cyClient / 8 + 7 * cyClient / 8)*2/3,
			 (cxClient / 8 + 7 * cxClient / 8)*2/3,
			 7 * cyClient / 8);

		 SetRect(&rect[8], (cxClient / 8 + 7 * cxClient / 8)*2/3,
			 (cyClient / 8 + 7 * cyClient / 8)*2/3,
			 7 * cxClient / 8, 7 * cyClient / 8);
}

LRESULT CALLBACK WndProc (HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	 static POINT pt;	// Used for where the mouse click on the screen
	 RECT rect[9];		// Rectangle structures for the 3 X 3 grid
	 int i,				// Loop Variable
		 bInRect[9];	// Rectangle tatus use for true or false
     HDC          hdc ; // Get a handle on the window
     PAINTSTRUCT  ps ;  // Declare the paint structure
	 HBRUSH hBrush1 = 0, hBrush2 = 0; // The brushes used for drawing
							          // retangles, X's, and O's
	      
     switch (message)
     {
     case WM_CREATE:
		 return 0 ;
          
     case WM_PAINT:
		 // Invalidate the rectangle in client area and redraw
		 InvalidateRect(hwnd, NULL, TRUE);

         hdc = BeginPaint (hwnd, &ps);

		 SetAllRects( rect );

		 // Begin drawing a 3 by 3 grid
		  
		  hBrush1 = CreateSolidBrush( RGB( 0, 0, 0 ) ); // Black brush
		 
		  // Get the Black Brush
		  SelectObject(hdc, hBrush1);

		  for(i = 0; i < 9; ++i)
			  FrameRect(hdc, &rect[i], hBrush1);

		  // End drawing a 3 by 3 grid

		  EndPaint (hwnd, &ps) ;
          return 0 ;

	 case WM_LBUTTONDOWN:
		  if (wParam & MK_LBUTTON)
          {
			  hdc = GetDC (hwnd);

			  SetAllRects( rect );

			  hBrush2 = CreateSolidBrush( RGB( 255, 0, 0 ) ); // Red brush

			  pt.x = LOWORD (lParam);
			  pt.y = HIWORD (lParam);

			  // Get where the user clicked
			  for( i = 0; i < 9; ++i )
				  bInRect[i] = PtInRect(&rect[i], pt);
			  // Draw the X or the O
			  for(i = 0; i < 9; ++i)
			  {
				  if( bInRect[i] == 1 && i % 2 == 0 )
				  {
					  DrawX(hdc, &rect[i], i, hBrush2);
					  break;
				  }
				  if( bInRect[i] == 0 && i % 2 != 0 )
				  {
					  DrawO(hdc, &rect[i], i, hBrush2);
					  break;
				  }
			  }

			  ReleaseDC (hwnd, hdc) ;
          }
		  
		  return 0;
		  
	 case WM_SIZE:
		 cxClient = LOWORD( lParam );
		 cyClient = HIWORD( lParam );		 
		 return 0;
		 
          
     case WM_DESTROY:
		  DeleteObject( hBrush1 );
		  DeleteObject( hBrush2 );
          PostQuitMessage (0) ;
          return 0 ;
     }
     return DefWindowProc (hwnd, message, wParam, lParam) ;
}

