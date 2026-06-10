/// <summary>
/// Represents a result with a generic data payload.
/// This class can be used to encapsulate the data being returned in a result, along with
/// any additional information about the result.
/// </summary>
/// <typeparam name="T">
/// The type of the data payload for the result.
/// </typeparam>
public record Result<T>(
    T? Data = default,
    string? Message = null,
    bool Success = true
);
