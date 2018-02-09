namespace AppWeb.PageStatus.Configuration

module DomainTypes = 
    open System
    type MonitorMethodUnion = Ping | HttpGet 
    type PageMonitorUri = {Uri: Uri; MonitorMethod: MonitorMethodUnion}
    type PageMonitorResult = {Uri: PageMonitorUri; Success: bool; Milliseconds: int}
