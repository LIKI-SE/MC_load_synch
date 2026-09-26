using System.IO;
using System;

string worldPath = @"C:\MinecraftSyncTest\WorldA";

string newPath = @"C:\MinecraftSyncTest\WorldB";

if (Directory.Exists(worldPath) == true && Directory.Exists(newPath)){
        DateTime dt  = Directory.GetCreationTime(worldPath);
        string[] files = Directory.GetFiles(worldPath);
        Console.WriteLine(worldPath + "created at " + dt + " time");
        foreach(string file in files){
            try{
                string filename = Path.GetFileName(file);
                string destination = Path.Combine(newPath, filename);
                DateTime dt_org  = File.GetLastWriteTimeUtc(file);
                DateTime dt_copy  = File.GetLastWriteTimeUtc(destination);

                if (File.Exists(destination) == false){
                    File.Copy(file, destination);
                    Console.WriteLine("File copied: " + filename);
                    
                } else if (dt_org != dt_copy) {
                    Console.WriteLine("File out of synch: " + filename);
                    File.Delete(destination);
                    File.Copy(file, destination);

                } else {
                    Console.WriteLine("File skipped: " + filename);
                }
    
 
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
