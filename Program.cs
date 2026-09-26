using System.IO;
using System;

string sourcePath= @"C:\Liv_Synch_loader\WorldA";

string destinationPath = @"C:\Liv_Synch_loader\WorldB";

string cloudPath = @"C:\Users\livki\OneDrive\Liv_Synch_loader";

Console.WriteLine("Hello, welcome to MC_load_synch");

while (true){
    Console.WriteLine(" ");

    Console.WriteLine("Press A for synch A->B");
    Console.WriteLine("Press B for changing source & destination path");
    Console.WriteLine("Press C for automatic folder creation");
    Console.WriteLine("Press D for info of path locations");
    Console.WriteLine("Press E to swap synch direction");
    Console.WriteLine("Press F to Cloud synchronization");
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
        sourcePath = @"C:\Liv_Synch_loader\WorldA";
        destinationPath = @"C:\Liv_Synch_loader\WorldB";
        Console.WriteLine("Autocreated these paths: " + sourcePath + " & " + destinationPath);
        break;
        
        case "D":
        Console.WriteLine("Current source path: " + sourcePath);
        Console.WriteLine("Current destination path: " + destinationPath);
        break;
        
        case "E":
        Console.WriteLine("Old order is from " + sourcePath + " to " + destinationPath);
        string backupSource = sourcePath;
        string backupDestination = destinationPath;
        sourcePath = backupDestination;
        destinationPath = backupSource;
        
        Console.WriteLine("Synch direction has reversed!");
        Console.WriteLine("BackupSource is: " + backupSource + " while newSource is: " + sourcePath);
        Console.WriteLine("BackupSource is: " + backupDestination + " while newSource is: " + destinationPath);
        break;

        case "F":
        Console.WriteLine("Transfer or Retrieve?");
        string Answer = Console.ReadLine();
        if (Answer == "Transfer"){
            destinationPath = cloudPath;
            Console.WriteLine("Cloud transfer is enabled: " +  destinationPath);
        } else if (Answer == "Retrieve") {
            sourcePath = cloudPath;
            Console.WriteLine("Cloud retrival is enabled: " +  destinationPath); 
        } else {
            break;
        }
        
        break;

        case "Q":
        return;
        break;
    
    }

}

