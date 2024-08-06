// See https://aka.ms/new-console-template for more information

using DesignPatterns.Model;
using System.Xml.Linq;


var engine = new RobotPart("Engine", weight:25, isElectric:false, isMobile:true);

var builder = new MachineBuilder<Robot,RobotPart>();
var rotor = new RobotPart(name:"Rotor",weight:10, isElectric:true, isMobile:true);
builder.Add(rotor);
builder.Add(rotor.FullClone());
builder.Add(rotor.FullClone());
builder.Add((RobotPart)rotor.Clone());
var robot = builder.GetValue();
robot.Name = "Walli";

var machineBuilder = new MachineBuilder<Machine<Part>, Part>();
var frame = new Part(name:"Каркас", weight:15);
machineBuilder.Add(frame);
machineBuilder.Add(engine.FullClone());
var machine = machineBuilder.GetValue();
machine.Name = "Charlie";

var newRobot = robot.FullClone();
newRobot.Name = "Igor";
newRobot.Add(new RobotPart(name:"Flashlight", weight:5, isElectric:true, isMobile:false));

robot.Add(engine);

LogRobot(robot);
LogRobot(newRobot);
LogMachine(machine);

TestingСloning();

string Which(bool value) => value? "является": "не является"; 

void LogRobot(Machine<RobotPart> robot)
{
    Console.WriteLine($"Робот {robot.Name} вес:{robot.Sum(p => p.Weight)} кг, {Which(robot.All(p => p.IsElectric))} полностью электрическим.");
}

void LogMachine(Machine<Part> machine)
{
    Console.WriteLine($"Механизм {machine.Name} вес:{machine.Sum(p => p.Weight)} кг.");
}

void TestingСloning() 
{
    var builder = new MachineBuilder<Robot, RobotPart>();
    builder.Add(new RobotPart(name: "Rotor", weight: 10, isElectric: true, isMobile: true));
    builder.Add(rotor.FullClone());
    builder.Add(rotor.FullClone());
    builder.Add(new RobotPart(name: "Propeller", weight: 5.5, isElectric: false, isMobile: true));
    var robotOne = builder.GetValue();
    robotOne.Name = "Walli";
    var robotOther = robotOne.FullClone(); // Создали нового робота.
    robotOther.Name = "Charlie";
    robotOther.Add(new RobotPart("Engine", weight: 25, isElectric: false, isMobile: true));

    //выводим результат.

    Console.WriteLine("-------------------------------");
    Console.WriteLine(robotOne.GetFullSpecification());
    LogRobot(robotOne);
    Console.WriteLine("-------------------------------");
    Console.WriteLine(robotOther.GetFullSpecification());
    LogRobot(robotOther);
    Console.WriteLine("-------------------------------");
}