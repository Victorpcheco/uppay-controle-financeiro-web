using ControleFinanceiro.API.Extensions;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infrastructure.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddCorsPolicy();

// HttpContext / UserContext
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, UserContext>();

// AutoMapper
builder.Services.AddAutoMapperProfiles();

// MediatR + ValidationBehavior + Validators
builder.Services.AddMediatRServices();

// Domínios
builder.Services.AddUsuarioServices();
builder.Services.AddContaBancariaServices();
builder.Services.AddCategoriaServices();
builder.Services.AddCartaoServices();
builder.Services.AddMesReferenciaServices();
builder.Services.AddMovimentacaoServices();
builder.Services.AddDashboardServices();

// Controllers + JSON options
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

// Swagger
builder.Services.AddSwaggerDoc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerDoc();
}

app.UseHttpsRedirection();

app.UseCorsPolicy(app.Environment);

app.UseMiddleware<ControleFinanceiro.API.Middlewares.ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

