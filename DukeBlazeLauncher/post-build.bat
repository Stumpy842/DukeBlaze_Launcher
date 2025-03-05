@echo off
echo ***TargetDir='%1'
echo ***TargetName='%2'
set d=%1
if "%~1" == "" goto err
set d=%2
if "%~2" == "" goto err
if not exist %1%2.exe (
	echo ***Missing file %2.exe
	goto merr
)
if not exist %1%2.dll (
	echo ***Missing file %2.dll
	goto merr
)
if not exist %1Newtonsoft.Json.dll (
	echo ***Missing file Newtonsoft.Json.dll
	goto merr
)
if not exist %1%2.runtimeconfig.json (
	echo ***Missing file %2.runtimeconfig.json
	goto merr
)
set d=E:\Games\DUKE3DAT
echo Copying %1%2.exe to %d%
copy /y %1%2.exe %d%
if errorlevel 1 goto cerr
echo Copying %1%2.dll to %d%
copy /y %1%2.dll %d%
if errorlevel 1 goto cerr
echo Copying %1Newtonsoft.Json.dll to %d%
copy /y %1Newtonsoft.Json.dll %d%
if errorlevel 1 goto cerr
echo Copying %1%2.runtimeconfig.json to %d%
copy /y %1%2.runtimeconfig.json %d%
if errorlevel 1 goto cerr
echo OK to run %d%\%2
exit /B 0
:err
echo ***ERROR: Missing or empty parameter %d%
goto fin
:cerr
echo ***Copying error...
:merr
echo ***Post-build aborted!
:fin