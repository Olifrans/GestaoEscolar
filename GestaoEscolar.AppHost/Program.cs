var builder = DistributedApplication.CreateBuilder(args);

//builder.AddProject<Projects.WebApi>("webapi");
//builder.AddProject<Projects.Core>("core");
//builder.AddProject<Projects.InfraEstrutura>("infraestrutura");

builder.Build().Run();
