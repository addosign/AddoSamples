# Addo Samples

## Introduction
This repository contains a couple of methods to show how to communicate with the Visma Addo API.
The following methods are demonstrated:
* /Login
* /InitiateSigning
* /GetSigningTemplate
* /GetSigning
* /GetSignings

The samples here is bare minimum samples - they should be enough to get you going but they will not represent a full blown application.
You should really have a look at the [Visma Addo API documentation](/APIDocumentation/ADDO-APIDocumentation-AddoWebService-090321-1235-30.pdf) to see what the API has to offer.

## Prerequisites
You need the following installed / configured:
* A Visma Addo account (obviously).
* A simple template on you account. This template should only have email notification and distribution enabled, no authentication and just touch signing. The template must be named _AddoSamplesTemplate_ - but that can be changed in the `appsettings.json` file (the *Template* key)
* .NET Core, version 3.1.x - these samples have been tested using v3.1.401.
* Some git client to check out the code. In the instructions below I use the command-line git client.

## Build and run
Clone the repository:
```
git clone https://github.com/vismaaddo/AddoSamples.git
cd AddoSamples
dotnet restore
```

Before building you must create the `credentials.json` file. This file should contain your Visma Addo account information:
```
{
	"Email": "your.email@somewhere.net",
	"Password": "YourSecretPassword"
}

```
This is a one-time thing. Please don't commit the file. Place the file next to `appsettings.json`.

Open up `Program.cs`. Un-commment any or all of the method calls starting on line 24-ish depending on what you want to test.
Then build and run:
```
dotnet build
dotnet run
```

Happy hacking!
