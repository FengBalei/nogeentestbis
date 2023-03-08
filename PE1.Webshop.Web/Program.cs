var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "Bestel Naamplaat",
    pattern: "Plates/PersonalizeAndOrder/{id?}",
    defaults: new { controller = "Plates", action = "PersonalizeAndOrder" }
    );

app.MapControllerRoute(
    name: "Bestel gepersonaliseerd voorwerp",
    pattern: "Tailor_Mades/PersonalizeAndOrder/{id?}",
    defaults: new { controller = "Tailor_Mades", action = "PersonalizeAndOrder" }
    );

app.MapControllerRoute(
    name: "Bestel Los Teken",
    pattern: "LooseSigns/PersonalizeAndOrder/{id?}",
    defaults: new { controller = "LooseSigns", action = "PersonalizeAndOrder" }
    );

app.MapControllerRoute(
    name: "Naamplaatjes",
    pattern: "Plates/GetAllPlates",
    defaults: new { controller = "Plates", action = "GetAllPlates" }
    );

app.MapControllerRoute(
    name: "Losse Tekens",
    pattern: "LooseSigns/Index",
    defaults: new { controller = "LooseSigns", action = "Index" }
    );

app.MapControllerRoute(
    name: "showItemsByDimensionWithACertainFromPrice",
    pattern: "Search/GetItemsWithACertainDimensionandFromPrice/{dimension}/{fromPrice}",
    defaults: new { controller = "Search", action = "GetItemsWithACertainDimensionandFromPrice" }
    );

app.MapControllerRoute(
    name: "showItemsByMaterialAndFromPrice",
    pattern: "Search/GetItemsWithCertainMaterialAndPrice/{material}/{fromPrice}",
    defaults: new { controller = "Search", action = "GetItemsWithCertainMaterialAndPrice" }
    );

app.MapControllerRoute(
    name: "showAvailableItemsWithACertainFromPrice",
    pattern: "Search/GetAvailableItemsWithACertainFromPrice/{available:bool}/{fromPrice}",
    defaults: new { controller = "Search", action = "GetAvailableItemsWithACertainFromPrice" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();