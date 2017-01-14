# Serilog ApplicationServices Library

Serilog enricher for Digipolis ApplicationServices.

## Table of Contents

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->


- [ApplicationServicesEnricher](#applicationservicesenricher)
- [Installation](#installation)
- [Usage](#usage)
- [Enricher](#enricher)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## ApplicationServicesEnricher

This library contains an enricher for Serilog that adds the IApplicationContext properties to the LogEvent.
You can find more info about the IApplicationContext here : [https://github.com/digipolisantwerp/application_aspnetcore](https://github.com/digipolisantwerp/application_aspnetcore).

## Installation

This package is hosted on Myget on the following feed : https://www.myget.org/F/digipolisantwerp/api/v3/index.json.
To add it to a project, you add the package to the project.json :

``` json 
"dependencies": {
    "Digipolis.Serilog.ApplicationServices":  "1.0.0",
 }
``` 

In Visual Studio you can also use the NuGet Package Manager to do this.

## Usage

The ApplicationServicesEnricher has a dependency on the IApplicationContext of the **Digipolis.ApplicationServices** package, so make sure the needed services are 
[registered](https://github.com/digipolisantwerp/application_aspnetcore#startup). Then register the ApplicationServicesEnricher in the .NET core DI container. This can be done 
in combination with the Serilog Extensions library found here : [https://github.com/digipolisantwerp/serilog_aspnetcore](https://github.com/digipolisantwerp/serilog_aspnetcore) 
by calling the **AddApplicationServicesEnricher()** method in the Configure method of the Startup class :

```csharp
services.AddApplicationServices(options => {
    options.ApplicationId = "a0eab541-0f09-4540-abbf-88cc1fe02a90";
    options.ApplicationName = "MyApplication";
});

services.AddSerilogExtensions(options => {
    options.MessageVersion = "1";
    options.AddApplicationServicesEnricher();
});
```  

## Enricher

The enricher adds the following fields to the Serilog LogEvent :

- ApplicationId : the application's unique id (given in the startup options).
- ApplicationName : the application's (friendly) name (given in the startup options).
- InstanceId : the unique id of the application's running instance (is generated at startup).
- InstanceName : the name of the application's running instance (is generated at startup).
- ApplicationVersion : the application's version.
- ComponentId : id of the component (.NET class) that logs the event.
- ComponentName : name of the component (.NET class) that logs the event.