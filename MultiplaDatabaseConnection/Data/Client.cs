namespace MultiplaDatabaseConnection.Data;

public class Client
{
    public Client() { }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ClientSince { get; set; }
    
    private Client(string name, DateTime registerDate)
    {
        Name = name;
        ClientSince = registerDate;
    }

    public Client Create(string name, DateTime registerDate) => new(name, registerDate);
}