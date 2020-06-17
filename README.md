# Daily Desktop Background

A small .NET Core (3.1) application that changes your desktop wallpaper to a random image from [Unsplash](https://unsplash.com/), using their free API to get a random photo found when searching for "desktop background".
[Magick.NET](https://github.com/dlemstra/Magick.NET) is used to download the images from Unsplash and convert them to the BMP format.
This application only works on Windows (tested on Windows 10 64-bit, may work without any issues on Windows 7 and beyond) since setting a wallpaper on Windows requires to interact with the registry.

## The Unsplash API

Unsplash requires you to authorize when using their API, which means you need to register your application. In their API guidelines (as of June 2020), it says that applications "cannot replicate the core user experience of Unsplash (unofficial clients, **wallpaper applications**, etc.)" (emphasis mine). In an email I was told that this does apply to this particular project, but I could use it for personal use anyway (meaning "Demo" app classification and a limit of 50 requests/hour).
This unfortunately means that you will need to get your own access key, which you can do so [here](https://unsplash.com/developers) (it's free), and build this project yourself if you want to use it.

## Building the project

First, open `DailyDesktopBackground/.access-key` and replace the placeholder text there with your Unsplash API acess key. Make sure that nothing else is in that file.

To build the project, a simple `dotnet build` in the root folder of the project should do it. Make sure to have a .NET Core SDK installed that supports .NET Core 2.2.
If you want to compile the application into an executable, go for `dotnet publish -c Release -r $platform` where platform is the platform you want to target, e.g. `win10-x64`.

