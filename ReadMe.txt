1) install api:

a) run solution file "\Project.Api\Project.Api.sln"  (open visual studio as administrator!!!)
b) open config file "Project.Api\Project.Api\App.config" find setting key "selfHostUrl"
c) run command prompt ipconfig /all
d) use your ip address for value "selfHostUrl" in "App.config"
e) run project



2) install client-app
a) open command prompt in "Project.UI\client-app"
b) run npm install
c) open file "Project.UI\client-app\src\app\services\data.service.ts" line 17
d) replase api address and port from step 1.d - this is connection to your back-end api 
e) when run "ng serve"
if ng - doesn't recognized command run "npm run ng serve"

when open browser "http://localhost:4200/"

