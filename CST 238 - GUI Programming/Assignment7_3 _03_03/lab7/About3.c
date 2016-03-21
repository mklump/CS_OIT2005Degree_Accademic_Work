   /*------------------------------------------------------------------
	' Author:         Matthew Klump
	' Date Created:   Feburary 28, 2003
	' Last Change Date: Feburary 28, 2003
	' Project:        Lab 7, CST 238 Winter 2003
	' Filename:       About3.c
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
#include "resource.h"

LRESULT CALLBACK WndProc (HWND, UINT, WPARAM, LPARAM) ;
BOOL    CALLBACK AboutDlgProc (HWND, UINT, WPARAM, LPARAM) ;
BOOL    CALLBACK ModalDlgProc (HWND, UINT, WPARAM, LPARAM) ;
BOOL    CALLBACK ModelessDlgProc (HWND, UINT, WPARAM, LPARAM) ;

LRESULT CALLBACK EllipPushWndProc (HWND, UINT, WPARAM, LPARAM) ;

HWND hDlgModeless ;

int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
                    PSTR szCmdLine, int iCmdShow)
{
     static TCHAR szAppName[] = TEXT ("About3") ;
     MSG          msg ;
     HWND         hwnd ;
     WNDCLASS     wndclass ;

     wndclass.style         = CS_HREDRAW | CS_VREDRAW ;
     wndclass.lpfnWndProc   = WndProc ;
     wndclass.cbClsExtra    = 0 ;
     wndclass.cbWndExtra    = 0 ;
     wndclass.hInstance     = hInstance ;
     wndclass.hIcon         = LoadIcon (hInstance, szAppName) ;
     wndclass.hCursor       = LoadCursor (NULL, IDC_ARROW) ;
     wndclass.hbrBackground = (HBRUSH) GetStockObject (WHITE_BRUSH) ;
     wndclass.lpszMenuName  = szAppName ;
     wndclass.lpszClassName = szAppName ;
     
     if (!RegisterClass (&wndclass))
     {
          MessageBox (NULL, TEXT ("This program requires Windows NT!"),
                      szAppName, MB_ICONERROR) ;
          return 0 ;
     }
     
     wndclass.style         = CS_HREDRAW | CS_VREDRAW ;
     wndclass.lpfnWndProc   = EllipPushWndProc ;
     wndclass.cbClsExtra    = 0 ;
     wndclass.cbWndExtra    = 0 ;
     wndclass.hInstance     = hInstance ;
     wndclass.hIcon         = NULL ;
     wndclass.hCursor       = LoadCursor (NULL, IDC_ARROW) ;
     wndclass.hbrBackground = (HBRUSH) (COLOR_BTNFACE + 1) ;
     wndclass.lpszMenuName  = NULL ;
     wndclass.lpszClassName = TEXT ("EllipPush") ;

     RegisterClass (&wndclass) ;
     
     hwnd = CreateWindow (szAppName, TEXT ("Matthew Klump - Lab7 CST 238 GUI Programming"),
                          WS_OVERLAPPEDWINDOW,
                          CW_USEDEFAULT, CW_USEDEFAULT,
                          CW_USEDEFAULT, CW_USEDEFAULT,
                          NULL, NULL, hInstance, NULL) ;
     
     ShowWindow (hwnd, iCmdShow) ;
     UpdateWindow (hwnd) ; 
     
     while (GetMessage (&msg, NULL, 0, 0))
     {
         if( hDlgModeless == 0 || !IsDialogMessage( hDlgModeless, &msg ))
         {
              TranslateMessage (&msg) ;
              DispatchMessage (&msg) ;
         }
     }
     return msg.wParam ;
}

LRESULT CALLBACK WndProc (HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
     static HINSTANCE hInstance ;
     
     switch (message)
     {
     case WM_CREATE :
          hInstance = ((LPCREATESTRUCT) lParam)->hInstance ;
          return 0 ;
          
     case WM_COMMAND :
          switch (LOWORD (wParam))
          {
          case IDM_APP_ABOUT :
               DialogBox (hInstance, TEXT("AboutBox"), hwnd, AboutDlgProc) ;
               return 0 ;

          case IDM_MODALDIALOG :
               DialogBox (hInstance, MAKEINTRESOURCE(IDD_MODALDIALOG), hwnd, ModalDlgProc) ;
               return 0 ;

          case IDM_MODELESSDIALOG :
               hDlgModeless = CreateDialog(hInstance,
                        MAKEINTRESOURCE(IDD_MODELESSDIALOG), hwnd, ModelessDlgProc) ;
               return 0 ;
          }
          break ;
          
     case WM_DESTROY :
          PostQuitMessage (0) ;
          return 0 ;
     }
     return DefWindowProc (hwnd, message, wParam, lParam) ;
}

BOOL CALLBACK AboutDlgProc (HWND hDlg, UINT message, 
                            WPARAM wParam, LPARAM lParam)
{
     switch (message)
     {
     case WM_INITDIALOG :
          return TRUE ;
          
     case WM_COMMAND :
          switch (LOWORD (wParam))
          {
          case IDOK :
               EndDialog (hDlg, 0) ;
               return TRUE ;
          }
          break ;
     }
     return FALSE ;
}

BOOL CALLBACK ModalDlgProc (HWND hDlg, UINT message, 
                            WPARAM wParam, LPARAM lParam)
{
     switch (message)
     {
     case WM_INITDIALOG :
          return TRUE ;
          
     case WM_COMMAND :
          switch (LOWORD (wParam))
          {
          case IDOK :
          case IDCANCEL :
               EndDialog (hDlg, 0) ;
               return TRUE ;
          case IDC_MESSAGE :
               MessageBox( hDlg, TEXT("Modal Dialog Box is Processing dialog messages"),
                                 TEXT("Modal Dialog Box Message Processing"), IDOK | MB_DEFBUTTON1 ) ;
              return 0 ;
          }
          break ;
     }
     return FALSE ;
}

BOOL CALLBACK ModelessDlgProc (HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
     switch (message)
     {
     case WM_INITDIALOG :
          return TRUE ;
          
     case WM_COMMAND :
          switch (LOWORD (wParam))
          {
          case IDOK :
          case IDCANCEL :
               DestroyWindow( hDlg ) ;
               hDlgModeless = NULL ;
               return TRUE ;

          case IDC_MESSAGE2 :
               MessageBox( hDlg, TEXT("Modeless Dialog Box is Processing dialog messages"),
                                 TEXT("Modeless Dialog Box Message Processing"), IDOK | MB_DEFBUTTON1 ) ;
               return TRUE ;
          
          case WM_CLOSE :
               DestroyWindow( hDlg ) ;
               hDlgModeless = NULL ;
               return FALSE ;
          }
          break ;
     }
     return FALSE ;
}

LRESULT CALLBACK EllipPushWndProc (HWND hwnd, UINT message, 
                                   WPARAM wParam, LPARAM lParam)
{
     TCHAR       szText[40] ;
     HBRUSH      hBrush ;
     HDC         hdc ;
     PAINTSTRUCT ps ;
     RECT        rect ;
     POINT       Pos ;
     static BOOL  bLBUTTONCLICKED = FALSE ;

     switch (message)
     {
     case WM_PAINT :
          GetClientRect (hwnd, &rect) ;
          GetWindowText (hwnd, szText, sizeof (szText)) ;
          
          hdc = BeginPaint (hwnd, &ps) ;
          
          if( bLBUTTONCLICKED == TRUE )
          {
             hBrush = CreateSolidBrush (!GetSysColor (COLOR_WINDOW)) ;
             hBrush = (HBRUSH) SelectObject (hdc, hBrush) ;
             SetBkColor (hdc, RGB(0, 0, 0)) ;
             SetTextColor (hdc, RGB(255, 255, 255)) ;
          }
          else
          {
             hBrush = CreateSolidBrush (GetSysColor (COLOR_WINDOW)) ;
             hBrush = (HBRUSH) SelectObject (hdc, hBrush) ;
             SetBkColor (hdc, GetSysColor (COLOR_WINDOW)) ;
             SetTextColor (hdc, GetSysColor (COLOR_WINDOWTEXT)) ;
          }          
          Ellipse (hdc, rect.left, rect.top, rect.right, rect.bottom) ;
          DrawText (hdc, szText, -1, &rect,
                    DT_SINGLELINE | DT_CENTER | DT_VCENTER) ;

          DeleteObject (SelectObject (hdc, hBrush)) ;
          
          EndPaint (hwnd, &ps) ;
          return 0 ;

     case WM_LBUTTONDOWN :
         SetCapture( hwnd ) ;
         bLBUTTONCLICKED = TRUE ;
         InvalidateRect( hwnd, NULL, TRUE ) ;
         return 0 ;

     case WM_MOUSEMOVE :
         Pos.x = LOWORD(lParam) ; 
         Pos.y = HIWORD(lParam) ;
 
         if( PtInRect( &rect, Pos ) && wParam & MK_LBUTTON )
             bLBUTTONCLICKED = TRUE ;
         else
             bLBUTTONCLICKED = FALSE ;

         InvalidateRect( hwnd, NULL, TRUE ) ;
         return 0 ;
          
     case WM_KEYUP :
          if (wParam != VK_SPACE)
               break ;
                                             // fall through
     case WM_LBUTTONUP :
          if( bLBUTTONCLICKED == TRUE )
          {
              SendMessage (GetParent (hwnd), WM_COMMAND,
                   GetWindowLong (hwnd, GWL_ID), (LPARAM) hwnd) ;
          }

          bLBUTTONCLICKED = FALSE ;
          ReleaseCapture() ;
          return 0 ;
     }
     return DefWindowProc (hwnd, message, wParam, lParam) ;
}
