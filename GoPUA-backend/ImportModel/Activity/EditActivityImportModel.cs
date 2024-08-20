namespace backend.ImportModel;

public class EditActivityImportModel
{
    public int Id { get; set; }
    public string name { get; set; }
    public string place { get; set; }
    public string type { get; set; }
    public DateTime? startSale { get; set; }
    public DateTime? endSale { get; set; }
    public DateTime? startAct { get; set; }
    public DateTime? endAct { get; set; }
    public DateTime? startTime { get; set; }
    public DateTime? endTime { get; set; }
    public string content { get; set; }
    public string hoster { get; set; }
    public IFormFile? areaImg { get; set; }
    public List<int>? ticket_Id { get; set; }
    public List<int>? ticketList { get; set; }

}