using System;

namespace ArtificialNeuron
{
    class Program
    {
        private const decimal Kilometers = 1;

        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Console App 'Convert km using artificial neuron'");
            Console.WriteLine("-----------------------------------------------");

            while (!endApp)
            {
                Console.Write("Enter distance in km, and then press Enter: ");
                string numInput = Console.ReadLine();

                decimal sourceKm;
                while (!decimal.TryParse(numInput, out sourceKm))
                {
                    Console.Write("This is not valid input. Please enter a decimal value: ");
                    numInput = Console.ReadLine();
                }

                Console.WriteLine("Choose a conversion option from the following list:" +
                    "\n\tm - Convert to miles" +
                    "\n\tv - Convert to versts" +
                    "\n\tn - Convert to nautical miles" +
                    "\nYour option? ");

                numInput = Console.ReadLine().ToLower();

                while (numInput != "m" && numInput != "v" && numInput != "n")
                {
                    Console.Write("This is not valid input. Сhoose one of the options 'm', 'v' or 'n': ");
                    numInput = Console.ReadLine();
                }

                if (numInput == "m")
                {
                    ConvertToMiles(sourceKm, Kilometers);
                }
                else if (numInput == "v")
                {
                    ConvertToVersts(sourceKm, Kilometers);
                }
                else if (numInput == "n")
                {
                    ConvertToNauticalMiles(sourceKm, Kilometers);
                }

                Console.WriteLine("-----------------------------------------------\n");
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");

                if (Console.ReadLine().ToLower() == "n")
                {
                    endApp = true;
                }

                Console.WriteLine("\n");
            }
        }

        private static void ConvertToNauticalMiles(decimal sourceKm, decimal Kilometers)
        {
            decimal nauticalMiles = 0.5395m;
            Neuron neuron = new Neuron();
            Console.WriteLine("\nArtificial learning has begun. Please wait...\n");

            int i = 0;
            do
            {
                i++;
                neuron.Train(Kilometers, nauticalMiles);
            }
            while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);
            Console.WriteLine($"Learning completed successfully!\nYour result is {neuron.ProcessInputData(sourceKm):0.00} nautical miles in {sourceKm} kilometers");
        }

        private static void ConvertToVersts(decimal sourceKm, decimal Kilometers)
        {
            decimal versts = 0.9373m;
            Neuron neuron = new Neuron();
            Console.WriteLine("\nArtificial learning has begun. Please wait...\n");

            int i = 0;
            do
            {
                i++;
                neuron.Train(Kilometers, versts);
            }
            while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);
            Console.WriteLine($"Learning completed successfully!\nYour result is {neuron.ProcessInputData(sourceKm):0.00} versts in {sourceKm} kilometers");
        }

        private static void ConvertToMiles(decimal sourceKm, decimal Kilometers)
        {
            decimal miles = 0.6213m;
            Neuron neuron = new Neuron();
            Console.WriteLine("\nArtificial learning has begun. Please wait...\n");

            int i = 0;
            do
            {
                i++;
                neuron.Train(Kilometers, miles);
            }
            while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

            Console.WriteLine($"Learning completed successfully!\nYour result is {neuron.ProcessInputData(sourceKm):0.00} miles in {sourceKm} kilometers");
        }
    }
}
