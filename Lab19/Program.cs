using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            List<Computer> listComputers = new List<Computer>()
            {
                new Computer() {Code = "4761281", Manufacturer = "Acer", CpuType = "Intel Celeron", CpuFreq = 2.2, RamCap = 4, HddCap = 128, VramCap = 2, CompPrice = 150, Amount = 32 },
                new Computer() {Code = "4852983", Manufacturer = "HP", CpuType = "Intel Celeron", CpuFreq = 2.1, RamCap = 4, HddCap = 256, VramCap = 2, CompPrice = 150, Amount = 43 },
                new Computer() {Code = "4794032", Manufacturer = "MSI", CpuType = "Intel Pentium", CpuFreq = 4, RamCap = 4, HddCap = 128, VramCap = 3, CompPrice = 190, Amount = 29 },
                new Computer() {Code = "4876543", Manufacturer = "DEXP", CpuType = "Intel Pentium", CpuFreq = 4.1, RamCap = 8, HddCap = 240, VramCap = 3, CompPrice = 210, Amount = 26 },
                new Computer() {Code = "4815779", Manufacturer = "HP", CpuType = "AMD Athlon", CpuFreq = 2.3, RamCap = 8, HddCap = 128, VramCap = 4, CompPrice = 230, Amount = 24 },
                new Computer() {Code = "4818800", Manufacturer = "Lenovo", CpuType = "AMD Athlon", CpuFreq = 2.3, RamCap = 8, HddCap = 256, VramCap = 4, CompPrice = 250, Amount = 31 },
                new Computer() {Code = "4736675", Manufacturer = "Dell", CpuType = "Intel i3", CpuFreq = 3.6, RamCap = 8, HddCap = 256, VramCap = 4, CompPrice = 320, Amount = 20 },
                new Computer() {Code = "4830448", Manufacturer = "Asus", CpuType = "Intel i5", CpuFreq = 2.9, RamCap = 8, HddCap = 256, VramCap = 4, CompPrice = 350, Amount = 26 },
                new Computer() {Code = "4804536", Manufacturer = "Asus", CpuType = "Intel i5", CpuFreq = 3.3, RamCap = 8, HddCap = 512, VramCap = 4, CompPrice = 390, Amount = 3 }
            };

            Console.WriteLine("\tРабота с LINQ");

            Console.Write("\n Введите модель процессора: ");            
            string cpuType = Console.ReadLine();
            Console.WriteLine(" Модели компьютеров с требуемым типом процессора: ");
            List<Computer> computersByCpu = listComputers
                .Where(c => c.CpuType.ToLower() == cpuType.ToLower())
                .ToList();
            foreach (var c in computersByCpu)
            {
                Console.WriteLine($" Производитель: {c.Manufacturer}; CPU: {c.CpuType} {c.CpuFreq} ГГц; RAM {c.RamCap} Гб; HDD {c.HddCap} Гб; Цена: {c.CompPrice}");
            }
            Console.ReadKey();

            Console.Write("\n Введите требуемый объём оперативной памяти: ");
            byte ramCap = Convert.ToByte(Console.ReadLine());
            Console.WriteLine(" Модели компьютеров с требуемым объёмом оперативной памяти: ");
            List<Computer> computersByRam = listComputers
                .Where(c => c.RamCap >= ramCap)
                .ToList();
            foreach (var c in computersByRam)
            {
                Console.WriteLine($" Производитель: {c.Manufacturer}; CPU: {c.CpuType} {c.CpuFreq} ГГц; RAM {c.RamCap} Гб; HDD {c.HddCap} Гб; Цена: {c.CompPrice}");
            }
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine(" Список всех моделей компьютеров, отсортированный по возрастанию цены:");
            Console.ReadKey();
            List<Computer> computersByPrice = listComputers
                .OrderBy(c => c.CompPrice)
                .ToList();
            foreach (var c in computersByPrice)
            {
                Console.WriteLine($" Производитель: {c.Manufacturer}; CPU: {c.CpuType} {c.CpuFreq} ГГц; RAM {c.RamCap} Гб; HDD {c.HddCap} Гб; Цена: {c.CompPrice}");
            }
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine(" Компьютеры, сгруппированные по модели процессора: ");
            Console.ReadKey();
            List<IGrouping<string, Computer>> computersGroupedByCpu = listComputers
                .GroupBy(c => c.CpuType)
                .ToList();
            foreach (var c in computersGroupedByCpu)
            {
                foreach (var cp in c)
                {
                    Console.WriteLine($" Производитель: {cp.Manufacturer}; CPU: {cp.CpuType} {cp.CpuFreq} ГГц; RAM {cp.RamCap} Гб; HDD {cp.HddCap} Гб; Цена: {cp.CompPrice}");
                }
            }
            Console.ReadKey();
            Console.WriteLine();

            Computer expComputer = computersByPrice.Last();
            Computer cheapComputer = computersByPrice.First();
            Console.WriteLine($" Наиболее дорогой компьютер стоит {expComputer.CompPrice}, наиболее дешёвый - {cheapComputer.CompPrice}");
            Console.ReadKey();
            Console.WriteLine();

            bool compOver30 = listComputers.Any(c => c.Amount > 30);
            if (compOver30)
            {
                Console.WriteLine(" Да, есть модели в количестве более 30 шт");
            }
            else
            {
                Console.WriteLine(" Нет, отсутствуют модели в количестве более 30 шт");
            }

            Console.ReadKey();
        }
    }

    class Computer
    {        
        public string Code { get; set; }
        public string Manufacturer { get; set; }
        public string CpuType { get; set; }
        public int CompPrice { get; set; }
        public double CpuFreq { get; set; }
        public int HddCap { get; set; }
        public byte RamCap { get; set; }
        public byte VramCap { get; set; }
        public byte Amount { get; set; }
    }
}
