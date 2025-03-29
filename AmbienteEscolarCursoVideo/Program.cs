using AmbienteEscolarCursoVideo.Data;
using AmbienteEscolarCursoVideo.Services.Aluno;
using AmbienteEscolarCursoVideo.Services.Historico;
using AmbienteEscolarCursoVideo.Services.Materia;
using AmbienteEscolarCursoVideo.Services.Professor;
using AmbienteEscolarCursoVideo.Services.Turma;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion"));
});

builder.Services.AddScoped<IAlunoInterface, AlunoService>();
builder.Services.AddScoped<IHistoricoInterface, HistoricoService>();
builder.Services.AddScoped<ITurmaInterface, TurmaService>();
builder.Services.AddScoped<IProfessorInterface, ProfessorService>();
builder.Services.AddScoped<IMateriaInterface, MateriaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
