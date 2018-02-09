namespace AppWeb.PageStatus.Monitor

module Monitor =
    open System
    open AppWeb.PageStatus.Configuration.DomainTypes
    open System.Net 
    open System.Net.NetworkInformation
    open System.Diagnostics
    
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
       
    let internal ping uri =
        let p = new Ping()
        let success = p.Send((uri:Uri).Host).Status = IPStatus.Success
        success
    
    let internal checkUri uriConfiguration = 
        let config = uriConfiguration:PageMonitorUri
        let stopWatch = Stopwatch.StartNew()
        let success = match config.MonitorMethod with 
                        | HttpGet -> httpStatus config.Uri
                        | Ping -> ping config.Uri
                        | _ -> false
        stopWatch.Stop()
        let milliseconds = Convert.ToInt32(stopWatch.Elapsed.TotalMilliseconds)
        {Uri = config; Success = success; Milliseconds = milliseconds}
       
    // Run monitor
    let run(uris: list<PageMonitorUri>) = 
        List.map 
            checkUri 
            uris
    
    
    
        
        
