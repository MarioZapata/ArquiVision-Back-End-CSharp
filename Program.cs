using ArquiVision.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ArquiVision.Services;
using ArquiVision.Services.Modulo_Actividades;
using ArquiVision.Services.Modulo_Catalogo;
using ArquiVision.Services.Modulo_Materiales;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddAutoMapper(typeof(MappingProfile)); // Aquí pasas el tipo del perfil



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Cambia esto por el origen de tu aplicación Angular
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


// Configurar la autenticación con JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserTypePolicy", policy =>
        policy.RequireClaim("userType", "1")); // Aquí especificas qué userType es requerido para acceder
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//Mis Servicios
builder.Services.AddScoped<MetodosReutilzables>(); // O AddSingleton o AddTransient según el caso.
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ICatTipoConstruccionService, CatTipoConstruccionService>();
builder.Services.AddScoped<ICat_EstadoActividad, CatEstadoActividadService>();
builder.Services.AddScoped<ICatEstadoProyectoService, CatEstadoProyectoService>();
builder.Services.AddScoped<ICatPrioridadService, CatPrioridadService>();
builder.Services.AddScoped<ICatTipoActividadService, CatTipoActividadService>();
builder.Services.AddScoped<ICatTipoUsuarioService, CatTipoUsuarioService>();
builder.Services.AddScoped<ITokenValidationService, TokenValidationService>();
builder.Services.AddScoped<ICatTipoMaterialService, CatTipoMaterialService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<CorreoService>();
builder.Services.AddScoped<ProyectoService>();
builder.Services.AddScoped<ActividadService>();
builder.Services.AddScoped<ICarritoService, CarritoService>(); // Agregar el servicio de carrito
builder.Services.AddScoped<IPedidoService, PedidoService>(); // Registrar el servicio



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowOrigin");
    //app.UseCors("AllowHamachi");

}

app.UseHttpsRedirection();

// Añadir los middlewares para autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
