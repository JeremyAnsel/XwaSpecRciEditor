@echo off
setlocal

cd "%~dp0"

xcopy dist\ bld\dist\ /E

For %%a in (
"XwaSpecRciEditor\XwaSpecRciEditor\bin\Release\net48\*.exe"
"XwaSpecRciEditor\XwaSpecRciEditor\bin\Release\net48\*.exe.config"
) do (
xcopy /s /d "%%~a" bld\dist\
)
