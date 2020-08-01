REM Kill chrome if needed
tasklist /FI "IMAGENAME eq chrome.exe" /NH | find /I /N "chrome.exe" >NUL
if "%ERRORLEVEL%"=="0" TASKKILL /IM chrome.exe /F

REM Kill chromedriver if needed
tasklist /FI "IMAGENAME eq chromedriver.exe" /NH | find /I /N "chromedriver.exe" >NUL
if "%ERRORLEVEL%"=="0" TASKKILL /IM chromedriver.exe /F

REM Kill iexplore if needed
tasklist /FI "IMAGENAME eq iexplore.exe" /NH | find /I /N "iexplore.exe" >NUL
if "%ERRORLEVEL%"=="0" TASKKILL /IM iexplore.exe /F

REM Kill IEDriverServer if needed
tasklist /FI "IMAGENAME eq IEDriverServer.exe" /NH | find /I /N "IEDriverServer.exe" >NUL
if "%ERRORLEVEL%"=="0" TASKKILL /IM IEDriverServer.exe /F