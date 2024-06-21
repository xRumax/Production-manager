
namespace EndLand.Transfer.ReportsDir.Data
{
    public class ReportListDto
    {
        public string Imei { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string ProjectName { get; set; } = null!;

        public string OrderNumber { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string? Ccid { get; set; }

        public string SerialNumber { get; set; } = null!;

        public int FirmwareVersion { get; set; }

        public int Volume { get; set; }

        public int EsiThresholdChannel0 { get; set; }

    
    }

}
