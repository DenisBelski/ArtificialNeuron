namespace ArtificialNeuron
{
    public class Neuron
    {
        private decimal weight = 0.5m;
        public decimal LastError { get; private set; }
        public decimal Smoothing { get; set; } = 0.000001m;

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
}