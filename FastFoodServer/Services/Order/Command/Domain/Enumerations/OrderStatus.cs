using Ardalis.SmartEnum;

namespace Domain.Enumerations
{
    public class OrderStatus : SmartEnum<OrderStatus>
    {
        private OrderStatus(string name, int value)
            : base(name, value) { }

        public static readonly OrderStatus Pendding = new PenddingStatus();
        public static readonly OrderStatus Reject = new RejectStatus();
        public static readonly OrderStatus Cancel = new CancelStatus();
        public static readonly OrderStatus Accepted = new AcceptStatus();
        public static readonly OrderStatus Prepared = new PreparedStatus();
        public static readonly OrderStatus Transport = new TransportStatus();
        public static readonly OrderStatus Complete = new CompleteStatus();

        public static implicit operator OrderStatus(string name)
            => FromName(name);

        public static implicit operator OrderStatus(int value)
            => FromValue(value);

        public static implicit operator string(OrderStatus status)
            => status.Name;

        public static implicit operator int(OrderStatus status)
            => status.Value;

        public class PenddingStatus : OrderStatus
        {
            public PenddingStatus()
                : base(nameof(Pendding), 0) { }
        }

        public class RejectStatus : OrderStatus
        {
            public RejectStatus()
                : base(nameof(Reject), 1) { }
        }

        public class AcceptStatus : OrderStatus
        {
            public AcceptStatus()
                : base(nameof(Accepted), 2) { }
        }

        public class TransportStatus : OrderStatus
        {
            public TransportStatus()
                : base(nameof(Transport), 3) { }
        }

        public class CompleteStatus : OrderStatus
        {
            public CompleteStatus()
                : base(nameof(Complete), 4) { }
        }

        public class CancelStatus : OrderStatus
        {
            public CancelStatus()
                : base(nameof(Cancel), 5) { }
        }

        public class PreparedStatus : OrderStatus
        {
            public PreparedStatus()
                : base(nameof(Prepared), 6) { }
        }
    }
}
