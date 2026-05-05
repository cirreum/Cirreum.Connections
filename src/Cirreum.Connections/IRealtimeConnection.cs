namespace Cirreum.Connections;

using System.Security.Claims;

/// <summary>
/// Per-connection state for a long-lived Cirreum connection.
/// Lifetime: connection upgrade through disconnect.
/// </summary>
public interface IRealtimeConnection {

	/// <summary>Unique identifier assigned by the transport adapter at upgrade.</summary>
	string ConnectionId { get; }

	/// <summary>The <see cref="ClaimsPrincipal"/> resolved at upgrade. Immutable for the connection's lifetime.</summary>
	ClaimsPrincipal User { get; }

	/// <summary>UTC timestamp when the connection was established.</summary>
	DateTimeOffset ConnectedAtUtc { get; }

	/// <summary>
	/// Per-connection bag for connection-scoped state (cached <c>IUserState</c>,
	/// <c>AuthenticatedScheme</c>, <c>ApplicationUserCache</c>, and any slot a feature
	/// would put in <c>HttpContext.Items</c> when the lifetime is the whole connection).
	/// </summary>
	IDictionary<object, object?> Items { get; }

	/// <summary>The transport that produced this connection (e.g. "signalr", "websockets"). Diagnostic only.</summary>
	string Transport { get; }

}
