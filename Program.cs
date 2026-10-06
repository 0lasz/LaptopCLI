using LaptopCLI;
// lista létrehozása
List<Laptop>Laptops = new List<Laptop>();
// listába írás (a txt-ből belehelyezzük soronként a listába a construktor alapján az adatokat)
using (StreamReader r = new StreamReader("../../../forras/laptops.txt")) 
{
    r.ReadLine(); //elsó sor skippelése
    while (!r.EndOfStream) //amíg fut a txt
    {string line = r.ReadLine(); // sorkiolvasás txt-ből
        Laptops.Add(new Laptop(line)); //kiolvasott sor hozzáadása a class típusú listához
    };
    
}

Console.WriteLine("5. feladat - Kiírás");
foreach (var line in Laptops) //ciklussal kiiratjuk az összes lista elemet
{
    Console.WriteLine(line.ToString()); //a ToString methodussal adjuk meg a kiirandó adatokat
}

Console.WriteLine("6. feladat");

var f6 = Laptops.Where(x => x.CPU.Contains("Intel Core i7") && x.Storage.Contains("SSD"));

int counter = 1;

foreach (var line in f6) 
{
    Console.WriteLine($"[{counter++}] {line.Category.CategoryName} | {line.Manufacturer.ManufacturerName} {line.Model} | {line.OS}");
}

var atlag = f6.Select(x => x.Price).Average();
Console.WriteLine($"A laptopok átlag ára {atlag} INR");

Console.WriteLine("7. feladat - fájlba írás");

var olcso = Laptops.Where(x => x.Category.CategoryName == "Gaming").OrderBy(x => x.Price).Take(20);

using (StreamWriter w = new StreamWriter("../../../forras/cheap.txt")) 
{
    foreach (var line in olcso) 
    {
        w.WriteLine($"{line.Manufacturer.ManufacturerName} {line.Model}\n" +
            $"\t\t{line.CPU}\n" +
            $"\t\t{line.Storage}\n" +
            $"\t\t{line.Screen}\n");
    }
}

    