var builder = WebApplication.CreateBuilder(args);   //webapplication is host here  so host is basically used to represent an http server implementation for the app which help in listening for http request
var app = builder.Build();  //build in this will build instance of the webapplication

app.MapGet("/", () => "Hello World!");  //this line is used to create instance of webapplication

app.Run();
