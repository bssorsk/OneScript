@echo off

setlocal
set pathdir=%~dp0

rem echo ᠬ� ���� %CD%
rem echo �ਯ�� ���஢���� %pathdir%

echo on
"%ProgramFiles(x86)%\OneScript\oscript.exe" %pathdir%\testrunner.os -run %1 %2 %3 %4 %5
@echo off

rem echo %ERRORLEVEL%
if NOT %ERRORLEVEL%==0 GOTO bad_exit

:success_exit
rem echo �ᯥ譮
rem pause

exit /B 0

:bad_exit
if %ERRORLEVEL%==-1 GOTO success_exit
echo Tests failed

pause
exit /B 1