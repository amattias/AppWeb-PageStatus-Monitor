# AppWeb-PageStatus-Monitor
A .NET Core F# library with tools for monitoring your uptime of web-sites/pages 

### Please note still in really early stage, not complete yet ###
More information about a rough timeplan and so will be shared

### Planned core features ###
* Client for monitor status of web pages
* Command line tool to run monitoring with
* Windows service integration to automate monitoring
* ...

### Page status check types implemented ###
* HttpGet, check so page answeres with 200 OK
* Ping so host can be successfully pinged

### Possible future check types ###
* Keyword, check if response contains keyword
* ...

### Possible future integrations ###
* Email reports and warnings
* 46elks sms integration for warnings
* Telegram bot integration for warnings
* ...