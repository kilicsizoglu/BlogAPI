namespace BlogAPI;

public class APIKey
{
    public Guid Key;
    public Guid UserId;
    
    public APIKey(Guid Key, Guid UserId ) {
        this.Key = Key;
        this.UserId = UserId;
    }
}
