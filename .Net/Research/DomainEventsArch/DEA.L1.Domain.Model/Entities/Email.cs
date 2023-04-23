namespace DEA.L1.Domain.Model.Entities;

public class Email : Observable
{
    public string To { get; set; }
    public string From { get; set; }
    public string Subjct { get; set; }
    public string Body { get; set; }
}
