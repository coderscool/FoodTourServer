using Ardalis.SmartEnum;

namespace Domain.Enumerations
{
    public class PaymentMethod : SmartEnum<PaymentMethod>
    {
        private PaymentMethod(string name, int value)
            : base(name, value) { }

        public static readonly PaymentMethod Empty = new EmptyStatus();
        public static readonly PaymentMethod CreditCard = new CreditCardStatus();
        public static readonly PaymentMethod PayPal = new PayPalStatus();
        public static readonly PaymentMethod PayDirect = new PayDirectStatus();

        public static implicit operator PaymentMethod(string name)
            => FromName(name);

        public static implicit operator PaymentMethod(int value)
            => FromValue(value);

        public static implicit operator string(PaymentMethod status)
            => status.Name;

        public static implicit operator int(PaymentMethod status)
            => status.Value;

        public class EmptyStatus : PaymentMethod
        {
            public EmptyStatus()
                : base(nameof(Empty), 0) { }
        }

        public class CreditCardStatus : PaymentMethod
        {
            public CreditCardStatus()
                : base(nameof(CreditCard), 1) { }
        }

        public class PayPalStatus : PaymentMethod
        {
            public PayPalStatus()
                : base(nameof(PayPal), 2) { }
        }

        public class PayDirectStatus : PaymentMethod
        {
            public PayDirectStatus()
                : base(nameof(PayDirect), 3) { }
        }
    }
}
