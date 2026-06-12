using PaymentShippingAPI.Data;
using PaymentShippingAPI.Model;

namespace PaymentShippingAPI.Service
{
    public class ServiceB
    {
            private readonly RepData userR = new RepData();
            public string Reguser(InfoM user)
            {
                if (string.IsNullOrWhiteSpace(user.fName))
                    return "First name is required.";
                if (string.IsNullOrWhiteSpace(user.lName))
                    return "Last name is required.";

                userR.saveUser(user);
                return $"Welcome, {user.fName} {user.lName}!";
            }
        }
        public class Payservice
        {
            private readonly Orderrepo orderR = new Orderrepo();
            public string Processpay(payinfo payment)
            {
                if (payment.method == "Credit Card")
                {
                    if (payment.cardNumber.Length != 16)
                        return "Card number must be 16 digits.";
                    if (string.IsNullOrWhiteSpace(payment.cardHolder))
                        return "Card Holder required.";
                }

                if (payment.method == "Gcash")
                {
                    if (string.IsNullOrWhiteSpace(payment.phoneNumber))
                        return "Phone number required.";
                }
                if (payment.method == "PayMaya")
                {
                    if (string.IsNullOrWhiteSpace(payment.phoneNumber))
                        return "Phone number required.";
                }
                if (payment.method == "PayPal")
                {
                    if (string.IsNullOrWhiteSpace(payment.email))
                        return "Email required.";
                    if (string.IsNullOrWhiteSpace(payment.cardNumber))
                        return "Card number must be 16 digits.";
                    if (string.IsNullOrWhiteSpace(payment.cardHolder))
                        return "Card Holder required.";
                }
                orderR.savePay(payment);
                return " >> Successful! Thank you.";
            }
        }

        public class Shipservice
        {
            private readonly shippingpath shiprepo = new shippingpath();
            public string Processship(shipinfo shipping)
            {
                if (string.IsNullOrWhiteSpace(shipping.address))
                    return "Address is required.";
                if (string.IsNullOrWhiteSpace(shipping.contactnum))
                    return "Contact number is required.";

                shiprepo.saveShip(shipping);
                return " >> Shipping information saved!";
            }

        }
    }



