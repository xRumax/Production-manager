using EndLand.Transfer.ProjectsDir.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.ProjectsDir.Commands
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
