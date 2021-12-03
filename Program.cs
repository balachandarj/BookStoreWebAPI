using BookStoreWebAPI.Controllers;
using BookStoreWebAPI.Data.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IBookService,BookService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("1.0.0", new OpenApiInfo
                    {
                        Version = "1.0.0",
                        Title = "Book Store",                       
                        Contact = new OpenApiContact()
                        {
                           Name = "Swagger Codegen Contributors",
                           Url = new Uri("https://github.com/swagger-api/swagger-codegen"),
                           Email = "apiteam@swagger.io"
                        }                        
                });
                // using System.Reflection;
                    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //TODO: Either use the SwaggerGen generated Swagger contract (generated from C# classes)
                c.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "Swagger Book Store");
                
            });
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
