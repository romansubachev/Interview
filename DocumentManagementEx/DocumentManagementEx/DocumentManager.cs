using System.Net.Mail;
using DocumentManagementEx.Entity;
using Microsoft.EntityFrameworkCore;

namespace DocumentManagementEx;

public class DocumentManager
{
    private readonly DbContext _dbContext;

    public DocumentManager()
    {
        _dbContext = new DocumentDbContext(new DbContextOptions<DocumentDbContext>());
    }

    public async Task HandleDocument(string filePath, string userEmail)
    {
        byte[] fileData = await File.ReadAllBytesAsync(filePath);
        var document = new Document
        {
            FileName = filePath,
            Data = fileData,
            UploadDate = DateTime.Now
        };
        _dbContext.Add(document);
        await _dbContext.SaveChangesAsync();
        var smtpClient = new SmtpClient("smtp.example.com");
        var mailMessage = new MailMessage("service@test.Com"
            , userEmail
            , "Document Uploaded"
            , "Your document has been uploaded successfully.");
        await smtpClient.SendMailAsync(mailMessage);
    }
}