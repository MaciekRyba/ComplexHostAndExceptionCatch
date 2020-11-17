using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.ComplexCalculatorService;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string hostName = "BasicHttpBinding_ComplexServices";

        private async void bAddDouble_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComplexServicesClient ComplexCalc = new ComplexServicesClient(hostName);
                var ComplexType = new ComplexType();

                ComplexType = await ComplexCalc.AddFourValueAsync(double.Parse(tFirstReal.Text),
                    double.Parse(tSecondReal.Text), double.Parse(tFirstImaginary.Text), double.Parse(tSecondImaginary.Text));

                lResult.Content = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();
            }
            catch (FaultException<CustomExceptionDetails> ex)
            {
                tError.Text = "Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Details;
            }
            catch (FaultException ex)
            {
                tResult.Text = ex.Message;
            }

        }

        private void bSubDouble_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ComplexCalc = new ComplexServicesClient(hostName);
                var ComplexType = new ComplexType();

                ComplexType = ComplexCalc.SubtractFourValue(double.Parse(tFirstReal.Text),
                    double.Parse(tSecondReal.Text), double.Parse(tFirstImaginary.Text), double.Parse(tSecondImaginary.Text));
                lResult.Content = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();

            }
            catch (FaultException<CustomExceptionDetails> ex)
            {
                tError.Text = "Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Details;
            }
            catch (FaultException ex)
            {
                tResult.Text = ex.Message;
            }

        }

        private void bMultipyDouble_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ComplexCalc = new ComplexServicesClient(hostName);
                var ComplexType = new ComplexType();

                ComplexType = ComplexCalc.MultiplyFourValue(double.Parse(tFirstReal.Text),
                    double.Parse(tSecondReal.Text), double.Parse(tFirstImaginary.Text), double.Parse(tSecondImaginary.Text));
                lResult.Content = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();
            }
            catch (FaultException<CustomExceptionDetails> ex)
            {
                tError.Text = "Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Details;
            }
            catch (FaultException ex)
            {
                tResult.Text = ex.Message;
            }

        }

        private void bDivDouble_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ComplexCalc = new ComplexServicesClient(hostName);
                var ComplexType = new ComplexType();

                ComplexType = ComplexCalc.DivisionFourValue(double.Parse(tFirstReal.Text),
                    double.Parse(tSecondReal.Text), double.Parse(tFirstImaginary.Text), double.Parse(tSecondImaginary.Text));
                lResult.Content = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();

            }
            catch (FaultException<CustomExceptionDetails> ex)
            {
                tError.Text = "Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Details;
            }
            catch (FaultException<DivideByZeroFault> ex)
            {
                tcatchExc.Text = "Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Description;
            }
            catch (FaultException ex)
            {
                tResult.Text = ex.Message;
            }
        }

        private void bAddComplex_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ComplexCalc = new ComplexServicesClient(hostName);
                var FirstComplex = new ComplexType();
                var SecondComplex = new ComplexType();
                var ComplexType = new ComplexType();

                FirstComplex.RealValueOperation = double.Parse(tFirstReal.Text);
                FirstComplex.ImaginryValueOperation = double.Parse(tFirstImaginary.Text);

                SecondComplex.RealValueOperation = double.Parse(tSecondReal.Text);
                SecondComplex.ImaginryValueOperation = double.Parse(tSecondImaginary.Text);


                ComplexType = ComplexCalc.AddTwoValue(FirstComplex, SecondComplex);
                lResult.Content = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();

            }
            catch (FaultException<CustomExceptionDetails> ex)
            {
                tError.Text = "Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Details;
            }
            catch (FaultException ex)
            {
                tResult.Text = ex.Message;
            }
        }

        private void bSubComplex_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ComplexCalc = new ComplexServicesClient(hostName);
                var FirstComplex = new ComplexType();
                var SecondComplex = new ComplexType();
                var ComplexType = new ComplexType();

                FirstComplex.RealValueOperation = double.Parse(tFirstReal.Text);
                FirstComplex.ImaginryValueOperation = double.Parse(tFirstImaginary.Text);

                SecondComplex.RealValueOperation = double.Parse(tSecondReal.Text);
                SecondComplex.ImaginryValueOperation = double.Parse(tSecondImaginary.Text);


                ComplexType = ComplexCalc.SubtractTwoValue(FirstComplex, SecondComplex);
                lResult.Content = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();

            }
            catch (FaultException<CustomExceptionDetails> ex)
            {
                tError.Text = "Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Details;
            }
            catch (FaultException ex)
            {
                tResult.Text = ex.Message;
            }

        }

        private void bMultipyComplex_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ComplexCalc = new ComplexServicesClient(hostName);
                var FirstComplex = new ComplexType();
                var SecondComplex = new ComplexType();
                var ComplexType = new ComplexType();

                FirstComplex.RealValueOperation = double.Parse(tFirstReal.Text);
                FirstComplex.ImaginryValueOperation = double.Parse(tFirstImaginary.Text);

                SecondComplex.RealValueOperation = double.Parse(tSecondReal.Text);
                SecondComplex.ImaginryValueOperation = double.Parse(tSecondImaginary.Text);


                ComplexType = ComplexCalc.MultiplyTwoValue(FirstComplex, SecondComplex);
                lResult.Content = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();
            }
            catch (FaultException<CustomExceptionDetails> ex)
            {
                tError.Text = "Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Details;
            }
            catch (FaultException ex)
            {
                tResult.Text = ex.Message;
            }

        }

        private void bDivComplex_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ComplexCalc = new ComplexServicesClient(hostName);
                var FirstComplex = new ComplexType();
                var SecondComplex = new ComplexType();
                var ComplexType = new ComplexType();

                FirstComplex.RealValueOperation = double.Parse(tFirstReal.Text);
                FirstComplex.ImaginryValueOperation = double.Parse(tFirstImaginary.Text);

                SecondComplex.RealValueOperation = double.Parse(tSecondReal.Text);
                SecondComplex.ImaginryValueOperation = double.Parse(tSecondImaginary.Text);


                ComplexType = ComplexCalc.DivisionTwoValue(FirstComplex, SecondComplex);
                lResult.Content = ComplexType.RealValueOperation.ToString() + " + " + ComplexType.ImaginryValueOperation.ToString();

            }
            catch (FaultException<CustomExceptionDetails> ex)
            {
                tError.Text = "Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Details;
            }
            catch (FaultException<DivideByZeroFault> ex)
            {
                tcatchExc.Text = "Message: " + ex.Detail.Message + "\n Details: " + ex.Detail.Description;
            }
            catch (FaultException ex)
            {
                tResult.Text = ex.Message;
            }

        }

        private void bClear_Click(object sender, RoutedEventArgs e)
        {
            tFirstReal.Text = "0";
            tFirstImaginary.Text = "0";
            tSecondReal.Text = "0";
            tSecondImaginary.Text = "0";

            lResult.Content = "0";
        }

        private void Btn2_Checked(object sender, RoutedEventArgs e)
        {
            hostName = "BasicHttpBinding_ComplexServices";
        }

        private void Btn1_Checked(object sender, RoutedEventArgs e)
        {
            hostName = "NetTcpBinding_ComplexServices";

        }
    }
}
