set  wildcard=*.*
@echo off
setlocal
if not [%1]==[] pushd %1
for /r %%F in (%wildcard%) do call :sub "%%F"
echo Total lines in %Files% files: %Total%
echo Total lines in %Files% files: %Total% >> LineCountLog.txt
popd
exit /b 0
:Sub
set /a Cnt=0
for /f %%n in ('type %1') do set /a Cnt+=1
set /a Total+=Cnt
set /a Files+=1
echo %1: %Cnt% lines
echo %1: %Cnt% lines >> LineCountLog.txt