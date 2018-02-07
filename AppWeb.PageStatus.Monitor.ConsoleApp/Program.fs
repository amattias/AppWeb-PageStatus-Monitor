// Learn more about F# at http://fsharp.org

open System
open AppWeb.PageStatus.Monitor
open AppWeb.PageStatus.Configuration.DomainTypes

let uriConfigurations = [
    {Uri = new Uri("https://www.appweb.se"); MonitorMethod = HttpGet}; 
    {Uri = new Uri("https://tinkr.cloud"); MonitorMethod = HttpGet}; 
    {Uri = new Uri("https://test.tinkr.cloud"); MonitorMethod = HttpGet}; 
    {Uri = new Uri("https://notvalidurl.tinkr.cloud"); MonitorMethod = HttpGet};
]

let printMonitorResult result = 
    printfn "%A" result 

let runMonitor = 
    let runResult = 
        Monitor.run 
        uriConfigurations
    List.map 
    printMonitorResult 
    runResult
    
let readLine = 
    printfn 
        "%A" 
        (Console.ReadLine() |> string)

[<EntryPoint>]
let main argv =
    Console.WriteLine 
        runMonitor
    readLine
    0