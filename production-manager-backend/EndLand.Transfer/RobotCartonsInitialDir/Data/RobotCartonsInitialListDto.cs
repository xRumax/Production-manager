using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotCartonsInitialDir.Data
{
    public class RobotCartonsInitialListDto
    {
        public int Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string? Purpose { get; set; }
        public int Dn {  get; set; }
        public int Quantity { get; set; }
        public string? Owner { get; set; }
    }
}
