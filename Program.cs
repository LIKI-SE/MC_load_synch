using System.IO;
using System;

string sourcePath= @"C:\MinecraftSync\WorldA";

string destinationPath = @"C:\MinecraftSync\WorldB";

Console.WriteLine("Hello, welcome to MC_load_synch");

while (true){
    Console.WriteLine(" ");

    Console.WriteLine("Press A for synch A->B");
    Console.WriteLine("Press B for changing source & destination path");
    Console.WriteLine("Press C for automatic folder creation");
    Console.WriteLine("Press D for info of path locations");
    Console.WriteLine("Press Q to exit program");
    
    string Synch = Console.ReadLine();
    
    switch (Synch){
        case "A":
        if (Directory.Exists(sourcePath) == true && Directory.Exists(destinationPath)){
                DateTime dt  = Directory.GetCreationTime(sourcePath);
                string[] files = Directory.GetFiles(sourcePath);
                Console.WriteLine(sourcePath + "created at " + dt + " time");
                foreach(string file in files){
                    try{
                        string filename = Path.GetFileName(file);
                        string destination = Path.Combine(destinationPath, filename);
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
            Directory.CreateDirectory(sourcePath);
            Directory.CreateDirectory(destinationPath);
        }
        break;
        case "B":
        Console.WriteLine("What path do you source to be?");
        sourcePath = Console.ReadLine();
        Console.WriteLine("New source path is: " + sourcePath);
        Console.WriteLine("What path do you destination to be?");
        destinationPath = Console.ReadLine();
        Console.WriteLine("New desitnation path is: " + destinationPath);
        break;
    
        case "C":
        sourcePath = @"C:\MinecraftSync\WorldA";
        destinationPath = @"C:\MinecraftSync\WorldB";
        break;
        case "D":
        Console.WriteLine("Current source path: " + sourcePath);
        Console.WriteLine("Current destination path: " + destinationPath);
        break;

        case "Q":
        return;
        break;
    
    }

}

