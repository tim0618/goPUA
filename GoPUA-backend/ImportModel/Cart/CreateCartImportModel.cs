namespace backend.ImportModel;

public class CreateCartImportModel
{
    public int Id { get; set; }
    public int user_Id { get; set; }
    public List<int> orderList { get; set; }

}