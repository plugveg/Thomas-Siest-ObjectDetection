using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thomas.Siest.ObjectDetection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello to the Microsoft Technologies 2025 Examen - Thomas Siest ObjectDetection!");

app.MapPost("/ObjectDetection", async ([FromForm] IFormFileCollection files) =>
{
    if (files.Count < 1)
        return Results.BadRequest("No files were provided.");

    await using var sceneSourceStream = files[0].OpenReadStream();
    using var sceneMemoryStream = new MemoryStream();
    sceneSourceStream.CopyTo(sceneMemoryStream);
    var imageSceneData = sceneMemoryStream.ToArray();

    var objectDetection = new Thomas.Siest.ObjectDetection.ObjectDetection();
    var detectObjectInScenesResults = await objectDetection.DetectObjectInScenesAsync(new[] { imageSceneData });

    var resultImageData = detectObjectInScenesResults[0].ImageData;

    return Results.File(resultImageData, "image/jpg");
}).DisableAntiforgery();


app.Run();
