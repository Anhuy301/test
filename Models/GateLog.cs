namespace Web_Test_DevExpress_ClaudeAI.Models
{
    public class GateLog
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeCode { get; set; } = string.Empty;
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string GateLocation { get; set; } = string.Empty;
        public LogType LogType { get; set; }
        public string? Notes { get; set; }
    }

    public enum LogType
    {
        CheckIn,
        CheckOut
    }
}