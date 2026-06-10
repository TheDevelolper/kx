/// <summary>
/// Represents a request with a generic data payload.
/// This class can be used to encapsulate the data being sent in a request, allowing for flexibility in the type of data being transmitted.
/// </summary>
/// <typeparam name="T">
/// The type of the data payload for the request.
/// </typeparam>
public class Request<T>
{
    public T? Data { get; set; }
}
