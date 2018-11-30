# Hw - Hello World

A Hello World program showcasing .net/c# and app design

## Requirements:
* Write “Hello World” to the console/screen. 
* Provide an API that is separated from the program logic to eventually support mobile applications, web applications, or console applications, or windows 
services.
* Support future enhancements for writing to a database, console etc. by using:
     - Common design patterns (inheritance, e.g.) to account for these future concerns. 
     - Configuration files or another industry-standard mechanism for determining where to write the information to. 
## Implementation details

The program is implemented as a .NET Framework 4.6.1 based Visual Studio 2017 Console Application solution using C# language.  

The solution consists of the following projects:

   * Hw.Console 
     - Entry point .NET Framework 4.6.1 EXE
     - Uses Unity as the DI container to manage and setup dependencies
	 - Makes use of a appsettings.json file to manage the configuration/settings
     - Using the NewtonSoft.JSON library, retrieves settings from the JSON configuration file
	 - Configuration file contains a single 'RepoTarget' setting that defines the default repository target
   * Hw.DataModels 
     - Contains the entities/data models available for all layers,  in a .NET Standard 2.0 class library
     - For this sample program assumed the types are shared across all layers
   * Hw.BusinessLogic 
     - Implements the business logic in a .NET Standard 2.0 class library
     - For this sample, consider this as the 'API' that the client application uses
     - Exposes a HelloWorldManager class that provides 'greeting' services
   * Hw.DataAccess
     - Implements the data 'persistency' / 'repository' layer in a .NET Standard 2.0 class library
     - Determines the repository target using a factory pattern
     - Currently supports 'console' and 'file' as the repository targets
	 - Implements the persistency mechanism for 'console' and 'file' targets
	 - Implements a custom Configuration/Settings class that reads from the specified JSON content
   * Hw.Tests
     - Implements unit tests using MS Unit
	 - Contains tests for the HelloWorldManager business logic class
	 - Makes use of Moq library 

