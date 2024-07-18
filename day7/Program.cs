namespace day7
{
    public class BMICalculator<T> where T : struct

    {
        public T height;
        public T weight;
        private Stack<double> bmihistory = new();


        public double CalculatoBmi(T height, T weight, bool IsMetric)
        {
            double heightInaMeters;
            double WeightInKg;
            if (IsMetric)
            {
                heightInaMeters = Convert.ToDouble(height);
                WeightInKg = Convert.ToDouble(weight);
            }
            else
            {
                heightInaMeters = Convert.ToDouble(height) * 0.3048;
                WeightInKg = Convert.ToDouble(weight) * 0.453592;
            }
            double bmi = WeightInKg / (heightInaMeters * heightInaMeters);
            bmihistory.Push(bmi);
            return (bmi);
        }
        public string GetBMICategory(double bmi)
        {
            if (bmi < 18.5) return "Underweight";
            else if (bmi <= 24.9) return "Normal weight";
            else if (bmi <= 29.9) return "Overweight";
            else if (bmi >= 30) return "Obesity";
            return GetBMICategory(bmi);

        }
        public void DisplayHistory()
        {
            Console.WriteLine("bmi calculation history: ");
            foreach (var entity in bmihistory)
            {

                Console.WriteLine(entity);
            }

        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            BMICalculator<double> bmicalculator = new BMICalculator<double>();
            while (true)
            {

                Console.Write("Enter height (in meters or feet): ");
                double height = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter weight (in kg or pounds): ");
                double weight = Convert.ToDouble(Console.ReadLine());

                Console.Write("Is the input in metric units? (yes/no): ");
                bool isMetric = Console.ReadLine().ToLower() == "yes";

                double bmi = bmicalculator.CalculatoBmi(height, weight, isMetric);


                string category = bmicalculator.GetBMICategory(bmi);

                Console.WriteLine($"BMI: {bmi}, Category: {category}");

                Console.Write("Do you want to view previous BMI calculations history? (yes/no): ");
                string viewHistory = Console.ReadLine().ToLower();
                if (viewHistory == "yes")
                {
                    bmicalculator.DisplayHistory();
                }

                Console.Write("Do you want to calculate another BMI? (yes/no): ");
                string calculateAgain = Console.ReadLine().ToLower();

                if (calculateAgain != "yes")
                {
                    break;
                }

            }
        }
    }
}