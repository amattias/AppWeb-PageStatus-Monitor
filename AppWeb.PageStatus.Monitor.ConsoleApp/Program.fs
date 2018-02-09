open System
open AppWeb.PageStatus.Monitor
open AppWeb.PageStatus.Configuration.DomainTypes
open Newtonsoft.Json
open System.IO

let path = Path.Combine(System.Environment.CurrentDirectory, @"config.json")
let lines = File.ReadAllLines(path)
let config = String.Join("", lines)
let uriConfigurations = JsonConvert.DeserializeObject<list<PageMonitorUri>>(config)

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
