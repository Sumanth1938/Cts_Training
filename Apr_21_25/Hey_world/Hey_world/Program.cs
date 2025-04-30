// See https://aka.ms/new-console-template for more information
using Hey_world.Implementation;
using Hey_world.Interfaces;
using Hey_world.Poco;

Console.WriteLine("Hello, World!");

IsayHello hello = new SayHelloOne();
hello.SayHello("John");

SaySomething saySomething = new SaySomething();
saySomething.SayHello("John");