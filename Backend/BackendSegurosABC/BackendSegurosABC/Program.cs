using Microsoft.EntityFrameworkCore;
using BackendSegurosABC;

var builder = WebApplication.CreateBuilder(args);

// Conexión a PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") 
                   .AllowAnyMethod() 
                   .AllowAnyHeader(); 
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

// Habilitar CORS con la política definida
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:5016");