using TvShowsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar el servicio TvShowService a la inyección de dependencias
builder.Services.AddSingleton<TvShowService>();

// Agregar servicios a la contenedor de dependencias
builder.Services.AddControllers();

// Agregar Swagger para la documentación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
