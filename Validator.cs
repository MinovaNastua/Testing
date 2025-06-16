using ConsoleApp1;
using System;

namespace ConsoleApp1
{
    public static class Validator
    {
        public static void ValidateAndThrowRestaurantParameters(RestaurantParameters parameters)
        {
            ValidateDays(parameters.Days);
            ValidateTables(parameters.Tables);
            ValidateOccupancy(parameters.Occupancy);
            ValidateAverageCheck(parameters.AverageCheck);
            ValidateExpensePercentage(parameters.FoodCostPercent);
            ValidateTaxPercentage(parameters.ProfitTaxPercent);
            ValidateStaffCount(parameters.StaffCount);
            ValidateAverageSalary(parameters.AverageSalary);
        }

        public static void ValidateAndThrowsCalculateTotalIncome(RestaurantParameters parameters)
        {
            ValidateDays(parameters.Days);
            ValidateTables(parameters.Tables);
            ValidateOccupancy(parameters.Occupancy);
            ValidateAverageCheck(parameters.AverageCheck);
            ValidateExpensePercentage(parameters.FoodCostPercent);
            ValidateTaxPercentage(parameters.ProfitTaxPercent);
            ValidateStaffCount(parameters.StaffCount);
            ValidateAverageSalary(parameters.AverageSalary);
        }

        public static void ValidateAndThrowsCalculateFoodExpenses(double totalIncome, double foodCostPercent)
        {
            ValidateExpensePercentage(foodCostPercent);
        }

        public static void ValidateAndThrowsCalculateSalaryExpenses(int staffCount, double averageSalary)
        {
            ValidateAverageSalary(averageSalary);
            ValidateStaffCount(staffCount);
        }

        public static void ValidateAndThrowsCalculateNetIncomeBeforeTax(double totalIncome, double foodExpenses, double salaryExpenses)
        {
            ValidateSalaryExpenses(salaryExpenses);
        }

        public static void ValidateAndThrowsCalculateTax(double netIncomeBeforeTax, double profitTaxPercent)
        {
            ValidateTaxPercentage(profitTaxPercent);
        }

        public static void ValidateAndThrowsCalculateNetIncomeAfterTax(double netIncomeBeforeTax, double tax)
        {
            ValidateTax(tax);
        }

        public static void ValidateTax(double tax)
        {
            if (tax < 0)
                throw new ArgumentException("Налог не может быть отрицательным.");
        }

        public static void ValidateSalaryExpenses(double salaryExpenses)
        {
            if (salaryExpenses < 0)
                throw new ArgumentException("Расходы на зарплату не могут быть отрицательными.");
        }
        private static void ValidateDays(int days)
        {
            if (days < 1 || days > 31)
                throw new ArgumentException("Количество дней должно быть от 1 до 31.");
        }

        private static void ValidateTables(int tables)
        {
            if (tables < 1 || tables > 50)
                throw new ArgumentException("Количество столиков должно быть от 1 до 50.");
        }

        private static void ValidateOccupancy(double occupancy)
        {
            if (occupancy < 0 || occupancy > 100)
                throw new ArgumentException("Заполняемость столиков должна быть от 0 до 100.");
        }

        private static void ValidateAverageCheck(double averageCheck)
        {
            if ( averageCheck > int.MaxValue)
                throw new ArgumentException("Средний чек не может быть больше чем " + int.MaxValue);
            if (averageCheck < 0 || averageCheck > int.MaxValue)
                throw new ArgumentException("Средний чек не может быть отрицательным.");
        }

        private static void ValidateExpensePercentage(double percentage)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException("Процент расходов должен быть от 0 до 100.");
        }

        private static void ValidateTaxPercentage(double percentage)
        {
            if (percentage < 0 || percentage > 30)
                throw new ArgumentException("Процент налога на прибыль должен быть от 0 до 30.");
        }

        private static void ValidateStaffCount(int staffCount)
        {
            if (staffCount < 1 || staffCount > 20)
                throw new ArgumentException("Количество сотрудников должно быть от 1 до 20.");
        }

        private static void ValidateAverageSalary(double salary)
        {
            if (salary < 0 || salary > 100000)
                throw new ArgumentException("Средняя зарплата не может быть отрицательной или превышать 100000.");
        }
    }
}