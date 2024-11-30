
public class BaseException : Exception
{
    public string Message { get; set; }
    public int? Code { get; set; }
}
