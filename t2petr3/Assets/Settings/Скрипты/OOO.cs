using System;
using System.Collections.Generic;
using System.Linq;

public class LevelScoreCalculator
{
    // ���� ��� �������� ����������� ���� �����������
    private List<int> scoreBoard = new List<int>();

    // ���������
    private const int InitialScore = 10000;
    private const int TimePenaltyPerSecond = 50;
    private const int ItemBonus = 500;

    public void PlayLevel(int difficultyCoefficient, int timeSpentInSeconds, int itemsCollected)
    {
        // ������ �����
        int finalScore = InitialScore * difficultyCoefficient
                         - (timeSpentInSeconds * TimePenaltyPerSecond)
                         + (itemsCollected * ItemBonus);

        // ���� ���� ������ 0, ������������ � 0
        finalScore = Math.Max(finalScore, 0);

        // ���������� ��������� � ����
        scoreBoard.Add(finalScore);

        // ��������� ���������� �� ��������
        scoreBoard = scoreBoard.OrderByDescending(score => score).ToList();

        // ����� ���������� ������� ����
        Console.WriteLine($"��� ���������: {finalScore} �����.");
    }

    public void ShowScoreBoard()
    {
        Console.WriteLine("������� �����������:");
        for (int i = 0; i < scoreBoard.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scoreBoard[i]} �����");
        }
    }
}

public class Program
{
    public static void Main()
    {
        LevelScoreCalculator scoreCalculator = new LevelScoreCalculator();

        // ������ ����������� ������
        scoreCalculator.PlayLevel(2, 100, 5); // ����������� ���������: 2, �����: 100 ���, ������� ���������: 5
        scoreCalculator.PlayLevel(3, 200, 10); // ����������� ���������: 3, �����: 200 ���, ������� ���������: 10
        scoreCalculator.PlayLevel(1, 50, 3); // ����������� ���������: 1, �����: 50 ���, ������� ���������: 3

        // ����� ������� ��������
        scoreCalculator.ShowScoreBoard();
    }
}
