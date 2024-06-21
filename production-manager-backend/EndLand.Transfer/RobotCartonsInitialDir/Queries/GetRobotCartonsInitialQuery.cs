using EndLand.Transfer.RobotCartonsInitialDir.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotCartonsInitialDir.Queries
{
    public class GetRobotCartonsInitialQuery : IRequest<RobotCartonsInitialDto>
    {
        public int Id { get; set; }
    }
}
