using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Core.Enums
{
    public enum CustomErrorCode
    {
        DatabaseError = 400,
        ArgumentError = 401,
        UnexpectedError = 402,
        ProjectWithIncidentsOrProducedDevices = 403,
        ProjectNotFound = 404,
        RobotDeviceNotFound = 405,
        RobotWaterMeterNotFound = 406,
        RobotConfigurationNotFound = 407,
        RobotCartonsInitialNotFound = 408,
        RobotCartonsFinishNotFound = 409,
        ReportNotFound = 410,
        ReportWithIncidents = 411,
        UserNotFound = 412
    }
}
