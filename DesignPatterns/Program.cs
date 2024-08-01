// See https://aka.ms/new-console-template for more information

using DesignPatterns.Model;



var builder = new MachineBuilder<Robot,RobotPart>();
var rotor = new RobotPart("Rotor", 10, true, true);
builder.Add(rotor);
builder.Add(rotor.FullClone());
builder.Add(rotor.FullClone());
var engine = new RobotPart("Engine", 25, false, true);
builder.Add(engine);
builder.Add((RobotPart)rotor.Clone());
var robot = builder.GetValue();
robot.Name = "Walli";

var machineBuilder = new MachineBuilder<Machine<Part>, Part>();
var frame = new Part("Каркас", 15);
machineBuilder.Add(frame);
machineBuilder.Add(engine.FullClone());
var machine = machineBuilder.GetValue();
machine.Name = "Charlie";

Console.WriteLine($"Робот {robot.Name} вес:{robot.Sum(p=>p.Weight)} кг, {Which(robot.All(p => p.IsElectric))} полностью электрическим.");
Console.WriteLine($"Механизм {machine.Name} вес:{machine.Sum(p => p.Weight)} кг.");

string Which(bool value) { if (value) return "является"; else return "не является"; }
