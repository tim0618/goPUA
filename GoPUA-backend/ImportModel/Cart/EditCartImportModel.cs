namespace backend.ImportModel;

public class EditCartImportModel
{
    public int Id { get; set; }
    public int user_Id { get; set; }
    public List<int> orderList { get; set; }
}