# Cordova QS Build Script
# Installs the required plugins and builds the platforms supported when
# using OSX.

cordova plugin add cordova-plugin-ms-azure-mobile-apps 

# Plugins required for push notifications
# cordova plugin add cordova-plugin-device
# cordova plugin add https://github.com/phonegap/phonegap-plugin-push.git

# Build supported platforms
cordova platform add ios
cordova build ios

cordova platform add android
cordova build android
