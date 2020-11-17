using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using NewConsoleComplex.ComplexCalculatorService;

namespace NewConsoleComplex
{
    class Program
    {
        static void Main(string[] args)
        {
            string sOption = "";

            do
            {

                double firsRealValue = 0; double secondRealValue = 0; double firstImaginaryValue = 0; double secondImaginaryValue = 0;
                var ComplexCalc = new ComplexServicesClient();
                var FirstComplex = new ComplexType();
                var SecondComplex = new ComplexType();
                string result = "";
                var ComplexType = new ComplexType();

                Console.WriteLine("Console Complex Calculator\r");
                Console.WriteLine("------------------------\n");

                Console.WriteLine("Proszę wybrać opcje z listy:\n");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\taC - Complex(Add)");
                Console.WriteLine("\tsC - Complex(Subtract)");
                Console.WriteLine("\tmC - Complex(Multiply)");
                Console.WriteLine("\tdC - Complex(Divide)");
                Console.WriteLine("\tc - czyść console");
                Console.WriteLine("\te - zakończ");
                sOption = Console.ReadLine();

                if (sOption != "c" && sOption != "e")
                {
                    Console.WriteLine("Wpisz pierwszą liczbę rzeczywista");
                    firsRealValue = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Wpisz druga liczbę rzeczywista");
                    secondRealValue = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Wpisz pierwszą liczbę urojona");
                    firstImaginaryValue = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Wpisz druga liczbę urojona");
                    secondImaginaryValue = Convert.ToInt32(Console.ReadLine());
                }
                try
                {
                    switch (sOption)
                    {
                        case "a":

                            ComplexType = ComplexCalc.AddFourValueAsync(firsRealValue, secondRealValue, firstImaginaryValue, secondImaginaryValue).Result;
                            result = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();
                            Console.WriteLine(result);
                            break;
                        case "s":

                            ComplexType = ComplexCalc.SubtractFourValue(firsRealValue, secondRealValue, firstImaginaryValue, secondImaginaryValue);
                            result = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();
                            Console.WriteLine(result);
                            break;
                        case "m":

                            ComplexType = ComplexCalc.MultiplyFourValue(firsRealValue, secondRealValue, firstImaginaryValue, secondImaginaryValue);
                            result = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();
                            Console.WriteLine(result);
                            break;
                        case "d":
                            ComplexType = ComplexCalc.DivisionFourValue(firsRealValue, secondRealValue, firstImaginaryValue, secondImaginaryValue);
                            result = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();
                            Console.WriteLine(result);
                            break;
                        case "aC":
                            FirstComplex.RealValueOperation = firsRealValue;
                            FirstComplex.ImaginryValueOperation = firstImaginaryValue;
                            SecondComplex.RealValueOperation = secondRealValue;
                            SecondComplex.ImaginryValueOperation = secondImaginaryValue;
                            ComplexType = ComplexCalc.AddTwoValue(FirstComplex, SecondComplex);
                            result = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();
                            Console.WriteLine(result);
                            break;
                        case "sC":
                            FirstComplex.RealValueOperation = firsRealValue;
                            FirstComplex.ImaginryValueOperation = firstImaginaryValue;
                            SecondComplex.RealValueOperation = secondRealValue;
                            SecondComplex.ImaginryValueOperation = secondImaginaryValue;
                            ComplexType = ComplexCalc.SubtractTwoValue(FirstComplex, SecondComplex);
                            result = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();
                            Console.WriteLine(result);
                            break;
                        case "mC":
                            FirstComplex.RealValueOperation = firsRealValue;
                            FirstComplex.ImaginryValueOperation = firstImaginaryValue;
                            SecondComplex.RealValueOperation = secondRealValue;
                            SecondComplex.ImaginryValueOperation = secondImaginaryValue;
                            ComplexType = ComplexCalc.MultiplyTwoValue(FirstComplex, SecondComplex);
                            result = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();
                            Console.WriteLine(result);
                            break;
                        case "dC":
                            FirstComplex.RealValueOperation = firsRealValue;
                            FirstComplex.ImaginryValueOperation = firstImaginaryValue;
                            SecondComplex.RealValueOperation = secondRealValue;
                            SecondComplex.ImaginryValueOperation = secondImaginaryValue;
                            ComplexType = ComplexCalc.DivisionTwoValue(FirstComplex, SecondComplex);
                            result = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();
                            Console.WriteLine(result);
                            break;
                        case "c":
                            Console.Clear();
                            break;
                    }
                }
                catch (FaultException<CustomExceptionDetails> ex)
                {
                    Console.WriteLine( "Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Details);
                }
                catch (FaultException<DivideByZeroFault> ex)
                {
                    Console.WriteLine("Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Description);
                }
                catch (FaultException ex)
                {
                    Console.WriteLine( ex.Message);
                }
            } while (sOption != "e");
        }

    }
}
