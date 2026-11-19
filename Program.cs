using BitFlipBlazor.Components;
using BitFlipBlazor.Services;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var url = builder.Configuration["Supabase:Url"]
    ?? throw new InvalidOperationException("Missing Supabase:Url configuration.");
var key = builder.Configuration["Supabase:Key"]
    ?? throw new InvalidOperationException("Missing Supabase:Key configuration.");

var supabase = new Supabase.Client(url, key, new SupabaseOptions
{
    AutoConnectRealtime = false
});
await supabase.InitializeAsync();

builder.Services.AddSingleton(supabase);

builder.Services.AddScoped<MissionService>();
builder.Services.AddScoped<ScoreService>();
builder.Services.AddScoped<UserSession>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();