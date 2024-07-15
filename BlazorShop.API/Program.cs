using BlazorShop.API.Context;
using BlazorShop.API.Mappings;
using BlazorShop.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:7250",
                                "https://localhost:7250",
                                "http://localhost:5045")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithHeaders(HeaderNames.ContentType, "application/json");
        });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(op => 
                            op.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection1")));

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
