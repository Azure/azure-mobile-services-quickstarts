REM Cordova QS Build Script
REM Installs the required plugins and builds the platforms supported when
REM using Windows.

call cordova plugin add cordova-plugin-ms-azure-mobile-apps 

REM Plugins required for push notifications
REM call cordova plugin add cordova-plugin-device
REM call cordova plugin add https://github.com/phonegap/phonegap-plugin-push.git

REM Build supported platforms
call cordova platform add wp8
call cordova build wp8

call cordova platform add windows
call cordova build windows

call cordova platform add android
call cordova build android
