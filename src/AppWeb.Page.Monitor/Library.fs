namespace AppWeb.Page.Monitor

/// ===========================================
/// Global types for this project
/// ===========================================
module DomainTypes = 
    open System

    type MonitorMethodUnion = Ping | HttpGet 
    type PageMonitorUri = {Uri: Uri; MonitorMethod: MonitorMethodUnion}
    type PageMonitorResult = {Uri: Uri; Success: bool; Milliseconds: int}


module Monitor =
    open System
    open DomainTypes
    open System.Net
    open System.Linq.Expressions
    
    let checkIfSuccessStatus status = 
        match status with 
         | HttpStatusCode.OK -> true
         | _ -> false

    // Fetch the contents of a web page
    let internal checkUri uriConfiguration =  
        try
            let stopWatch = System.Diagnostics.Stopwatch.StartNew()
            let config = uriConfiguration:PageMonitorUri
            let req = WebRequest.Create(config.Uri) 
            use resp = req.GetResponse() :?> HttpWebResponse
            stopWatch.Stop()
            let success = checkIfSuccessStatus resp.StatusCode
            let milliseconds = Convert.ToInt32(stopWatch.Elapsed.TotalMilliseconds)
            {Uri = uriConfiguration.Uri; Success = success; Milliseconds = milliseconds}
        with 
            | :? WebException as ex -> 
                {Uri = uriConfiguration.Uri; Success = false; Milliseconds = -1}


    // dummy method always return success and 100ms
    
    //let internal checkUri(uriConfiguration: PageMonitorUri) : PageMonitorResult 
    //    = {Uri = uriConfiguration.Uri; Success = true; Milliseconds = 100}
       

    // runs test
    let run(uris: list<PageMonitorUri>) = 
        List.map 
            checkUri 
            uris
    
    
    
        
        
