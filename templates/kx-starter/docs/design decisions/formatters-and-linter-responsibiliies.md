# Tool Responsibilities

## EditorConfig

Provides universal editor-level formatting and whitespace consistency across different IDEs and editors.

Examples:

- indentation style
- indentation size
- line endings
- trailing whitespace
- final newlines

Goal:
"Ensure all editors behave consistently."

Notes:
We leave basic indentation responsibilities to EditorConfig because it is editor-agnostic and widely supported across development tools.

---

## Prettier

Handles code formatting and visual layout.

Examples:

- wrapping
- quotes
- semicolons
- trailing commas
- object/array formatting

Goal:
"Make the code look consistent."

Notes:
Prettier should focus on code formatting rather than editor behaviour.

---

## ESLint

Provides fast feedback while coding and enforces source-level rules.

Examples:

- unused variables
- unsafe TypeScript usage
- React hook mistakes
- circular dependencies
- forbidden imports
- module boundary rules

Goal:
"Prevent problematic code and local architectural violations."

---

## Architectural Tests

Protect the overall system design and validate higher-level architectural boundaries.

Examples:

- domain cannot reference infrastructure
- enforce clean architecture layers
- dependency direction rules
- module/package constraints
- transitive dependency validation

Goal:
"Ensure the overall system architecture remains correct over time."

---

# Mental Model

EditorConfig:
"Ensure editors behave consistently."

Prettier:
"Make the code look clean."

ESLint:
"Don't write problematic code."

Architectural Tests:
"Does the whole system still obey the intended design?"
