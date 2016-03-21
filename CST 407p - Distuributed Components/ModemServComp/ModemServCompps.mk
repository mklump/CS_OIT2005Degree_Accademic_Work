
ModemServCompps.dll: dlldata.obj ModemServComp_p.obj ModemServComp_i.obj
	link /dll /out:ModemServCompps.dll /def:ModemServCompps.def /entry:DllMain dlldata.obj ModemServComp_p.obj ModemServComp_i.obj \
		kernel32.lib rpcndr.lib rpcns4.lib rpcrt4.lib oleaut32.lib uuid.lib \

.c.obj:
	cl /c /Ox /DWIN32 /D_WIN32_WINNT=0x0400 /DREGISTER_PROXY_DLL \
		$<

clean:
	@del ModemServCompps.dll
	@del ModemServCompps.lib
	@del ModemServCompps.exp
	@del dlldata.obj
	@del ModemServComp_p.obj
	@del ModemServComp_i.obj
