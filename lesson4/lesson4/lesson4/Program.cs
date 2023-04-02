

namespace lesson4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter myCounter = new Counter();
            Handle1 myHadnle1 = new Handle1();
            Handle2 myHadnle2 = new Handle2();

            myCounter.Ready77 += myHadnle1.DisplayPrint;
            myCounter.Ready77 += myHadnle2.DisplayPrint;

            myCounter.Count100();
        }
    }
}
