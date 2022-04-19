@echo off
chcp 1252
if "%VisualStudioVersion%"=="" call "%ProgramFiles%\Microsoft Visual Studio\2020\BuildTools\Common7\Tools\VsDevCmd.bat" 2> nul
if "%VisualStudioVersion%"=="" call "%ProgramFiles%\Microsoft Visual Studio\2020\Enterprise\Common7\Tools\VsDevCmd.bat" 2> nul
if "%VisualStudioVersion%"=="" call "%ProgramFiles%\Microsoft Visual Studio\2020\Professional\Common7\Tools\VsDevCmd.bat" 2> nul

if "%VisualStudioVersion%"=="" call "%ProgramFiles(x86)%\Microsoft Visual Studio\2019\BuildTools\Common7\Tools\VsDevCmd.bat" 2> nul
if "%VisualStudioVersion%"=="" call "%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Enterprise\Common7\Tools\VsDevCmd.bat" 2> nul
if "%VisualStudioVersion%"=="" call "%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Professional\Common7\Tools\VsDevCmd.bat" 2> nul
if "%VisualStudioVersion%"=="" call "%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat" 2> nul
if "%VisualStudioVersion%"=="" call "%ProgramFiles(x86)%\Microsoft Visual Studio\2019\WDExpress\Common7\Tools\VsDevCmd.bat" 2> nul

set sln="cave-signed-mongo-csharp-driver.sln"

git clean -fdX
if %errorlevel% neq 0 exit /b %errorlevel%

msbuild /t:Clean %sln%
if %errorlevel% neq 0 exit /b %errorlevel%

dotnet restore %sln%
if %errorlevel% neq 0 exit /b %errorlevel%

if not "%1"=="debug" msbuild /p:Configuration=Release /p:Platform="Any CPU" %sln%
if %errorlevel% neq 0 exit /b %errorlevel%

if "%1"=="debug" msbuild /p:Configuration=Debug /p:Platform="Any CPU" %sln%
if %errorlevel% neq 0 exit /b %errorlevel%

