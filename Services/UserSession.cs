namespace BitFlipBlazor.Services;

public class UserSession
{
    public int Uid { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public bool IsAuthenticated => Uid > 0;

    public void SetUser(int uid, string name, string role)
    {
        Uid = uid;
        Name = name;
        Role = role;
    }

    public void Clear()
    {
        Uid = 0;
        Name = string.Empty;
        Role = string.Empty;
    }
}