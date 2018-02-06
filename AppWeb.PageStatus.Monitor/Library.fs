namespace AppWeb.PageStatus.Monitor

module Monitor =
    open System
    open AppWeb.PageStatus.Configuration.DomainTypes
    open System.Net
    open System.Diagnostics
    open System.Linq.Expressions
    
    let internal checkIfSuccessStatus status = 
        match status with 
            | HttpStatusCode.OK -> true
            | _ -> false

    let internal httpStatus uri =
        try
            let req = WebRequest.Create(uri:Uri) 
            use resp = req.GetResponse() :?> HttpWebResponse
            let success = checkIfSuccessStatus resp.StatusCode
            success
        with 
            | :? WebException as ex -> false
       
    let internal checkUri uriConfiguration = 
        let config = uriConfiguration:PageMonitorUri
        let stopWatch = Stopwatch.StartNew()
        let success = match config.MonitorMethod with 
                        | HttpGet -> httpStatus config.Uri
                        | Ping -> false
                        | _ -> false
        stopWatch.Stop()
        let milliseconds = Convert.ToInt32(stopWatch.Elapsed.TotalMilliseconds)
        {Uri = uriConfiguration.Uri; Success = success; Milliseconds = milliseconds}
       
    // Run monitor
    let run(uris: list<PageMonitorUri>) = 
        List.map 
            checkUri 
            uris
    
    
    
        
        
