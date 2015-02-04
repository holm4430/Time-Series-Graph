/*Name: Kevin Holmes
 * Description: Contains a bunch of technical analysis functions
 * Version 1.1
 * Date: February 3, 2015
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDL
{
    //class containing technical analysis methods for array of closing prices
    static class TechnicalAnalysis
    {
        public static double[] SMA(int period, double[] closeprices)
        {
            Array.Reverse(closeprices);
            double runningtotal;
            double[] arrSMA = new double[closeprices.Length - period];
            //create array of SMA
            for (int i = period; i <= closeprices.Length - 1; i++)
            {   runningtotal = 0;
                //loop through prices and get old prices
                for (int k = i - period; k <= i-1; k++)
                {
                    runningtotal = runningtotal + closeprices[k];

                }
                //calcuate SMA for time period
                arrSMA[i - period] = runningtotal / period;
            }
            //change back array
            Array.Reverse(closeprices);
            Array.Reverse(arrSMA);
            return arrSMA;
        }

        public static double[] EMA(int period,double[] closeprices)
        {
            Array.Reverse(closeprices);
  
            double expPer = 2.0 / (period + 1);
            double[] arrEMA = new double[closeprices.Length - 1];
            //create array of EMA
            arrEMA[0] = closeprices[0];
            for (int i =  1; i < closeprices.Length - 1; i++)
            {
               
                //calcuate EMA for time period
                arrEMA[i] = expPer*(closeprices[i]) + arrEMA[i - 1]*(1.0-expPer);
            }
            //change back array
            Array.Reverse(closeprices);
            Array.Reverse(arrEMA);
            return arrEMA;

        }

        //calculated MACD for time series of closing prices
        public static Tuple<double[],double[]> MACD(double[] closeprices)
        {   double[] arr12dayEMA = EMA(12,closeprices);
            double[] arr26dayEMA = EMA(26,closeprices);
            
            double[] arrMACD = new double[arr12dayEMA.Length];

         
            for (int i = 0; i < arr12dayEMA.Length - 1; i++)
            {
                arrMACD[i] = arr12dayEMA[i] - arr26dayEMA[i];
            }
            double[] arr9dayCross = EMA(9, arrMACD);

            return new Tuple<double[], double[]>(arr9dayCross, arrMACD);
           
        }

        //calculates runnind standard deviation for time series of closing prices
        public static double[] BOLL(double[] closeprices)
        {
            const int bollper = 20;
            double[] std = new double[closeprices.Length - bollper];
            for (int i = bollper; i <= closeprices.Length - 1; i++)
            {
                std[i - bollper] = stddv(closeprices.Skip(i - bollper).Take(bollper).ToArray());

            }

            return std;
        }

        //calculuate standard deviation of an array of doubles
        private static double stddv(double[] numbers)
        {
            double total = 0;
            double standarddv;
            double avg = numbers.Average();
            foreach (double val in numbers)
            {
                total = total + (val - avg) * (val - avg);

            }
            total = total / numbers.Length;
            standarddv = Math.Sqrt(total);
            return standarddv;
        }
     
    }
}
