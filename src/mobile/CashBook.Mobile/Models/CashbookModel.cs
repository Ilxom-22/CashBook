namespace CashBook.Mobile.Models;

public class CashbookModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedTime { get; set; }
    public DateTime? ModifiedTime { get; set; }
    public decimal Balance { get; set; } = 0;
    
    public string LastUpdatedText
    {
        get
        {
            var lastUpdate = ModifiedTime ?? CreatedTime;
            var timeSpan = DateTime.Now - lastUpdate;
            
            if (timeSpan.TotalMinutes < 1)
                return "just now";
            else if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} minute{((int)timeSpan.TotalMinutes == 1 ? "" : "s")} ago";
            else if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} hour{((int)timeSpan.TotalHours == 1 ? "" : "s")} ago";
            else if (timeSpan.TotalDays < 30)
                return $"{(int)timeSpan.TotalDays} day{((int)timeSpan.TotalDays == 1 ? "" : "s")} ago";
            else if (timeSpan.TotalDays < 365)
                return $"{(int)(timeSpan.TotalDays / 30)} month{((int)(timeSpan.TotalDays / 30) == 1 ? "" : "s")} ago";
            else
                return lastUpdate.ToString("MMM dd yyyy");
        }
    }
} 