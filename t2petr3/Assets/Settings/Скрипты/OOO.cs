using System;
using System.Collections.Generic;
using System.Linq;

public class LevelScoreCalculator
{
    // Лист для хранения результатов всех прохождений
    private List<int> scoreBoard = new List<int>();

    // Константы
    private const int InitialScore = 10000;
    private const int TimePenaltyPerSecond = 50;
    private const int ItemBonus = 500;

    public void PlayLevel(int difficultyCoefficient, int timeSpentInSeconds, int itemsCollected)
    {
        // Расчёт очков
        int finalScore = InitialScore * difficultyCoefficient
                         - (timeSpentInSeconds * TimePenaltyPerSecond)
                         + (itemsCollected * ItemBonus);

        // Если очки меньше 0, приравниваем к 0
        finalScore = Math.Max(finalScore, 0);

        // Записываем результат в лист
        scoreBoard.Add(finalScore);

        // Сортируем результаты по убыванию
        scoreBoard = scoreBoard.OrderByDescending(score => score).ToList();

        // Вывод результата текущей игры
        Console.WriteLine($"Ваш результат: {finalScore} очков.");
    }

    public void ShowScoreBoard()
    {
        Console.WriteLine("Таблица результатов:");
        for (int i = 0; i < scoreBoard.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scoreBoard[i]} очков");
        }
    }
}

public class Program
{
    public static void Main()
    {
        LevelScoreCalculator scoreCalculator = new LevelScoreCalculator();

        // Пример прохождений уровня
        scoreCalculator.PlayLevel(2, 100, 5); // Коэффициент сложности: 2, время: 100 сек, собрано предметов: 5
        scoreCalculator.PlayLevel(3, 200, 10); // Коэффициент сложности: 3, время: 200 сек, собрано предметов: 10
        scoreCalculator.PlayLevel(1, 50, 3); // Коэффициент сложности: 1, время: 50 сек, собрано предметов: 3

        // Вывод таблицы рейтинга
        scoreCalculator.ShowScoreBoard();
    }
}
