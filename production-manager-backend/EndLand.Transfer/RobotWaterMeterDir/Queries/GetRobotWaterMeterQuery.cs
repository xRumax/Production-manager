using System;
using EndLand.Transfer.RobotWaterMeterDir.Data;
using MediatR;

namespace EndLand.Transfer.RobotWaterMeterDir.Queries
{
	public class GetRobotWaterMeterQuery : IRequest<RobotWaterMeterDto>
	{
		public int Id { get; set; }
	}
}

