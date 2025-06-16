using ConsoleApp1;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    public static class Program
    {
        static void Main()
        {
            var parameters = new RestaurantParameters
            {
                Days = GetInput("Введите количество дней работы ресторана (1-31): ", 1, 31),
                Tables = GetInput("Введите количество столиков в ресторане (1-50): ", 1, 50),
                Occupancy = GetInput("Введите среднюю заполняемость столиков (0-100): ", 0, 100),
                AverageCheck = GetInput("Введите средний чек с одного столика (в рублях): ", 0),
                FoodCostPercent = GetInput("Введите процент расходов на продукты (0-100): ", 0, 100),
                ProfitTaxPercent = GetInput("Введите процент налога на прибыль (0-30): ", 0, 30),
                StaffCount = GetInput("Введите количество сотрудников (1-20): ", 1, 20),
                AverageSalary = GetInput("Введите среднюю зарплату сотрудника (0-100000): ", 0, 100000)
            };

            Validator.ValidateAndThrowRestaurantParameters(parameters);

            double totalIncome = CalculateTotalIncome(parameters);
            double foodExpenses = CalculateFoodExpenses(totalIncome, parameters.FoodCostPercent);
            double salaryExpenses = CalculateSalaryExpenses(parameters.StaffCount, parameters.AverageSalary);
            double netIncomeBeforeTax = CalculateNetIncomeBeforeTax(totalIncome, foodExpenses, salaryExpenses);
            double tax = CalculateTax(netIncomeBeforeTax, parameters.ProfitTaxPercent);
            double netIncomeAfterTax = CalculateNetIncomeAfterTax(netIncomeBeforeTax, tax);

            Console.WriteLine($"Итоговый доход: {totalIncome} руб.");
            Console.WriteLine($"Общие расходы на продукты: {foodExpenses} руб.");
            Console.WriteLine($"Общие расходы на зарплату: {salaryExpenses} руб.");
            Console.WriteLine($"Чистый доход до налогообложения: {netIncomeBeforeTax} руб.");
            Console.WriteLine($"Налог: {tax} руб.");
            Console.WriteLine($"Итоговый доход после налога: {netIncomeAfterTax} руб.");
        }

        static int GetInput(string prompt, int minValue, int maxValue)
        {
            int value;
            do
            {
                Console.Write(prompt);
                value = int.Parse(Console.ReadLine());
            } while (value < minValue || value > maxValue);
            return value;
        }

        static double GetInput(string prompt, double minValue)
        {
            double value;
            do
            {
                Console.Write(prompt);
                value = double.Parse(Console.ReadLine());
            } while (value < minValue);
            return value;
        }

        public static double CalculateTotalIncome(RestaurantParameters parameters)
        {
            Validator.ValidateAndThrowsCalculateTotalIncome(parameters);
            return parameters.Days * parameters.Tables * (parameters.Occupancy / 100) * parameters.AverageCheck;
        }

        public static double CalculateFoodExpenses(double totalIncome, double foodCostPercent)
        {
            Validator.ValidateAndThrowsCalculateFoodExpenses( totalIncome,  foodCostPercent);
            return totalIncome * (foodCostPercent / 100);
        }

        public static double CalculateSalaryExpenses(int staffCount, double averageSalary)
        {
            Validator.ValidateAndThrowsCalculateSalaryExpenses( staffCount,  averageSalary);
            return staffCount * averageSalary;
        }

        public static double CalculateNetIncomeBeforeTax(double totalIncome, double foodExpenses, double salaryExpenses)
        {
            Validator.ValidateAndThrowsCalculateNetIncomeBeforeTax( totalIncome,  foodExpenses,  salaryExpenses);
            return totalIncome - foodExpenses - salaryExpenses;
        }

        public static double CalculateTax(double netIncomeBeforeTax, double profitTaxPercent)
        {
            Validator.ValidateAndThrowsCalculateTax( netIncomeBeforeTax,  profitTaxPercent);
            if ((netIncomeBeforeTax * (profitTaxPercent / 100)) >= 0)
                return netIncomeBeforeTax * (profitTaxPercent / 100);
            return 0;
        }

        public static double CalculateNetIncomeAfterTax(double netIncomeBeforeTax, double tax)
        {
            Validator.ValidateAndThrowsCalculateNetIncomeAfterTax( netIncomeBeforeTax,  tax);
            return netIncomeBeforeTax - tax;
        }
    }

    public class RestaurantParameters
    {
        public int Days { get; set; }
        public int Tables { get; set; }
        public double Occupancy { get; set; }
        public double AverageCheck { get; set; }
        public double FoodCostPercent { get; set; }
        public double ProfitTaxPercent { get; set; }
        public int StaffCount { get; set; }
        public double AverageSalary { get; set; }
    }
}