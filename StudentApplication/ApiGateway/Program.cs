using Ocelot.DependencyInjection;
using Ocelot.Middleware;
var builder = WebApplication.CreateBuilder(args);
// 1. Configure Ocelot (pointing to ocelot.json)
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
// 2. Add Logging (Optional but helpful)
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});
var app = builder.Build();
// 3. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
// 4. If your microservices use HTTPS with self-signed certs in dev,
// you might need to handle SSL certificate validation if Ocelot has issues.
// For production, proper certificates are a must.
// For development, if you face SSL issues when Ocelot calls downstream services:
// HttpClientHandler clientHandler = new HttpClientHandler();
// clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; 
// Bypass certificate validation for dev
// builder.Services.AddOcelot(builder.Configuration)
// .ConfigureDownstreamHostAndPorts(options => {})
// .ConfigureHttpClient(httpClientBuilder => {
// httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() => clientHandler);
// });
// This is generally not recommended for production.
app.UseHttpsRedirection(); // Redirect HTTP to HTTPS for the gateway itself
// 5. Use Ocelot Middleware - This is crucial!
await app.UseOcelot();
app.Run();