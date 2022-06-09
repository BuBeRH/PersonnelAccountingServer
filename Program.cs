using PersonnelAccountingServer.Database;
using PersonnelAccountingServer.Classes.Response;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
DBConnect.Connect();

app.MapGet("/getfiltredperson", async (context) =>
{
    var response = context.Response;

    response.Headers.ContentType = "application/json; charset=utf-8";
    if (context.Request.Query["param"] != "")
    {
        response.Headers.ContentType = "application/json; charset=utf-8";
        await response.WriteAsJsonAsync(DBConnect.GetFiltredPersons(context.Request.Query["param"], context.Request.Query["col"]));
    }
});

app.MapGet("/deleteperson", async (context) =>
{
    var response = context.Response;

    if (Int32.TryParse(context.Request.Query["number"], out int number))
    {
        DBConnect.DeletePerson(number);
        await response.WriteAsJsonAsync("{'status':'succes'}");
    }
});

app.MapPost("/updateperson", async (context) =>
{
    var request = context.Request;

    try
    {
        Jperson? person = await request.ReadFromJsonAsync<Jperson>();
        if (person != null)
        {
            DBConnect.UpdatePerson(person);
        }
    }
    catch { }
});

app.MapGet("/getpersons", async (context) =>
{
    var response = context.Response;

    response.Headers.ContentType = "application/json; charset=utf-8";
    await response.WriteAsJsonAsync(DBConnect.GetPersons());

});

app.MapGet("/getperson", async (context) => 
{
    var response = context.Response;

    response.Headers.ContentType = "application/json; charset=utf-8";
    if (Int32.TryParse(context.Request.Query["number"], out int number))
    {
        await response.WriteAsJsonAsync(DBConnect.GetPerson(number));
    }
    else
    {
        await response.WriteAsJsonAsync(DBConnect.GetPerson(1));
    }
});

app.MapPost("/addperson", async (context) =>
{
    var request = context.Request;
    try
    {
        Jperson? person = await request.ReadFromJsonAsync<Jperson>();
        if(person != null)
        {
            DBConnect.AddPerson(person);
        }
    }
    catch { }
});

app.Run();