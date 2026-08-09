using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StockControlApi.Data;
using StockControlApi.Service;
using StockControlApi.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApiStockControlContext>(options => options.UseNpgsql(connectionString));

// Adiciona suporte aos Controllers
builder.Services.AddControllers();

// Adiciona o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStockMovementService, StockMovementService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IUserService, UserService>();

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("key").Get<string>());

builder.Services.AddAuthentication(
    x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
)
.AddJwtBearer(
    x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
);

builder.Services.AddSingleton<TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "API funcionando!");

app.Run(); ;