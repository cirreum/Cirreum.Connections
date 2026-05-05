# Cirreum.Connections

[![NuGet Version](https://img.shields.io/nuget/v/Cirreum.Connections.svg?style=flat-square&labelColor=1F1F1F&color=003D8F)](https://www.nuget.org/packages/Cirreum.Connections/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Cirreum.Connections.svg?style=flat-square&labelColor=1F1F1F&color=003D8F)](https://www.nuget.org/packages/Cirreum.Connections/)
[![GitHub Release](https://img.shields.io/github/v/release/cirreum/Cirreum.Connections?style=flat-square&labelColor=1F1F1F&color=FF3B2E)](https://github.com/cirreum/Cirreum.Connections/releases)
[![License](https://img.shields.io/github/license/cirreum/Cirreum.Connections?style=flat-square&labelColor=1F1F1F&color=F2F2F2)](https://github.com/cirreum/Cirreum.Connections/blob/main/LICENSE)
[![.NET](https://img.shields.io/badge/.NET-10.0-003D8F?style=flat-square&labelColor=1F1F1F)](https://dotnet.microsoft.com/)

**Server-side abstractions for long-lived Cirreum connections**

## Overview

**Cirreum.Connections** defines the foundational abstractions for managing long-lived bidirectional connections (SignalR, WebSockets) in the Cirreum framework. It provides the two-scope model (per-connection + per-invocation), identity lifecycle hooks, and the server-initiated push primitive that transport adapters build on.

This package is transport-agnostic. For concrete transport implementations, install a runtime extension:

- `Cirreum.Runtime.Connections.SignalR` — SignalR transport
- `Cirreum.Runtime.Connections.WebSockets` — raw WebSocket transport
- `Cirreum.Runtime.Connections` — both transports

## Key Abstractions

| Type | Purpose |
|---|---|
| `IRealtimeConnection` | Per-connection state: `ConnectionId`, `User`, `Items`, `ConnectedAtUtc`, `Transport` |
| `IRealtimeInvocation` | Per-message state: `Connection`, `Items`, `Services` (DI scope), `Aborted` |
| `IRealtimeConnectionAccessor` | AsyncLocal-backed ambient accessor for the current connection |
| `IRealtimeInvocationAccessor` | AsyncLocal-backed ambient accessor for the current invocation |
| `IConnectionAuthLifecycle` | App-side hook for identity resolution at connect/disconnect |
| `IRealtimeOutbound` | Server-initiated fire-and-forget push over the active connection |
| `ConnectionContextKeys` | Well-known `Items` dictionary keys for connection-bag slots |

## Two-Scope Model

Long-lived connections operate at two distinct scopes simultaneously:

- **Per-connection** — lifetime from upgrade through disconnect. Holds cached identity (`ClaimsPrincipal`), `IUserState`, and connection-stable state in `Items`.
- **Per-invocation** — lifetime of a single inbound message. Fresh DI scope per message, correlation IDs, audit context in `Items`. Prevents state leaking across messages.

## Documentation

- [Architecture Decision Record](https://github.com/cirreum/DevOps/blob/main/docs/adr/0001-realtime-connections.md)
- [Changelog](docs/CHANGELOG.md)

## Contribution Guidelines

1. **Be conservative with new abstractions**  
   The API surface must remain stable and meaningful.

2. **Limit dependency expansion**  
   Only add foundational, version-stable dependencies.

3. **Favor additive, non-breaking changes**  
   Breaking changes ripple through the entire ecosystem.

4. **Include thorough unit tests**  
   All primitives and patterns should be independently testable.

5. **Document architectural decisions**  
   Context and reasoning should be clear for future maintainers.

6. **Follow .NET conventions**  
   Use established patterns from Microsoft.Extensions.* libraries.

## Versioning

Cirreum.Connections follows [Semantic Versioning](https://semver.org/):

- **Major** - Breaking API changes
- **Minor** - New features, backward compatible
- **Patch** - Bug fixes, backward compatible

Given its foundational role, major version bumps are rare and carefully considered.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

**Cirreum Foundation Framework**  
*Layered simplicity for modern .NET*
