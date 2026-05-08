using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Представляє навчальний заклад із набором характеристик для ідентифікації та порівняння.
/// </summary>
public class EducationalInstitution : IEquatable<EducationalInstitution>
{
    public string Name { get; set; }
    public int AccreditationLevel { get; set; }
    public int StudentCount { get; set; }
    public int FoundationYear { get; set; }
    public string City { get; set; }

    /// <summary>
    /// Ініціалізує новий екземпляр класу з визначеними параметрами.
    /// </summary>
    public EducationalInstitution(string name, int accreditationLevel, int studentCount, int foundationYear, string city)
    {
        Name = name;
        AccreditationLevel = accreditationLevel;
        StudentCount = studentCount;
        FoundationYear = foundationYear;
        City = city;
    }

    /// <summary>
    /// Визначає, чи є два об'єкти ідентичними на основі значень усіх полів.
    /// </summary>
    public bool Equals(EducationalInstitution other)
    {
        if (other == null) return false;
        return Name == other.Name &&
               AccreditationLevel == other.AccreditationLevel &&
               StudentCount == other.StudentCount &&
               FoundationYear == other.FoundationYear &&
               City == other.City;
    }

    public override bool Equals(object obj) => Equals(obj as EducationalInstitution);

    public override int GetHashCode() => HashCode.Combine(Name, AccreditationLevel, StudentCount, FoundationYear, City);

    public override string ToString()
    {
        return $"[{AccreditationLevel} рівень] {Name} ({City}, Студентів: {StudentCount}, Рік: {FoundationYear})";
    }
}

/// <summary>
/// Виконавчий клас для демонстрації сортування та пошуку в масиві об'єктів.
/// </summary>
public class Lab3
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        EducationalInstitution[] institutions = {
            new EducationalInstitution("КПІ", 4, 25000, 1898, "Київ"),
            new EducationalInstitution("КНУ", 4, 26000, 1834, "Київ"),
            new EducationalInstitution("ЛНУ", 4, 20000, 1661, "Львів"),
            new EducationalInstitution("Коледж зв'язку", 2, 1500, 1921, "Київ"),
            new EducationalInstitution("Будівельний технікум", 2, 1800, 1944, "Одеса")
        };

        Console.WriteLine("--- Початковий масив ---");
        PrintArray(institutions);

        EducationalInstitution[] sortedInstitutions = SortInstitutions(institutions);

        Console.WriteLine("\n--- Відсортований масив ---");
        PrintArray(sortedInstitutions);

        EducationalInstitution target = new EducationalInstitution("КПІ", 4, 25000, 1898, "Київ");
        Console.WriteLine($"\nШукаємо: {target}");

        int foundIndex = FindInstitution(sortedInstitutions, target);
        
        if (foundIndex != -1)
        {
            Console.WriteLine($"Об'єкт знайдено! Індекс: {foundIndex}");
        }
        else
        {
            Console.WriteLine("Об'єкт не знайдено.");
        }
    }

    /// <summary>
    /// Сортує масив: за рівнем акредитації (зростання) та кількістю студентів (спадання).
    /// </summary>
    public static EducationalInstitution[] SortInstitutions(EducationalInstitution[] array)
    {
        return array
            .OrderBy(inst => inst.AccreditationLevel)
            .ThenByDescending(inst => inst.StudentCount)
            .ToArray();
    }

    /// <summary>
    /// Здійснює пошук ідентичного об'єкта в масиві та повертає його індекс.
    /// </summary>
    public static int FindInstitution(EducationalInstitution[] array, EducationalInstitution target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(target)) 
            {
                return i;
            }
        }
        return -1;
    }

    private static void PrintArray(EducationalInstitution[] array)
    {
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
}