# Release Notes — Cirreum.Connections v1.0.0

Initial release of the server-side abstractions for long-lived Cirreum connections.

## What's in this release

This package defines the foundational primitives that transport adapters (SignalR, WebSockets) build on:

- **Two-scope model** — `IRealtimeConnection` (per-connection lifetime) and `IRealtimeInvocation` (per-message lifetime) with separate `Items` dictionaries, mirroring the `HttpContext` pattern but split across two distinct lifetimes.
- **Ambient accessors** — `IRealtimeConnectionAccessor` and `IRealtimeInvocationAccessor` with AsyncLocal-backed default implementations. Read-only getter on the interface; explicit `SetConnection`/`ClearConnection` and `SetInvocation`/`ClearInvocation` methods for transport adapters.
- **Identity lifecycle hook** — `IConnectionAuthLifecycle` for App-side identity resolution at connect/disconnect. Return `false` from `OnConnectedAsync` to reject the connection at upgrade.
- **Server-initiated push** — `IRealtimeOutbound.SendAsync<T>` for fire-and-forget push over the active connection. Multi-producer safe; within a single producer, sends preserve issue order.
- **Well-known keys** — `ConnectionContextKeys` for connection-bag slots (Outbound, AppName, TransportName).

## Design references

- [ADR-0001 — Cirreum.Connections](https://github.com/cirreum/DevOps/blob/main/docs/adr/0001-realtime-connections.md)
- [Implementation Specification](https://github.com/cirreum/DevOps/blob/main/docs/Connections/01-DESIGN.md)
