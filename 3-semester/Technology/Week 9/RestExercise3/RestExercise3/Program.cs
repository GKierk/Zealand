using ActorRepositoryLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "AllowAll",
            policy =>
            {
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
    });
builder.Services.AddControllers();
builder.Services.AddSingleton<ActorsRepository>(new ActorsRepository());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
