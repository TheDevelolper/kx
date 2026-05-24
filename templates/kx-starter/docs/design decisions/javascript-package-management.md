# JavaScript Package Management

## Why pnpm?

pnpm uses a single content-addressable store shared across all projects on the machine. A given version of a package is only ever downloaded once, regardless of how many projects depend on it.

**Examples:**
- multiple projects using the same version of a package share a single copy on disk
- switching branches that change dependencies rarely requires fresh downloads
- CI pipelines benefit from shared caches across builds


---

### Hoisted Dependencies for Centralised Management

We enable hoisting via `shamefully-hoist=true` to create a flat `node_modules` at the workspace root. This keeps all dependencies centralised and in sync across every package in the workspace.

**Examples:**
- updating a shared dependency in one place prevents packages from drifting apart on older versions
- security patches applied once cover all packages in the workspace
- tooling that assumes hoisted `node_modules` works without extra configuration

Goal:
"All packages share the same dependency versions; update once, apply everywhere."

---

### Built-in Workspace Support

pnpm has first-class monorepo support via `pnpm-workspace.yaml` with no extra tools like Lerna or Nx required.

**Examples:**
- automatic linking of workspace packages with the `workspace:` protocol
- scoped commands (`pnpm --filter <package> add ...`)
- shared lockfile across all workspace packages
- dependency graph awareness for build ordering

Goal:
"Manage monorepos without additional tooling."

---

### Performance

pnpm is consistently faster than npm for installs, especially in CI and monorepo scenarios, due to its efficient store and parallelisation.

**Examples:**
- CI installs benefit from the store cache across builds
- parallel package resolution and linking
- incremental installs are significantly faster

Goal:
"Minimise time spent waiting for package installs."

---

### Security

pnpm validates package integrity via checksums and its content-addressable store, even with hoisting enabled. Combined with centralised version management, this reduces the risk of outdated or compromised dependencies persisting across the workspace.

**Examples:**
- tampered packages are detected via checksums before linking
- centralised management ensures security patches reach every package
- prevents dependency confusion attacks

Goal:
"Keep dependencies verified and up to date, even with a flat node_modules."

---

## Trade-offs

### Loss of Strict Isolation

Hoisting means packages can access undeclared transitive dependencies at runtime, reintroducing the phantom dependency problem that pnpm's default strict mode prevents.

**Mitigations:**
- regularly audit dependencies with tools like `depcheck`
- use ESLint rules to flag undeclared imports
- run `pnpm ls --depth=0` per package to verify declared dependencies

Goal:
"Accept the convenience of hoisting while remaining disciplined about explicit declarations."
