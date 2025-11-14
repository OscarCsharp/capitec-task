using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using web_api.Config;
using web_api.Data;
using web_api.Entities;
using web_api.Interface;
using web_api.Repository;
using web_api.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var key = builder.Configuration["ApplicationSettings:JWT_Secret"];
if (string.IsNullOrEmpty(key)) { throw new InvalidOperationException("JWT Key is not configured."); }

var issuer = builder.Configuration["ApplicationSettings:Issuer"];
if (issuer == null) { throw new InvalidOperationException("JWT Issuer is missing."); }

var audience = builder.Configuration["ApplicationSettings:Audience"];
if (audience == null) { throw new InvalidOperationException("Audience is missing."); }

builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));
builder.Services.Configure<DefaultSettings>(builder.Configuration.GetSection("DefaultSettings"));
builder.Services.Configure<DefaultSettings>(builder.Configuration.GetSection("DefaultUsers"));

builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
builder.Services.AddScoped<IRepository<Appointment>, Repository<Appointment>>();
builder.Services.AddScoped<IRepository<Branch>, Repository<Branch>>();
builder.Services.AddScoped<IRepository<Invoice>, Repository<Invoice>>();
builder.Services.AddScoped<IRepository<InvoiceNotification>, Repository<InvoiceNotification>>();
builder.Services.AddScoped<IRepository<Transaction>, Repository<Transaction>>();
builder.Services.AddScoped<IRepository<TransactionDispute>, Repository<TransactionDispute>>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddSingleton<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAppointment, AppointmentService>();
builder.Services.AddScoped<IInvoice, InvoiceService>();
builder.Services.AddScoped<IInvoiceNotification, InvoiceNotificationService>();
builder.Services.AddScoped<ITransaction, TransactionService>();
builder.Services.AddScoped<ITransactionDispute, TransactionDisputeService>();
builder.Services.AddScoped<IBranch, BranchService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var clientApp = builder.Configuration.GetSection("ApplicationSettings:ClientApp").Get<string>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins",
        policy => policy.WithOrigins(clientApp)
          .AllowAnyHeader()
          .AllowAnyMethod());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
     {
       ValidateIssuerSigningKey = true,
       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
       ValidateIssuer = true,
       ValidateAudience = true,
       ValidIssuer = issuer,
       ValidAudience = audience,
       ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();
builder.Services.AddIdentityCore<User>()
                .AddRoles<Role>()//For Roles in the database
               .AddEntityFrameworkStores<DataContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
