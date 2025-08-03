using Ardalis.SmartEnum;

namespace Domain.Enumerations
{
    public class OrderGroupStatus : SmartEnum<OrderGroupStatus>
    {
        private OrderGroupStatus(string name, int value)
            : base(name, value) { }

        public static readonly OrderGroupStatus Pendding = new PenddingStatus();
        public static readonly OrderGroupStatus Reject = new RejectStatus();
        public static readonly OrderGroupStatus Accept = new AcceptStatus();
        public static readonly OrderGroupStatus Prepared = new PreparedStatus();
        public static readonly OrderGroupStatus Require = new RequireStatus();
        public static readonly OrderGroupStatus Transport = new TransportStatus();
        public static readonly OrderGroupStatus Complete = new CompleteStatus();

        public static implicit operator OrderGroupStatus(string name)
            => FromName(name);

        public static implicit operator OrderGroupStatus(int value)
            => FromValue(value);

        public static implicit operator string(OrderGroupStatus status)
            => status.Name;

        public static implicit operator int(OrderGroupStatus status)
            => status.Value;

        public class PenddingStatus : OrderGroupStatus
        {
            public PenddingStatus()
                : base(nameof(Pendding), 0) { }
        }

        public class RejectStatus : OrderGroupStatus
        {
            public RejectStatus()
                : base(nameof(Reject), 1) { }
        }

        public class AcceptStatus : OrderGroupStatus
        {
            public AcceptStatus()
                : base(nameof(Accept), 2) { }
        }

        public class PreparedStatus : OrderGroupStatus
        {
            public PreparedStatus()
                : base(nameof(Prepared), 2) { }
        }

        public class RequireStatus : OrderGroupStatus
        {
            public RequireStatus()
                : base(nameof(Require), 2) { }
        }

        public class TransportStatus : OrderGroupStatus
        {
            public TransportStatus()
                : base(nameof(Transport), 3) { }
        }

        public class CompleteStatus : OrderGroupStatus
        {
            public CompleteStatus()
                : base(nameof(Complete), 4) { }
        }
    }
}
