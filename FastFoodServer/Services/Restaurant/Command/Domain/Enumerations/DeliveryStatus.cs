using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enumerations
{
    public class DeliveryStatus : SmartEnum<DeliveryStatus>
    {
        private DeliveryStatus(string name, int value)
            : base(name, value) { }

        public static readonly DeliveryStatus Pendding = new PenddingStatus();
        public static readonly DeliveryStatus Reject = new RejectStatus();
        public static readonly DeliveryStatus Cancel = new CancelStatus();
        public static readonly DeliveryStatus Accepted = new AcceptStatus();
        public static readonly DeliveryStatus Require = new RequireStatus();
        public static readonly DeliveryStatus Transport = new TransportStatus();
        public static readonly DeliveryStatus Complete = new CompleteStatus();

        public static implicit operator DeliveryStatus(string name)
            => FromName(name);

        public static implicit operator DeliveryStatus(int value)
            => FromValue(value);

        public static implicit operator string(DeliveryStatus status)
            => status.Name;

        public static implicit operator int(DeliveryStatus status)
            => status.Value;

        public class PenddingStatus : DeliveryStatus
        {
            public PenddingStatus()
                : base(nameof(Pendding), 0) { }
        }

        public class RejectStatus : DeliveryStatus
        {
            public RejectStatus()
                : base(nameof(Reject), 1) { }
        }

        public class AcceptStatus : DeliveryStatus
        {
            public AcceptStatus()
                : base(nameof(Accepted), 2) { }
        }

        public class TransportStatus : DeliveryStatus
        {
            public TransportStatus()
                : base(nameof(Transport), 3) { }
        }

        public class CompleteStatus : DeliveryStatus
        {
            public CompleteStatus()
                : base(nameof(Complete), 4) { }
        }

        public class CancelStatus : DeliveryStatus
        {
            public CancelStatus()
                : base(nameof(Cancel), 5) { }
        }

        public class RequireStatus : DeliveryStatus
        {
            public RequireStatus()
                : base(nameof(Require), 6) { }
        }
    }
}
