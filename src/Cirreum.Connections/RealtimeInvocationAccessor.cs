namespace Cirreum.Connections;

/// <summary>
/// Default <see cref="AsyncLocal{T}"/>-backed implementation of <see cref="IRealtimeInvocationAccessor"/>.
/// Transport adapters call <see cref="SetInvocation"/> and <see cref="ClearInvocation"/>
/// to manage the ambient scope; consumers read via <see cref="Invocation"/>.
/// </summary>
public sealed class RealtimeInvocationAccessor : IRealtimeInvocationAccessor {

	private static readonly AsyncLocal<IRealtimeInvocation?> _current = new();

	/// <inheritdoc />
	public IRealtimeInvocation? Invocation => _current.Value;

	/// <inheritdoc />
	public void SetInvocation(IRealtimeInvocation invocation) => _current.Value = invocation;

	/// <inheritdoc />
	public void ClearInvocation() => _current.Value = null;

}