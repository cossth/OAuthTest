using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.TryAddSingleton<IPersistedGrantStore, InMemoryPersistedGrantStore>();

builder.Services.AddAuthentication("token")
    .AddOAuth2Introspection("token", options =>
    {
        options.Authority = "https://id.pilot.vunet.io";
        options.ClientId = "vusmartmaps";
        options.ClientSecret = "a51dfb50-c21c-9b5f-b780-840eedfe08ec";
        // options.IntrospectionEndpoint = "https://id.pilot.vunet.io/connect/introspect";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
