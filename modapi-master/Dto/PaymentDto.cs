using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorOnDemand.Dto
{
    public class PaymentDto
    {
        public int id { get; set; }
        public double trainerFees { get; set; }
        public double commision { get; set; }
    }
}
