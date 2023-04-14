using System;
public class Program
{
    public static string binary(string numeric)
    {
        string result = "";
        string resForDouble = "";
        bool flag = false;
        int number1 = 0;
        double number2 = 0.0;
        int temp;
        double tempForDouble;
        if (numeric.IndexOf('.') != -1)
        {
            flag = true;
            number2 = double.Parse(numeric);
        }
        else number1 = int.Parse(numeric);

        if (flag == false)
        {
            int copyNum1 = number1;
            while (copyNum1 != 0)
            {
                temp = copyNum1 % 2;
                copyNum1 = copyNum1 / 2;
                result = result.Insert(0, temp.ToString());
            }
        }
        else if (flag == true)
        {
            int copyNum1 = (int)number2;
            double copyNum2 = number2 - copyNum1;
            int tempForInt;

            while (copyNum1 != 0)
            {
                temp = copyNum1 % 2;
                copyNum1 = copyNum1 / 2;
                result = result.Insert(0, temp.ToString());
            }
            int index = 0;
            while (index != 5)
            {
                tempForDouble = copyNum2 * 2;
                tempForInt = (int)tempForDouble % 2;
                copyNum2 = tempForDouble;
                resForDouble = resForDouble.Insert(resForDouble.Length, tempForInt.ToString());
                index++;
            }

        }
        return result + "," + resForDouble;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Введіть ціле або дробове число для переведення у двійкову систему: ");
        string entered, allowable = "0123456789,.";
        entered = Console.ReadLine();
        if (entered.StartsWith("+") || entered.StartsWith("-"))
        {
            entered = entered.Substring(1);
            Console.WriteLine("Введені символи без першого знака: " + entered);
        }
        if (entered.IndexOf(',') != -1)
        {
            int x = entered.IndexOf(',');
            entered = entered.Remove(entered.IndexOf(','), 1);
            entered = entered.Insert(x, ".");
        }

        int k = 0;
        for (int i = 0; i < entered.Length; i++)
        {
            if (allowable.IndexOf(entered[i]) == -1)
            {
                k = 1;
                Console.WriteLine("Ви ввели некоректні символи! ");
                break;
            }
        }
        if (k == 0)
        {
            Console.WriteLine("Число у двійковій системі:");
            Console.WriteLine(binary(entered));
        }

    }
}