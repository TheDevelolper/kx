# Kx

## Getting Started

### Install the template

**Via VS Code task:**
Run `Tasks: Run Task` → **Install Project**

**Manually:**
```sh
dotnet new install ./templates/kx-starter --force
```

## Uninstall the template

**Via VS Code task:**
Run `Tasks: Run Task` → **Uninstall Project**

**Manually:**
```sh
dotnet new uninstall ./templates/kx-starter
```

After installing, create a new project

```sh
dotnet new kx-starter -n ExampleProject
```

Or from a directory:

```sh
mkdir ExampleProject
cd ExampleProject
dotnet new kx-starter
```
