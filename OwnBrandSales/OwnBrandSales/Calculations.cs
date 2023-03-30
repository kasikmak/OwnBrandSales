namespace OwnBrandSales
{
    public class Calculations
    {
                
        public float NumberSum { get; private set; }

        public float ValueSum { get; private set; }
        
        public float Result
        {
            get
            {
                return this.ValueSum / this.NumberSum;
            }
        }

        public Calculations()
        {
            this.ValueSum = 0;
            this.NumberSum = 0;
        }

        public float Ratio
        {
            get
            {
                switch (this.Result)
                {
                    case var result when result >= 0 && result < 1:
                        return 0.5f;
                    case var result when result >= 1 && result < 1.5:
                        return 0.6f;
                    case var result when result >= 1.5 && result < 2:
                        return 0.7f;
                    case var result when result >= 2 && result < 2.5:
                        return 0.8f;
                    case var result when result >= 2.5 && result < 3:
                        return 0.9f;
                    case var result when result >= 3 && result < 5:
                        return 1f;
                    case var result when result >= 5 && result < 7:
                        return 1.05f;
                    case var result when result >= 7 && result < 9:
                        return 1.1f;
                    case var result when result >= 9 && result < 11:
                        return 1.2f;
                    case var result when result >= 11 && result < 13:
                        return 1.3f;
                    case var result when result >= 13 && result < 16:
                        return 1.4f;
                    case var result when result >= 16:
                        return 1.6f;
                    default:
                        return 0f;
                }
            }
        }

        public void GetNumberSum(float number)
        {
           this.NumberSum += number;
        }

        public void GetValueSum(float value)
        {
            this.ValueSum += value;
        }

        public void GetResult()
        {
            var result = this.Result;
        }
    }     
}