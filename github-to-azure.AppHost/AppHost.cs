var builder = DistributedApplication.CreateBuilder(args);

var configapi = builder.AddProject<Projects.ConfigApi>("configapi");

var gateway = builder.AddYarp("gateway")
    .WithConfiguration(yarp =>
    {
        yarp.AddRoute(configapi);
        yarp.AddRoute("/api/{**catch-all}", configapi);
    });


builder.Build().Run();
