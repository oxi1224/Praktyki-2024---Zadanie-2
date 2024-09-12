using System.Text;

Console.WriteLine("Podaj ściężkę pliku: ");
string? filePath = Console.ReadLine();

if (!File.Exists(filePath)) {
  Console.WriteLine("Plik nie istnieje");
  return;
}

if (filePath.Substring(filePath.LastIndexOf(".") + 1) != "txt") {
  Console.WriteLine("Podany plik nie jest plikiem tekstowym");
  return;
}

string locPath = filePath.Substring(0, filePath.LastIndexOf("."));
FileStream fin = File.Open(filePath, FileMode.Open);
string zawartosc = new StreamReader(fin).ReadToEnd();
string nowa_zawartosc = string.Join(" ", zawartosc.Split(" ").Select(slowo => slowo.Replace("praca", "job")));

string data = DateTime.Now.ToString("ddMMyyyy");
FileStream fout = File.Open($"{locPath}_changed-{data}.txt", FileMode.OpenOrCreate);
fout.Write(Encoding.UTF8.GetBytes(nowa_zawartosc));
fout.Close();
