# Unity MonoSingleton

This Unity base class provides a robust implementation of the Singleton pattern for MonoBehaviour-derived components. It
ensures that only one instance of the component exists in the scene and that it persists across scene loads.

## Features

- **Singleton Pattern**: Ensures that only one instance of the component exists in the scene.
- **Auto-Initialization**: Automatically creates an instance if none exists.
- **DontDestroyOnLoad**: Keeps the instance alive across scene loads.

## Installation

### Option 1: Install via Unity Package Manager

1. Open Unity and go to `Window` > `Package Manager`.
2. Click the `+` button in the top-left corner.
3. Select `Add package from git URL...`.
4. Enter the following URL:```https://github.com/RimuruDev/MonoSingleton.git```

5. Click `Add` to install the package.

### Option 2: Install via Release Package

1. Download the latest `.unitypackage` file from the [Releases](https://github.com/RimuruDev/MonoSingleton/releases)
   page.
2. In Unity, go to `Assets` > `Import Package` > `Custom Package...`.
3. Select the downloaded `.unitypackage` file and import it into your project.

## Usage

1. Create a new class that inherits from `MonoSingleton<T>`, where `T` is the type of the inheriting class.
2. Implement your custom logic in this class.

Example:

```csharp
using UnityEngine;

namespace YourNamespace
{
    public class GameManager : MonoSingleton<GameManager>
    {
        protected override void Awake()
        {
            base.Awake();
            // Your initialization code here :D
        }
        
        // Your custom methods here ;3
    }
}
```

This will ensure that `GameManager` behaves as a singleton within your project, with a single instance that persists
across scene loads.

## Contact

- **Email**: [rimuru.dev@gmail.com](mailto:rimuru.dev@gmail.com)
- **GitHub**: [RimuruDev](https://github.com/RimuruDev)
- **LinkedIn**: [rimuru](https://www.linkedin.com/in/rimuru/)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---