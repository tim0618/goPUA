using backend.AppDBContext;
using backend.Repository;
using backend.Repository.Interface;
using backend.Service;
using backend.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args); // 建立 Web 應用程式生成器

builder.Services.AddRazorPages(); // 添加 Razor Pages 支援
builder.Services.AddControllers(); // 添加 MVC 控制器支援

// 配置資料庫
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDB"))); // 使用 SQL Server 來配置資料庫連線字串

// Service
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<Token>();

// Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();

// 配置 JWT 驗證
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // 使用 JWT Bearer 驗證方案
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true; // 在驗證失敗時，回應中包含錯誤詳細資訊

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // 驗證 Token 的發行者
            ValidIssuer = "JwtAuthDemo", // 定義合法的發行者

            ValidateAudience = false, // 不驗證 Token 的接受者

            ValidateLifetime = true, // 驗證 Token 是否在有效期內

            ValidateIssuerSigningKey = true, // 驗證簽章的密鑰

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ababababab@cdcdcdcdcd@efefefefef")) // 設定 JWT 簽章的密鑰
        };
    });

// 添加 Swagger/OpenAPI 
builder.Services.AddEndpointsApiExplorer(); // 為 API 端點生成 OpenAPI 規範
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); // 設定 Swagger 文件的標題和版本
});

var app = builder.Build(); // 建立 Web 應用程式

// 配置 HTTP 請求
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // 使用預設的錯誤處理頁面
    app.UseHsts(); // 使用 HSTS (HTTP 嚴格傳輸安全) 頭部
}

app.UseHttpsRedirection(); // 強制使用 HTTPS
app.UseStaticFiles(); // 啟用靜態文件服務
app.UseRouting(); // 啟用路由功能

app.UseAuthentication(); // 啟用身份驗證中間件
app.UseAuthorization(); // 啟用授權中間件

// 啟用 Swagger 生成的 JSON 端點
app.UseSwagger();

// 啟用 Swagger UI 並指定 Swagger JSON 端點
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); // 設定 Swagger UI 的端點
    c.RoutePrefix = "swagger"; // 設定 Swagger UI 的路由前綴為 "swagger"
});

app.MapRazorPages(); // 映射 Razor Pages 端點
app.MapControllers(); // 映射控制器端點

app.Run(); // 啟動應用程式
