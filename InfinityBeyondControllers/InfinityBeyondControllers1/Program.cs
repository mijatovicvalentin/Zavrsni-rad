using InfinityBeyondControllers1.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
 https://medium.com/geekculture/customizing-swagger-in-asp-net-core-5-2c98d03cbe52

builder.Services.AddSwaggerGen(sgo => { 
    // èitati https://devintxcontent.blob.core.windows.net/showcontent/Speaker%20Presentations%20Fall%202017/Web%20API%20Best%20Practices.pdf
    var o = new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "InfinityBeyond API",
        Version = "v1",
      
    };
    sgo.SwaggerDoc("v1", o);


});


builder.Services.AddDbContext<InfinityBeyondContext>(o =>
    o.UseSqlServer(
        builder.Configuration.
        GetConnectionString(name: "InfinityBeyondContext")
        )
    );



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opcije =>
    {
        opcije.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(opcije =>
    {
        opcije.ConfigObject.
        AdditionalItems.Add("requestSnippetsEnabled", true);
    });
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();