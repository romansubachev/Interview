namespace DocumentManagementEx.Entity;

public class Document
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public byte[] Data { get; set; }
    public DateTime UploadDate { get; set; }
    
    public int UserId { get; set; }
}