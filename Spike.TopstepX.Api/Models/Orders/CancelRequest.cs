using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spike.TopstepX.Api.Models.Orders
{
    public record CancelRequest
    {
        public int AccountId { get; set; }
        public int OrderId { get; set; }
    }
}
