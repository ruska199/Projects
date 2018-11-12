using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalc
{
    //*********************************************************************************************
    struct Table
    {
        public int months;
        public double loanBalance;
        public double interest;
        public double principalPayment;
        public double alltogether;
        
        //Add this for next commits and easy modifications
        public Table(int m, double lB, double i, double pP, double all)
        {
            months = m;
            loanBalance = lB;
            interest = i;
            principalPayment = pP;
            alltogether = all;
        }
    }
    //*********************************************************************************************
    class Program
    {
        static void Main(string[] args)
        {
            Table t = new Table();
            
            //PAY ATTENTION TO THE PATH
            string writePath = @"D:\\projects\Csharp\karanProjects\MortCalc\table.txt";
            
                //try to input data for calculating an annuity mortgage loan
            //*********************************************************************************************
            Console.Write("Enter mortgage loan amount      >> ");
            while(!double.TryParse(Console.ReadLine(), out t.loanBalance) || t.loanBalance <= 0)
            {
                Console.Write("It must be double number greater than 0, try again >>  ");
            }

            Console.Write("Enter the number of months      >> ");
            while(!int.TryParse(Console.ReadLine(), out t.months) || t.months <= 0)
            {
                Console.Write("It must be int number greater than 0, try again   >>  ");
            }

            Console.Write("Enter the ann. interest rate(%) >> ");
            while(!double.TryParse(Console.ReadLine(), out t.interest) || t.interest <= 0)
            {
                Console.Write("It must be double number greater than 0, try again >>  ");
            }
            
            //*********************************************************************************************
            try
            {
                //convert interest in 0.00 format
                double intrst = (t.interest / 100) / 12;
                //calculate annuity mortgage month payment
                t.principalPayment = t.loanBalance * (intrst * Math.Pow(1 + intrst, t.months)) / (Math.Pow(1 + intrst, t.months) - 1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //*********************************************************************************************
            //Add Table array to make easy writing details in the file.txt
            Table[] tOut = new Table[t.months];
            tOut[tOut.Length - 1].months = t.months;
            
            //*********************************************************************************************
            try
            {
                tOut[0].months = 1;
                tOut[0].principalPayment = t.principalPayment - (t.loanBalance * (t.interest / 100) / 12);
                tOut[0].interest = t.loanBalance * (t.interest / 100) / 12;
                tOut[0].loanBalance = t.loanBalance;
                tOut[0].alltogether = tOut[0].interest + tOut[0].principalPayment;
                for (int i = 1; i < tOut.Length; i++)
                {

                    tOut[i].months = tOut[tOut.Length - 1].months - (tOut[tOut.Length - 1].months - i) + 1;
                    tOut[i].loanBalance = tOut[i - 1].loanBalance - tOut[i - 1].principalPayment;
                    tOut[i].interest = tOut[i].loanBalance * (t.interest / 100) / 12;
                    tOut[i].principalPayment = t.principalPayment - tOut[i].interest;
                    tOut[i].alltogether = tOut[i].interest + tOut[i].principalPayment;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //*********************************************************************************************
            try
            { 
                double totalLoan = t.principalPayment * t.months - t.loanBalance;
                using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.UTF8))
                {
                    sw.WriteLine("Here is below detailed information about annuity mortgage loan:");
                    sw.Write("Loan amount:   ");
                    sw.Write("{0:0.00}", t.loanBalance);
                    sw.WriteLine();
                    sw.Write("Term:            ");
                    sw.Write(t.months);
                    sw.WriteLine();
                    sw.Write("Annual interest:           ");
                    sw.Write(t.interest);
                    sw.WriteLine();
                    sw.Write("Total loan overpayment: ");
                    sw.Write("{0:0.00}", totalLoan);
                    sw.Write("Payment per day:  ");
                    sw.Write("{0:0.00}", t.principalPayment/30);
                    sw.Write("Payment per week:  ");
                    sw.Write("{0:0.00}", t.principalPayment/4);
                    sw.WriteLine();
                    sw.WriteLine();
                    sw.WriteLine();
                    sw.WriteLine("|(1) Month |  (2) Loan balance |    (3) Interest |(4) Principal payment |(5) Alltogether |");
                    for (int i = 0; i < tOut.Length; i++)
                    {
                        sw.Write("(1):  ");
                        string m = String.Format("{0:0.00}", tOut[i].months);
                        sw.Write("{0,2}", m);
                        sw.Write("       (2):  ");
                        string lB = String.Format("{0:0.00}", tOut[i].loanBalance);
                        sw.Write("{0,2}", lB);
                        sw.Write("       (3):  ");
                        string intrst = String.Format("{0:0.00}", tOut[i].interest);
                        sw.Write("{0,2}", intrst);
                        sw.Write("       (4):  ");
                        string pP = String.Format("{0:0.00}", tOut[i].principalPayment);
                        sw.Write("{0,2}", pP);
                        sw.Write("       (5):  ");
                        string all = String.Format("{0:0.00}", tOut[i].alltogether);
                        sw.Write("{0,2}", all);
                        sw.WriteLine();
                    }
                    sw.WriteLine("!!! PAY ATTENTION !!!");
                    sw.WriteLine("A loan with an annuity repayment scheme will always be more expensive for the borrower");
                } 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            //*********************************************************************************************
            try
            {
                using (StreamReader sr = new StreamReader(writePath, Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //*********************************************************************************************
            Console.ReadKey();
        }
    }
}
