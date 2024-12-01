# Safe Area

![Unity](https://img.shields.io/badge/Unity-000000?logo=unity)
[![Package](https://img.shields.io/github/v/release/hadrienestela/com.hadrienestela.ui.safe-area?label=latest&logo=npm)](https://github.com/hadrienestela/com.hadrienestela.ui.safe-area/pkgs/npm/com.hadrienestela.ui.safe-area)
[![Documentation](https://img.shields.io/github/deployments/hadrienestela/com.hadrienestela.ui.safe-area/github-pages?label=documentation)](https://hadrienestela.github.io/com.hadrienestela.ui.safe-area)

## About

The `com.hadrienestela.ui.safe-area` package provides component that adapts rectTransform to the safe area constraints.

## Installation

### Scoped registry

Open the `Project Settings -> Package Manager` window then add the registry definition to the `Scoped Registries` section.

```
"name": "GitHub - hadrienestela",
"url": "https://npm.pkg.github.com/@hadrienestela",
"scopes": [
    "com.hadrienestela.ui.safe-area"
]
```

### Package dependency

Open the `Package Manager` window then click the `+` icon and select `install package by name`.

```
"com.hadrienestela.ui.safe-area"
```

### Registry authentication

Configure authentication information for the registry by adding the following lines to your `~/.upmconfig.toml` file according to the [unity documentation](https://docs.unity3d.com/6000.0/Documentation/Manual/upm-config-scoped.html)

```
[npmAuth."https://npm.pkg.github.com/@hadrienestela"]
token = "<TOKEN>"
alwaysAuth = true
```

