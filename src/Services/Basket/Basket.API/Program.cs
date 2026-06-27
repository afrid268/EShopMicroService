var builder = WebApplication.CreateBuilder(args);

//services to containers

var app = builder.Build();

// configures the http request pipeleine

app.MapGet("/", () => "Hello World!");

app.Run();
