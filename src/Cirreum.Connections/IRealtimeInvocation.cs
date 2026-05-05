namespace Cirreum.Connections;

/// <summary>
/// Per-message-invocation state. A fresh instance is created by the transport adapter
/// for each inbound message; cleared when the dispatch completes.
/// </summary>
public interface IRealtimeInvocation {

	/// <summary>The connection this invocation belongs to.</summary>
	IRealtimeConnection Connection { get; }

	/// <summary>Per-invocation bag — the <c>HttpContext.Items</c> analog at message scope.</summary>
	IDictionary<object, object?> Items { get; }

	/// <summary>The DI scope created by the transport adapter for this invocation.</summary>
	IServiceProvider Services { get; }

	/// <summary>Cancellation tied to the invocation's lifetime.</summary>
	CancellationToken Aborted { get; }

}
