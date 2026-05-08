using System;
using Xunit;

/// <summary>
/// Набір тестів для перевірки коректності логіки сортування та пошуку.
/// </summary>
public class UnitTest1
{
    /// <summary>
    /// Перевіряє, чи виконується сортування за двома полями згідно з вимогами.
    /// </summary>
    [Fact]
    public void SortInstitutions_ShouldSortByAccreditationAscAndStudentsDesc()
    {
        var input = new[] {
            new EducationalInstitution("А", 2, 100, 2000, "Місто"),
            new EducationalInstitution("Б", 1, 500, 2000, "Місто"),
            new EducationalInstitution("В", 1, 1000, 2000, "Місто")
        };
        
        var expected = new[] {
            new EducationalInstitution("В", 1, 1000, 2000, "Місто"),
            new EducationalInstitution("Б", 1, 500, 2000, "Місто"),
            new EducationalInstitution("А", 2, 100, 2000, "Місто")
        };

        var actual = Lab3.SortInstitutions(input);

        Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Перевіряє успішний пошук ідентичного об'єкта в масиві.
    /// </summary>
    [Fact]
    public void FindInstitution_ShouldReturnValidIndex_WhenObjectExists()
    {
        var array = new[] {
            new EducationalInstitution("КНУ", 4, 26000, 1834, "Київ"),
            new EducationalInstitution("КПІ", 4, 25000, 1898, "Київ")
        };
        var target = new EducationalInstitution("КПІ", 4, 25000, 1898, "Київ");

        int index = Lab3.FindInstitution(array, target);

        Assert.Equal(1, index);
    }

    /// <summary>
    /// Перевіряє роботу пошуку, якщо ідентичний об'єкт відсутній у масиві.
    /// </summary>
    [Fact]
    public void FindInstitution_ShouldReturnMinusOne_WhenObjectDoesNotExist()
    {
        var array = new[] {
            new EducationalInstitution("КНУ", 4, 26000, 1834, "Київ")
        };
        var target = new EducationalInstitution("НАУ", 4, 15000, 1933, "Київ");

        int index = Lab3.FindInstitution(array, target);

        Assert.Equal(-1, index);
    }
}