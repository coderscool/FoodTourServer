using Ardalis.SmartEnum;

namespace Domain.Enumerations
{
    public class OrderItemStatus : SmartEnum<OrderItemStatus>
    {
        private OrderItemStatus(string name, int value)
            : base(name, value) { }

        public static readonly OrderItemStatus Pendding = new PenddingStatus();
        public static readonly OrderItemStatus Reject = new RejectStatus();
        public static readonly OrderItemStatus Accept = new AcceptStatus();
        public static readonly OrderItemStatus Prepared = new PreparedStatus();
        public static readonly OrderItemStatus Require = new RequireStatus();
        public static readonly OrderItemStatus Transport = new TransportStatus();
        public static readonly OrderItemStatus Complete = new CompleteStatus();

        public static implicit operator OrderItemStatus(string name)
            => FromName(name);

        public static implicit operator OrderItemStatus(int value)
            => FromValue(value);

        public static implicit operator string(OrderItemStatus status)
            => status.Name;

        public static implicit operator int(OrderItemStatus status)
            => status.Value;

        public class PenddingStatus : OrderItemStatus
        {
            public PenddingStatus()
                : base(nameof(Pendding), 0) { }
        }

        public class RejectStatus : OrderItemStatus
        {
            public RejectStatus()
                : base(nameof(Reject), 1) { }
        }

        public class AcceptStatus : OrderItemStatus
        {
            public AcceptStatus()
                : base(nameof(Accept), 2) { }
        }

        public class PreparedStatus : OrderItemStatus
        {
            public PreparedStatus()
                : base(nameof(Accept), 2) { }
        }

        public class RequireStatus : OrderItemStatus
        {
            public RequireStatus()
                : base(nameof(Accept), 2) { }
        }

        public class TransportStatus : OrderItemStatus
        {
            public TransportStatus()
                : base(nameof(Transport), 3) { }
        }

        public class CompleteStatus : OrderItemStatus
        {
            public CompleteStatus()
                : base(nameof(Complete), 4) { }
        }
    }
}
