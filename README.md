# BCHWebApi

This project is a Web API with .NET Core Framework that fetches and stores all information of Ethereum (ETH), Dash, and Bitcoin (BTC) blockchains using the BlockCypher API as a data source.
The main functionality of the project includes providing API endpoints that show all available blockchain information in Swagger,
storing all blockchain information in a database with a timestamp named CreatedAt, providing API endpoints that show the history of each blockchain's information stored in the database in descending order based on CreatedAt.
.NET Core 6 and SQLite (EF) as the database.
To use it localy you should check that all nessesered nuget packages are installed correctly and also you should create databe using pm console by writing the commad dotnet ef database update from BCH.WebApi directory. 
