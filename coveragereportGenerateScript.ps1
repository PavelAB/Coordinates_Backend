$testResult = dotnet test --collect:"XPlat Code Coverage"

$xmlLine = $testResult | Select-Object -Last 1

reportgenerator -targetdir:"coveragereport" -reporttypes:Html -reports:$xmlLine

Start-Process "coveragereport/index.html"
 