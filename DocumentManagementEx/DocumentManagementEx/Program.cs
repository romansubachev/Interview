// See https://aka.ms/new-console-template for more information


using DocumentManagementEx;
using Microsoft.EntityFrameworkCore;

var docManager = new DocumentManager();
docManager.HandleDocument("example.pdf", "userEmail@test.com");
Console.WriteLine("Hello, World!");