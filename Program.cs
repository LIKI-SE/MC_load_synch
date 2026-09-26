using System.IO;
using System;

string worldPath = @"C:\MinecraftSyncTest\WorldA";

string newPath = @"C:\MinecraftSyncTest\WorldB";

while (true){
    
    Console.WriteLine("Hello, welcome to MC_load_synch");
    
    Console.WriteLine("Press A for synch A->B");
    Console.WriteLine("Press B for synch direction");
    Console.WriteLine("Press C for automatic folder creation");
    Console.WriteLine("Press Q to exit program");
    
    string Synch = Console.ReadLine();
    
    switch (Synch){
        case "A":
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
        break;
        case "B":
        Console.WriteLine("What path do you source to be?");
        worldPath = Console.ReadLine();
        Console.WriteLine("New source path is: " + worldPath);
        Console.WriteLine("What path do you destination to be?");
        newPath = Console.ReadLine();
        Console.WriteLine("New desitnation path is: " + newPath);
        break;
    
        case "C":
        worldPath = @"C:\MinecraftSyncTest\WorldA";
        newPath = @"C:\MinecraftSyncTest\WorldB";
        break;

        case "Q":
        return;
        break;
    
    }

}

