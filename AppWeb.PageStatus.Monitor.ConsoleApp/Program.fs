// Learn more about F# at http://fsharp.org

open System
open AppWeb.PageStatus.Monitor
open AppWeb.PageStatus.Configuration.DomainTypes

let uri1: PageMonitorUri = {Uri = new Uri("https://www.appweb.se"); MonitorMethod = MonitorMethodUnion.HttpGet}
let uri2: PageMonitorUri = {Uri = new Uri("https://tinkr.cloud"); MonitorMethod = MonitorMethodUnion.HttpGet}
let uri3: PageMonitorUri = {Uri = new Uri("https://test.tinkr.cloud"); MonitorMethod = MonitorMethodUnion.HttpGet}
let uri4: PageMonitorUri = {Uri = new Uri("https://notvalidurl.tinkr.cloud"); MonitorMethod = MonitorMethodUnion.HttpGet}

let uriConfigurations: list<PageMonitorUri> = [uri1; uri2; uri3; uri4]

let printMonitorResult result = printfn "%A" result 

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