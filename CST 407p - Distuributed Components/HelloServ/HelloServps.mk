
HelloServps.dll: dlldata.obj HelloServ_p.obj HelloServ_i.obj
	link /dll /out:HelloServps.dll /def:HelloServps.def /entry:DllMain dlldata.obj HelloServ_p.obj HelloServ_i.obj \
		kernel32.lib rpcndr.lib rpcns4.lib rpcrt4.lib oleaut32.lib uuid.lib \

.c.obj:
	cl /c /Ox /DWIN32 /D_WIN32_WINNT=0x0400 /DREGISTER_PROXY_DLL \
		$<

clean:
	@del HelloServps.dll
	@del HelloServps.lib
	@del HelloServps.exp
	@del dlldata.obj
	@del HelloServ_p.obj
	@del HelloServ_i.obj
