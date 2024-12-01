# Getting Started

## Device Simulator

In order to simulate the mobile safe area you need first to install the package [`com.unity.device-simulator.devices`](https://docs.unity3d.com/Packages/com.unity.device-simulator.devices@1.0/manual/index.html).

![Package Manager Install Package](../images/simulator-package.png)

This package will provide a new game window where you can select a mobile device to simulate.

![Device simulator safe area](../images/simulator-safe-area.png)

## Safe Area

Adding the [SafeArea](https://hadrienestela.github.io/com.hadrienestela.ui.safe-area/api/HadrienEstela.UI.SafeArea.SafeArea.html) component to a RectTransform will drive its size to match the parent RectTransform size without leaving the safe area.

![Safe area component](../images/safe-area-inspector.png)
![Safe area scene example](../images/safe-area-scene.png)

## Safe Area Visualizer

The Safe [SafeAreaVisualizer](https://hadrienestela.github.io/com.hadrienestela.ui.safe-area/api/HadrienEstela.UI.SafeArea.SafeAreaVisualizer.html) component draws a safe area overlay for debugging.