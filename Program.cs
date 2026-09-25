using System.IO;
using System;

string worldPath = @"C:\MinecraftSyncTest\WorldA";

if (Directory.Exists(worldPath) == true){
    DateTime dt  = Directory.GetCreationTime(worldPath);
    string[] files = Directory.GetFiles(worldPath);
    Console.WriteLine("It exists");
    Console.WriteLine(worldPath + "created at " + dt + " time");
    foreach(string file in files){
        string filename = Path.GetFileName(file);
        Console.WriteLine(filename);

    }

} else {
    Directory.CreateDirectory(worldPath);
}
