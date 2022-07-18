using System;

namespace ArtificialNeuron
{
    class Program
    {
        public class Neuron
        {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }
            public decimal Smoothing { get; set; } = 0.00001m;

            public decimal ProcessInputData(decimal input)
            {
                return weight * input;
            }

            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }

            public void Train(decimal input, decimal expectedResult)
            {
                var actualResult = input * weight;
                LastError = expectedResult - actualResult;
                var correction = (LastError / actualResult) * Smoothing;
                weight += correction;
            }
        }

        static void Main(string[] args)
        {
            decimal kilometers = 100;
            decimal miles = 62.1371m;

            Neuron neuron = new Neuron();

            int i = 0;
            do
            {
                i++;
                neuron.Train(kilometers, miles);
                //Console.WriteLine($"Iterations {i}\tError:\t{neuron.LastError}");
            } 
            while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

            Console.WriteLine("Learning completed");

            Console.WriteLine($"{neuron.ProcessInputData(100)} miles in {100} kilometers");
            Console.WriteLine($"{neuron.ProcessInputData(541)} miles in {541} kilometers");
            Console.WriteLine($"{neuron.RestoreInputData(10)} kilometers in {10} miles");
        }
    }
}
