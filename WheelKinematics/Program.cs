/*
Below is a Kestrel Web Server that hosts a gRPC .net app.
Based on this tutorial: https://www.youtube.com/watch?v=QyxCX2GYHxk
*/
using Microsoft.AspNetCore.Server.Kestrel.Core;
using WheelKinematics.Services;

namespace WheelKinematics {
    class Program {
        static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Set to use all http versions, configure port, and maybe someday use HTTPS
            // This can also be changed in appsettings.json
            // builder.WebHost.ConfigureKestrel((context, options) => {
            //     options.ListenAnyIP(5001, listenOptions => {
            //         listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
            //         // listenOptions.UseHttps(); // nifty, but will cause panic in the browser due to no cert
            //     });
            // });

            // Add services to the container.
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<KinematicsCalcService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}