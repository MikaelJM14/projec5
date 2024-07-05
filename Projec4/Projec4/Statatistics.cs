using System.Threading.Tasks;

namespace Projec4
{
    public class Statatistics
    {
        public double First;
        public double Last;
        public double Total;
        public int Counted;

        public Statatistics()
        {
            Counted = 0;
            Total = 0.0;
            First = double.MinValue;
            Last = double.MaxValue;
        }

        public double Ave
        {
            get
            {
                return Total / Counted;
            }
        }

        public void Add(double value)
        {
            Total += value;
            Counted+=1;
            Last = Math.Min(value, Last);
            First = Math.Max(value, First);
        }
    }
}
