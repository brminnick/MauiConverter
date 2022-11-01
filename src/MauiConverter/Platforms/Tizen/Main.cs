using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace MauiConverter;

class Program : MauiApplication
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args) => new Program().Run(args);
}