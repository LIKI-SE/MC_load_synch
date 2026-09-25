using System.IO;
using System;

string worldPath = @"C:\MinecraftSyncTest\WorldA";

string newPath = @"C:\MinecraftSyncTest\WorldB";

if (Directory.Exists(worldPath) == true && Directory.Exists(newPath)){
        DateTime dt  = Directory.GetCreationTime(worldPath);
        string[] files = Directory.GetFiles(worldPath);
        Console.WriteLine("It exists");
        Console.WriteLine(worldPath + "created at " + dt + " time");
        foreach(string file in files){
            try{
                string filename = Path.GetFileName(file);
                string destination = Path.Combine(newPath, filename);
                File.Copy(file, destination);
                Console.WriteLine(filename);  
            }
      catch{
          string filename = Path.GetFileName(file);
          Console.WriteLine("This file had a copy issue: " + filename);
      }      
    }
} else {
    Directory.CreateDirectory(worldPath);
    Directory.CreateDirectory(newPath);
}
