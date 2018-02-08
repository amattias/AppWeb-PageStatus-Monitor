open System
open AppWeb.PageStatus.Monitor
open AppWeb.PageStatus.Configuration.DomainTypes

let uriConfigurations = [
    {Uri = new Uri("https://www.appweb.se"); MonitorMethod = HttpGet}; 
    {Uri = new Uri("https://tinkr.cloud"); MonitorMethod = HttpGet}; 
    {Uri = new Uri("https://test.tinkr.cloud"); MonitorMethod = Ping}; 
    {Uri = new Uri("https://notvalidurl.tinkr.cloud"); MonitorMethod = HttpGet}
]

let print result = printfn "%A" result 

let runMonitor = 
    let result = 
        Monitor.run uriConfigurations
    List.map 
        print 
        result

let readLine = 
    printfn "%A" (Console.ReadLine() |> string)

[<EntryPoint>]
let main argv =
    Console.WriteLine runMonitor 
    readLine
    0
