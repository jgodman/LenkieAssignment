using JsonFileDAO;
using Library.IData;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<IBookDAO, BookDAO>();
builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.ApiName = "webAPIClient";
        options.Authority = "https://localhost:44343";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("libraryApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "read");
    });

    options.AddPolicy("libraryAdminApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "admin");
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    option.IncludeXmlComments(xmlPath);
    option.CustomSchemaIds(type => type.ToString());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization("libraryApiScope", "libraryAdminApiScope");
});

app.MapControllers();

app.Run();
