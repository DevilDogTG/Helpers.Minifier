# Minifier

## Description

This is a simple DMNSN Minifier tool. It allows you to shorten long content to make your logs more concise and readable.

## Features

- Shortens long content to single lines
- Improves logs readability
- Easy to use

## Installation

### Method 1: Clone Source Code and Use as Project Reference

1. Clone this repository:

```bash
git clone https://github.com/DevilDogTG/Helpers.Minifier.git
```

2. Open the project in Visual Studio and add it as a reference to your solution.

### Method 2: Install Package via NuGet

1. Open your project in Visual Studio.
2. Open the NuGet Package Manager Console.
3. Run the following command to install the package:

```cmd
nuget install DMNSN.Helpers.Minifier
```

## Usage

1. using `DMNSN.Helpers.Minifier` namespace in your code
2. Use the `MinifyHelper` static class to minify content:

```csharp
string html = "<html>\n<head>\n<title>Test HTML</title>\n</head>\n<body>\n<h1>Hello, World!</h1>\n</body>\n</html>";
string minifiedHtml = MinifyHelper.MinifyHtml(html);
```

## Contributing

Contributions are welcome! If you have any ideas, suggestions, or bug reports, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.
