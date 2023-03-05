# BCHWebApi

This project is a Web API with .NET Core Framework that fetches and stores all information of Ethereum (ETH), Dash, and Bitcoin (BTC) blockchains using the side API as a data source.
The main functionality of the project includes providing API endpoints that show all available blockchain information in Swagger,
storing all blockchain information in a database with a timestamp named CreatedAt, providing API endpoints that show the history of each blockchain's information stored in the database in descending order based on CreatedAt.
.NET Core 6 and SQLite (EF) as the database.
To use this project locally, ensure that all necessary NuGet packages are installed correctly. Additionally, you must create a database using the PM console by navigating to the /src/BCH.WebApi directory and typing the command "dotnet ef database update". This will update the database schema and ensure that the application can interact with the database correctly.
