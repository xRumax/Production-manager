using System;
namespace EndLand.Transfer.RobotWaterMeterDir.Data
{
	public class RobotWaterMeterDto
	{
        public int Id { get; set; }

        public int IdCartonInitial { get; set; }

        public int IdCartonFinish { get; set; }

        public string SerialNumber { get; set; } = null!;

        public string Purpose { get; set; } = null!;

        public int Dn { get; set; }

        public double Q3 { get; set; }

        public int YearLegalization { get; set; }

        public int YearSecondaryLegalization { get; set; }

        public double PixelCount { get; set; }

        public bool TestResult { get; set; }

        public double? PixelCount2 { get; set; }

        public string? Owner { get; set; }
    }
}

