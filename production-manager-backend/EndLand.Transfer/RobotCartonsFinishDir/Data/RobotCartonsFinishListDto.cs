using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotCartonsFinishDir.Data
{
    public class RobotCartonsFinishListDto
    {
        public int Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Purpose { get; set; } = null!;
        public int Quantity { get; set; }
        public bool TestResult { get; set; }
        public string? Owner { get; set; }
        public bool? FullCarton { get; set; }

    }
}
