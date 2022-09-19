using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(writeTo => writeTo.Console(new RenderedCompactJsonFormatter()))
            .CreateLogger();


var builder = ConfigureBuilder(WebApplication.CreateBuilder(args));
ConfigureApp(builder.Build()).Run();


WebApplicationBuilder ConfigureBuilder(WebApplicationBuilder builder)
{
    builder.Host.UseSerilog();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    return builder;

}

WebApplication ConfigureApp(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseSerilogRequestLogging(options=>{
        options.EnrichDiagnosticContext = (ctx,request)=>{
            ctx.Set("UserAgent", request.Request.Headers["User-Agent"]);
        };
    }); 

    app.UseAuthorization();
    app.MapControllers();
    return app;
}
