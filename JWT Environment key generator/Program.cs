using System.Text;

string key = KeyGenerator.GenerateKey();
Console.WriteLine(key);

var result = Encoding.UTF8.GetBytes(key);
Console.WriteLine("\nLenght:" + key.Length);