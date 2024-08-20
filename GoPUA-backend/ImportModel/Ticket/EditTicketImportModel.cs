namespace backend.ImportModel;

public class EditTicketImportModel
{
    public int Id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public DateTime? startTime { get; set; }
    public DateTime? endTime { get; set; }
    public int totalAmount { get; set; }
    public int activity_Id { get; set; }

}