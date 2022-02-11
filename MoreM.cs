using System;

namespace MoreMath
{
    class Numbers
    {
        float number;
        int 
            piPrecision,
            maxE;
         
        public Numbers(float number)
        {
            this.number = number;
            this.piPrecision = 1000000;
            //PiPrecision = 1000000;
        }

        public double Add(double baseNumber, double numberToAdd)
        {
            return baseNumber + numberToAdd;
        }

        public double Sub(double baseNumber, double numberToSub)
        {
            return baseNumber - numberToSub;
        }

        public double Mul(double baseNumber, double numberToMul)
        {
            return baseNumber * numberToMul;
        }

        public double Div(double baseNumber, double numberToDiv)
        {
            return baseNumber / numberToDiv;
        }

        public double Abs(double number)
        {
            if(number < 0)
            {
                return -number;
            }
            else
            {
                return number;
            }
        }

        public double Pow(double baseNumber, double exposant)
        {
            if (exposant < 0)
            {
                exposant = Abs(exposant);

                double result = 1;
                for (int i = 0; i < exposant; i++)
                {
                    result *= baseNumber;
                }

                return (1 / result);
            }
            else if (exposant == 0)
            {
                return 1;
            }

            else
            {
                double result = 1;
                for (int i = 0; i < exposant; i++)
                {
                    result *= baseNumber;
                }

                return result;
            }
        }

        public int Exp()
        {
            int exponential = Convert.ToInt32(this.number);

            for(int i = 1; i < Convert.ToInt32(this.number); i++)
            {
                exponential = exponential * Convert.ToInt32(this.number - i);
            }

            return exponential;
        }

        public int PiPrecision
        {
            get
            {
                return this.piPrecision;
            }
            set
            {
                Console.Write("Choose a precision number for pi : ");
                this.piPrecision = Convert.ToInt32(Console.ReadLine());
            }
        }
        public double Pi
        {
            get
            {
                double x = 0;

                for(int i = 1; i < PiPrecision; i += 2)
                {
                    if((i - 3) % 4 == 0)
                    {
                        x -= (1.0 / i);
                    }
                    else
                    {
                        x += (1.0 / i);
                    }
                }

                return x * 4;
            }
        }

        public int EPrecision
        {
            get
            {
                return this.maxE;
            }
            set
            {
                Console.Write("Choose a precision number for e : ");
                this.maxE = Convert.ToInt32(Console.ReadLine());
            }
        }

        public double E
        {
            get
            {
                double exp = Pow(1.0 + (1.0 / EPrecision), EPrecision);
                return exp;
            }
        }

        public double sig(double s)
        {
            double sigmoid = 1 / 1 + Pow(E, - s);
            return sigmoid;
        }
    }

    class List
    {
        double[]
            list;

        public List(double[] list)
        {
            this.list = list;
        }

        public void PrintList()
        {
            Console.Write("{");

            for(int i = 0; i < this.list.Length; i++)
            {
                Console.Write(this.list[i]);

                if (i + 1 != this.list.Length)
                {
                    Console.Write(", ");
                }
            }

            Console.Write("}\n");
        }

        public void Reverse()
        {
            double[] reversed = new double[this.list.Length];

            for(int i = 0; i < this.list.Length; i++)
            {
                reversed[i] = this.list[(this.list.Length - 1) - i];
            }

            for (int i = 0; i < this.list.Length; i++)
            {
                this.list[i] = reversed[i];
            }
        }

        public double ListTot()
        {
            double total = 0;

            for(int i = 0; i < this.list.Length; i++)
            {
                total += this.list[i];
            }

            return total;
        }

        public void AddToIndexes(double numberToAdd, int startIndex, int endIndex)
        {
            if(endIndex > this.list.Length - 1 || endIndex < startIndex || startIndex < 0)
            {
                return;
            }

            for (int i = startIndex; i < endIndex + 1; i++)
            {
                this.list[i] += numberToAdd;
            }
        }

        public void SubToIndexes(double numberToSub, int startIndex, int endIndex)
        {
            if(endIndex > this.list.Length - 1 || endIndex < startIndex || startIndex < 0)
            {
                return;
            }

            for (int i = startIndex; i < endIndex + 1; i++)
            {
                this.list[i] -= numberToSub;
            }
        }

        public void MulToIndexes(double numberToMul, int startIndex, int endIndex)
        {
            if(endIndex > this.list.Length - 1 || endIndex < startIndex || startIndex < 0)
            {
                return;
            }

            for (int i = startIndex; i < endIndex + 1; i++)
            {
                this.list[i] *= numberToMul;
            }
        }

        public void DivToIndexes(double numberToDiv, int startIndex, int endIndex)
        {
            if(endIndex > this.list.Length - 1 || endIndex < startIndex || startIndex < 0)
            {
                return;
            }

            for (int i = startIndex; i < endIndex + 1; i++)
            {
                this.list[i] /= numberToDiv;
            }
        }

        public void PowIndexes(double pow, int startIndex, int endIndex)
        {
            if(endIndex > this.list.Length - 1 || endIndex < startIndex || startIndex < 0)
            {
                return;
            }

            Numbers num = new Numbers(1);


            for (int i = startIndex; i < endIndex + 1; i++)
            {
                this.list[i] = num.Pow(this.list[i], pow);
            }
        }

        public void Push(double number)
        {
            double[] temp = new double[this.list.Length];

            for(int i = 0; i < this.list.Length; i++)
            {
                temp[i] = this.list[i];
            }

            this.list = new double[this.list.Length + 1];

            for(int i = 0; i < this.list.Length - 1; i++)
            {
                this.list[i] = temp[i];
            }

            this.list[this.list.Length - 1] = number;
        }

        public void Pop()
        {
            double[] temp = new double[this.list.Length];

            for (int i = 0; i < this.list.Length; i++)
            {
                temp[i] = this.list[i];
            }

            this.list = new double[this.list.Length - 1];

            for (int i = 0; i < this.list.Length; i++)
            {
                this.list[i] = temp[i];
            }
        }

        public void Insert(double number, int index)
        {
            double[] temp1 = new double[index];

            for (int i = 0; i < temp1.Length; i++)
            {
                temp1[i] = this.list[i];
            }

            double[] temp2 = new double[this.list.Length - temp1.Length];

            for (int i = 0; i < temp2.Length; i++)
            {
                temp2[i] = this.list[i+temp1.Length];
            }

            this.list = new double[this.list.Length + 1];

            for (int i = 0; i < temp1.Length; i++)
            {
                this.list[i] = temp1[i];
            }

            this.list[index] = number;

            for(int i = 0; i < temp2.Length; i++)
            {
                this.list[i + temp1.Length + 1] = temp2[i];
            }
        }

        public void Remove(int index)
        {
            double[] temp1 = new double[index];

            for (int i = 0; i < temp1.Length; i++)
            {
                temp1[i] = this.list[i];
            }

            double[] temp2 = new double[this.list.Length - temp1.Length - 1];

            for (int i = 0; i < temp2.Length; i++)
            {
                temp2[i] = this.list[i + temp1.Length + 1];
            }

            this.list = new double[this.list.Length - 1];

            for (int i = 0; i < temp1.Length; i++)
            {
                this.list[i] = temp1[i];
            }

            for (int i = 0; i < temp2.Length; i++)
            {
                this.list[i + temp1.Length] = temp2[i];
            }
        }

        public void Reset()
        {
            this.list = new double[this.list.Length];
        }

        public void FillWith(double number)
        {
            for(int i = 0; i < this.list.Length; i++)
            {
                this.list[i] = number;
            }
        }

        public void Extend(int numberOfIndexesToAdd)
        {
            double[] temp = new double[this.list.Length];

            for(int i = 0; i < this.list.Length; i++)
            {
                temp[i] = this.list[i];
            }

            this.list = new double[this.list.Length + numberOfIndexesToAdd];

            for (int i = 0; i < temp.Length; i++)
            {
                this.list[i] = temp[i];
            }
        }

        public void ExtendWith(int numberOfIndexesToAdd, double value)
        {
            double[] temp = new double[this.list.Length];

            for (int i = 0; i < this.list.Length; i++)
            {
                temp[i] = this.list[i];
            }

            this.list = new double[this.list.Length + numberOfIndexesToAdd];

            for (int i = 0; i < temp.Length; i++)
            {
                this.list[i] = temp[i];
            }

            for(int i = temp.Length; i < this.list.Length; i++)
            {
                this.list[i] = value;
            }
        }

        public void ResetToDim(int length)
        {
            this.list = new double[length];
        }

        public void ResetAndFill(int length, double value)
        {
            this.ResetToDim(length);

            for(int i = 0; i < this.list.Length; i++)
            {
                this.list[i] = value;
            }
        }

        public int[] Find(double value)
        {
            int[] indexesFound;
            int count = 0;
            for(int i = 0; i < this.list.Length; i++)
            {
                if (this.list[i] == value)
                {
                    count++;
                }
            }
            
            indexesFound = new int[count];

            int j = 0;

            for (int i = 0; i < this.list.Length; i++)
            {
                if (this.list[i] == value)
                {
                    indexesFound[j] = i;
                    j++;
                }
            }

            return indexesFound;
        }
    }

    class Functions
    {
        double
            x,
            y;

        public Functions(double x)
        {
            this.x = x;
        }

        public void Constant(double output)
        {
            this.y = output;
        }

        public void Linear(double factor)
        {
            this.y = this.x * factor;
        }

        public void Affin(double factor, double term)
        {
            this.y = this.x * factor + term;
        }

        public void Quad(int degree, double factor, double term)
        {
            Numbers num = new Numbers(0);

            this.y = num.Pow(this.x, degree) * factor + term;
        }
    }

    class Equations
    {
        public class OneOne
        {
            double
                factorOne,
                termOne,
                factorTwo,
                termTwo;

            public OneOne(double factorOne, double termOne, double factorTwo, double termTwo)
            {
                this.factorOne = factorOne;
                this.termOne = termOne;
                this.factorTwo = factorTwo;
                this.termTwo = termTwo;
            }

            public string Canonic()
            {
                double term = this.termOne - this.termTwo;
                term /= factorTwo;
                double factor = this.factorOne - this.factorTwo;

                string Res = Convert.ToString(factor) + "x " + Convert.ToString(term);

                return Res;
            }
        }
    }
}