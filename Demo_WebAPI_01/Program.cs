//# Installation et configuration de la Web API (Via un builder)
var builder = WebApplication.CreateBuilder(args);

// Ajout des services necessaires à la Web API

// TODO Des trucs à découvrir :o

// FIXME Ceux-ci sera expliqué jeudi, promis ! Bisous
builder.Services.AddCors(options =>
{
    options.AddPolicy("FFA", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
    });
});

// - Les controllers : Logique des endpoints de la Web API
builder.Services.AddControllers();

// - Package pour "Swagger/OpenAPI" https://aka.ms/aspnetcore/swashbuckle
//   Remarque : A été modifié depuis le .Net 9
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build de la Web API
var app = builder.Build();


//# Configuration du flux lors d'une requete (Middleware)

// Middleware uniquement lors du dev (-> Swagger UI)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware intégré à la requete

// - ...
app.UseCors("FFA");

// - Redirection vers du HTTPS
app.UseHttpsRedirection();

// - Active les fonctionnalité d'autorisation
app.UseAuthorization();

// - Ajoute le "routing" de la requete vers les controllers
app.MapControllers();

// - Demarre l'app
app.Run();
