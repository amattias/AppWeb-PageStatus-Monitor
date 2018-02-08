namespace AppWeb.PageStatus.Configuration

/// ===========================================
/// Global types for this project
/// ===========================================
module DomainTypes = 
    open System
    type MonitorMethodUnion = Ping | HttpGet 
    type PageMonitorUri = {Uri: Uri; MonitorMethod: MonitorMethodUnion}
    type PageMonitorResult = {PageMonitorUri: PageMonitorUri; Success: bool; Milliseconds: int}
