//# Installation et configuration de la Web API (Via un builder)
var builder = WebApplication.CreateBuilder(args);

// Ajout des services necessaires à la Web API

// TODO Des trucs à découvrir :o

// Configuration de la sécurité cors
builder.Services.AddCors(options =>
{
    // Ajout une régle -> Tout autorisé (dev uniquement)
    options.AddPolicy("AllowAll", builder =>
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

// - Utilise la regle "cors" précédement configuré
app.UseCors("AllowAll");

// - Autoriser d'acceder au contenu du dossier public (wwwroot)
app.UseStaticFiles();

// - Redirection vers du HTTPS
app.UseHttpsRedirection();

// - Active les fonctionnalité d'autorisation
app.UseAuthorization();

// - Ajoute le "routing" de la requete vers les controllers
app.MapControllers();

// - Demarre l'app
app.Run();
