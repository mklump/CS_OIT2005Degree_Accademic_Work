option explicit

const stVirtualDir = "2389"
const stPhysicalDirDefault = "C:\program files\msdntrain\2389"

Dim objArgs
Dim stPhysicalDir
Dim WebRoot 
Dim webVDir
Dim webServer
Dim wshShell 
Dim oNet

	Set objArgs = WScript.Arguments

	if objArgs.Count > 1 then
		wscript.echo "If the path you specified contains a space, please surround it in quotes."
		wscript.quit(1)
	end if

	if objArgs.Count = 1 then
		stPhysicalDir = objArgs(0)
	else
		stPhysicalDir = stPhysicalDirDefault
	end if

	if not CheckFolder(stPhysicalDir) then
		wscript.echo "The lab and democode files must be installed to:" + vbcrlf + stPhysicalDir + vbcrlf + "before this script is run." + vbcrlf + vbcrlf + "Please run Allfiles.exe as described" + vbcrlf + "in the Classroom Setup Guide before continuing."
		wscript.quit
	end if
	Set WshShell = WScript.CreateObject("WScript.Shell")
	WshShell.Run "cacls """ + stPhysicalDir + """ /E /T /G Everyone:R", 0, true
	WshShell.Run "cacls """ + stPhysicalDir + """ /E /T /G Everyone:W", 0, true

	Set WebRoot = GetObject("IIS://LocalHost/W3SVC/1/ROOT") 

	set webVDir = getVDir(webRoot)
	SetVDirInfo(webVDir)

	Set WebRoot = nothing
	set webVDir = nothing

	'wscript.echo "Done"


function getVDir(Root)
Dim V

on error resume next
	Set V = Root.Create("IIsWebVirtualDir", stVirtualDir) 

	if err then
		Set V = Root.GetObject("IIsWebVirtualDir", stVirtualDir)
	end if

on error goto 0

	set getVDir = v
end function

sub SetVDirInfo(vDir)
    With vDir
	.path = stPhysicalDir
	.AccessScript = TRUE
	.AccessRead = TRUE
	.EnableDirBrowsing = TRUE
	.SetInfo
	.AppCreate 0
    end with
end sub

function CheckFolder(stFolder)
dim ofs
'On Error Resume Next 
	Set ofs = CreateObject("Scripting.FileSystemObject") 
	If (Not ofs.FolderExists(stFolder)) Then 
		CheckFolder = false
	else
		CheckFolder = true
	end if
	set ofs = nothing
on error goto 0
end function
