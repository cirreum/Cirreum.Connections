namespace Cirreum.Connections;

/// <summary>
/// Ambient accessor for the current <see cref="IRealtimeInvocation"/>.
/// Returns <c>null</c> outside an active invocation scope.
/// </summary>
public interface IRealtimeInvocationAccessor {

	/// <summary>Gets the current invocation, or <c>null</c> if none is active.</summary>
	IRealtimeInvocation? Invocation { get; }

	/// <summary>Set the ambient invocation for the current async flow.</summary>
	void SetInvocation(IRealtimeInvocation invocation);

	/// <summary>Clear the ambient invocation for the current async flow.</summary>
	void ClearInvocation();

}
