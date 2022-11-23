using DesafioBackEnvelope.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureSwagger();

builder.Services.AddInfrastructureAPI(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => //
    {
        // Desabilitar swagger schemas
        options.DefaultModelsExpandDepth(-1);

        //Configuração swagger local
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DesafioBackEnvelope.API.v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//Expõe a classe para o teste tornasndo ela publica
public partial class Program { }