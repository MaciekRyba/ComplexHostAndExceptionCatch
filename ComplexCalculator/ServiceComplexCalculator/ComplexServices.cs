using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.ComponentModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;

namespace Microsoft.ServiceModel.Samples
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ComplexServices
    {


        [OperationContract(Name = "AddTwoValue")]
        [FaultContract(typeof(CustomExceptionDetails))]
        [FaultContract(typeof(DivideByZeroFault))]
        ComplexType Add(ComplexType FirstComplex, ComplexType SecondComplex);

        [OperationContract(Name = "AddFourValue")]
        ComplexType Add(double real1, double real2, double imaginary1, double imaginary2);


        [OperationContract(Name = "SubtractTwoValue")]
        [FaultContract(typeof(CustomExceptionDetails))]
        [FaultContract(typeof(DivideByZeroFault))]
        ComplexType Subtract(ComplexType FirstComplex, ComplexType SecondComplex);

        [OperationContract(Name = "SubtractFourValue")]
        ComplexType Subtract(double real1, double real2, double imaginary1, double imaginary2);


        [OperationContract(Name = "DivisionTwoValue")]
        [FaultContract(typeof(CustomExceptionDetails))]
        [FaultContract(typeof(DivideByZeroFault))]
        ComplexType Division(ComplexType FirstComplex, ComplexType SecondComplex);

        [OperationContract(Name = "DivisionFourValue")]
        [FaultContract(typeof(CustomExceptionDetails))]
        [FaultContract(typeof(DivideByZeroFault))]
        ComplexType Division(double real1, double real2, double imaginary1, double imaginary2);


        [OperationContract(Name = "MultiplyTwoValue")]
        [FaultContract(typeof(CustomExceptionDetails))]
        [FaultContract(typeof(DivideByZeroFault))]
        ComplexType Multiply(ComplexType FirstComplex, ComplexType SecondComplex);

        [OperationContract(Name = "MultiplyFourValue")]
        [FaultContract(typeof(CustomExceptionDetails))]
        [FaultContract(typeof(DivideByZeroFault))]
        ComplexType Multiply(double real1, double real2, double imaginary1, double imaginary2);


    }


    // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
    [DataContract]
    public class ComplexType
    {
        double RealValue;
        double ImaginaryValue;

        [DataMember]
        public double RealValueOperation
        {
            get { return RealValue; }
            set { RealValue = value; }
        }

        [DataMember]
        public double ImaginryValueOperation
        {
            get { return ImaginaryValue; }
            set { ImaginaryValue = value; }
        }


    }

    public class CalculatorWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public CalculatorWindowsService()
        {
            // Name the Windows Service
            ServiceName = "WCFWindowsServiceSample";
        }

        public static void Main()
        {
            ServiceBase.Run(new CalculatorWindowsService());
        }

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(ComplexCalculatorService));
            serviceHost.Open();
        }



        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }

    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "WCFComplexCalculatorService";
            Installers.Add(process);
            Installers.Add(service);
        }
    }



    [DataContract]
    public class CustomExceptionDetails
    {
        [DataMember]
        public bool Result { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Details { get; set; }
    }

    [DataContract]
    public class DivideByZeroFault
    {
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
