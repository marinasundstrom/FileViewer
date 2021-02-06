# File Viewer

Simulated file viewer / File hierarchy visualizer in Blazor in WebAssembly.

For exercise details, check EXERCISE.md.

## How it works

The first time the app is running, it loads the initial data consisting of file paths.
Then, the app creates a graph of nodes representing directories and files.

The nodes can be viewed and manipulated in the interface, by adding and removing child items.

There is a tree view displaying the hierarchy of directories.

When viewing directories, there are two Display Modes: List and Grid. The Grid mode is currently incomplete.

## Screenshots

<img src="/Screenshots/Screenshot1.png" />

<img src="/Screenshots/Screenshot2.png" />

<img src="/Screenshots/Screenshot3.png" />

## Requirements
* .NET Core 3.1 - for Blazor
* Node.JS - for compiling and bundling of assets

## To be improved
* UI - Theme, Layout and such
* Components - Make better components
* Naming
* Unit Tests


## App Data

The initial data is loaded from the files.json file the first time the app is running.
It is then stored in the browser's Local Storage, which is where all the changes made in the app will be saved.

To reset the app, simply clear the "paths" post in Local Storage. That will reload the the data original data.

The manipulated data also contains folder paths.

We assume that all files must have a file extension (e.g. .txt).
