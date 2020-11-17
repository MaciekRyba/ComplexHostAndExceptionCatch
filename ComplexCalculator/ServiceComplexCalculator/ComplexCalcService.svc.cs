using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Microsoft.ServiceModel.Samples
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ComplexCalculatorService : ComplexServices
    {
        public ComplexType Add(ComplexType FirstComplex, ComplexType SecondComplex)
        {
            return add_method(FirstComplex.RealValueOperation, SecondComplex.RealValueOperation, FirstComplex.ImaginryValueOperation, SecondComplex.ImaginryValueOperation);

        }

        public ComplexType Division(ComplexType FirstComplex, ComplexType SecondComplex)
        {
            return division_method(FirstComplex.RealValueOperation, SecondComplex.RealValueOperation, FirstComplex.ImaginryValueOperation, SecondComplex.ImaginryValueOperation);

        }

        public ComplexType Division(double real1, double real2, double imaginary1, double imaginary2)
        {
            return division_method(real1, real2, imaginary1, imaginary2);

        }

        public ComplexType Multiply(ComplexType FirstComplex, ComplexType SecondComplex)
        {
            return multiply_method(FirstComplex.RealValueOperation, SecondComplex.RealValueOperation, FirstComplex.ImaginryValueOperation, SecondComplex.ImaginryValueOperation);

        }

        public ComplexType Multiply(double real1, double real2, double imaginary1, double imaginary2)
        {

            return multiply_method(real1, real2, imaginary1, imaginary2);

        }

        public ComplexType Subtract(ComplexType FirstComplex, ComplexType SecondComplex)
        {
            return subtract_method(FirstComplex.RealValueOperation, SecondComplex.RealValueOperation, FirstComplex.ImaginryValueOperation, SecondComplex.ImaginryValueOperation);

        }

        public ComplexType Subtract(double real1, double real2, double imaginary1, double imaginary2)
        {
            return subtract_method(real1, real2, imaginary1, imaginary2);

        }

        ComplexType ComplexServices.Add(double real1, double real2, double imaginary1, double imaginary2)
        {
            return add_method(real1, real2, imaginary1, imaginary2);

        }


        private ComplexType subtract_method(double real1, double real2, double imaginary1, double imaginary2)
        {
            ComplexType ResultValue = new ComplexType();

            ResultValue.RealValueOperation = real1 - real2;
            ResultValue.ImaginryValueOperation = imaginary1 - imaginary2;

            if (real1 == 0 && imaginary1 == 0 && real2 != 0 && imaginary2 != 0)
            {
                var ObjCustom = new CustomExceptionDetails
                {
                    Result = false,
                    Details = @"Pierwsza liczba zespolona ma wartość rzecziwistą i urojoną równą 0 ",
                    Message = "Wartość rzeczywista lub urojona dla pierwszej liczby zespolonej powinna być większa od 0, żeby równanie miało sens"
                };
                throw new FaultException<CustomExceptionDetails>(ObjCustom);
            }
            else if (real2 == 0 && imaginary2 == 0 && real1 != 0 && imaginary1 != 0)
            {
                var ObjCustom = new CustomExceptionDetails
                {
                    Result = false,
                    Details = @"Druga liczba zespolona ma wartość rzecziwistą i urojoną równą 0 ",
                    Message = "Wartość rzeczywista lub urojona dla drugiej liczby zespolonej powinna być większa od 0, żeby równanie miało sens"
                };
                throw new FaultException<CustomExceptionDetails>(ObjCustom);
            }
            else if (real2 == 0 && imaginary2 == 0 && real1 == 0 && imaginary1 == 0)
            {
                var ObjCustom = new CustomExceptionDetails
                {
                    Result = false,
                    Details = @"Wszystkie liczby rzeczywiste oraz urojone mają wartości równe 0 ",
                    Message = "Wartość rzeczywista lub urojona dla obu liczby zespolonych powinny być większe od 0, żeby równanie miało sens"
                };
                throw new FaultException<CustomExceptionDetails>(ObjCustom);


            }
            return ResultValue;

        }

        private ComplexType add_method(double real1, double real2, double imaginary1, double imaginary2)
        {
            ComplexType ResultValue = new ComplexType();

            if (real1 == 0 && imaginary1 == 0 && real2 != 0 && imaginary2 != 0)
            {
                var ObjCustom = new CustomExceptionDetails
                {
                    Result = false,
                    Details = @"Pierwsza liczba zespolona ma wartość rzecziwistą i urojoną równą 0 ",
                    Message = "Wartość rzeczywista lub urojona dla pierwszej liczby zespolonej powinna być większa od 0, żeby równanie miało sens"
                };
                throw new FaultException<CustomExceptionDetails>(ObjCustom);
            }
            else if (real2 == 0 && imaginary2 == 0 && real1 != 0 && imaginary1 != 0)
            {
                var ObjCustom = new CustomExceptionDetails
                {
                    Result = false,
                    Details = @"Druga liczba zespolona ma wartość rzecziwistą i urojoną równą 0 ",
                    Message = "Wartość rzeczywista lub urojona dla drugiej liczby zespolonej powinna być większa od 0, żeby równanie miało sens"
                };
                throw new FaultException<CustomExceptionDetails>(ObjCustom);
            }
            else if (real2 == 0 && imaginary2 == 0 && real1 == 0 && imaginary1 == 0)
            {
                var ObjCustom = new CustomExceptionDetails
                {
                    Result = false,
                    Details = @"Wszystkie liczby rzeczywiste oraz urojone mają wartości równe 0 ",
                    Message = "Wartość rzeczywista lub urojona dla obu liczby zespolonych powinny być większe od 0, żeby równanie miało sens"
                };
                throw new FaultException<CustomExceptionDetails>(ObjCustom);
            }

            ResultValue.RealValueOperation = real1 + real2;
            ResultValue.ImaginryValueOperation = imaginary1 + imaginary2;


            return ResultValue;
        }

        private ComplexType division_method(double real1, double real2, double imaginary1, double imaginary2)
        {
            ComplexType ResultValue = new ComplexType();

            try
            {
                if (real1 == 0 && imaginary1 == 0 && real2 != 0 && imaginary2 != 0)
                {
                    var ObjCustom = new CustomExceptionDetails
                    {
                        Result = false,
                        Details = @"Pierwsza liczba zespolona ma wartość rzecziwistą i urojoną równą 0 ",
                        Message = "Wartość rzeczywista lub urojona dla pierwszej liczby zespolonej powinna być większa od 0, żeby równanie miało sens"
                    };
                    throw new FaultException<CustomExceptionDetails>(ObjCustom);
                }
                else if (real2 == 0 && imaginary2 == 0 && real1 != 0 && imaginary1 != 0)
                {
                    var ObjCustom = new CustomExceptionDetails
                    {
                        Result = false,
                        Details = @"Druga liczba zespolona ma wartość rzecziwistą i urojoną równą 0 ",
                        Message = "Wartość rzeczywista lub urojona dla drugiej liczby zespolonej powinna być większa od 0, żeby równanie miało sens"
                    };
                    throw new FaultException<CustomExceptionDetails>(ObjCustom);
                }
                else if (real2 == 0 && imaginary2 == 0 && real1 == 0 && imaginary1 == 0)
                {
                    var ObjCustom = new CustomExceptionDetails
                    {
                        Result = false,
                        Details = @"Wszystkie liczby rzeczywiste oraz urojone mają wartości równe 0 ",
                        Message = "Wartość rzeczywista lub urojona dla obu liczby zespolonych powinny być większe od 0, żeby równanie miało sens"
                    };
                    throw new FaultException<CustomExceptionDetails>(ObjCustom);
                }
                double divideValue = Math.Pow(real2, 2) - (Math.Pow(imaginary2, 2) * (-1));

                ResultValue.RealValueOperation = ((real1 * real2) + (imaginary1 * imaginary2)) / (Math.Pow(real2, 2) + Math.Pow(imaginary2, 2));
                ResultValue.ImaginryValueOperation = (-(real1 * imaginary2) + (imaginary1 * real2)) / (Math.Pow(real2, 2) + Math.Pow(imaginary2, 2));
                return ResultValue;
            }
            catch (DivideByZeroException e)
            {
                DivideByZeroFault fault = new DivideByZeroFault();

                fault.Result = false;
                fault.Message = e.Message;
                fault.Description = "Cannot divide by zero.";

                throw new FaultException<DivideByZeroFault>(fault);
            }
        }


        private ComplexType multiply_method(double real1, double real2, double imaginary1, double imaginary2)
        {
            ComplexType ResultValue = new ComplexType();

            if (real1 == 0 && imaginary1 == 0 && real2 != 0 && imaginary2 != 0)
            {
                var ObjCustom = new CustomExceptionDetails
                {
                    Result = false,
                    Details = @"Pierwsza liczba zespolona ma wartość rzecziwistą i urojoną równą 0 ",
                    Message = "Wartość rzeczywista lub urojona dla pierwszej liczby zespolonej powinna być większa od 0, żeby równanie miało sens"
                };
                throw new FaultException<CustomExceptionDetails>(ObjCustom);
            }
            else if (real2 == 0 && imaginary2 == 0 && real1 != 0 && imaginary1 != 0)
            {
                var ObjCustom = new CustomExceptionDetails
                {
                    Result = false,
                    Details = @"Druga liczba zespolona ma wartość rzecziwistą i urojoną równą 0 ",
                    Message = "Wartość rzeczywista lub urojona dla drugiej liczby zespolonej powinna być większa od 0, żeby równanie miało sens"
                };
                throw new FaultException<CustomExceptionDetails>(ObjCustom);
            }
            else if (real2 == 0 && imaginary2 == 0 && real1 == 0 && imaginary1 == 0)
            {
                var ObjCustom = new CustomExceptionDetails
                {
                    Result = false,
                    Details = @"Wszystkie liczby rzeczywiste oraz urojone mają wartości równe 0 ",
                    Message = "Wartość rzeczywista lub urojona dla obu liczby zespolonych powinny być większe od 0, żeby równanie miało sens"
                };
                throw new FaultException<CustomExceptionDetails>(ObjCustom);
            }

            ResultValue.RealValueOperation = (real1 * real2) - (imaginary1 * imaginary2);
            ResultValue.ImaginryValueOperation = (real1 * imaginary2) + (imaginary1 * real2);


            return ResultValue;
        }
    }

}
