Windows:

```
> dotnet run --project .\Repro21\Repro21.csproj
Chain status:
False
UntrustedRoot

> dotnet run --project .\Repro31\Repro31.csproj
Chain status:
False
UntrustedRoot

> dotnet run --project .\Repro50\Repro50.csproj
Chain status:
False
UntrustedRoot

> dotnet clean
```

Ubuntu:

```
$ sudo dotnet run --project ./Repro21/Repro21.csproj
Chain status:
False
UntrustedRoot

$ sudo dotnet run --project ./Repro31/Repro31.csproj
Chain status:
False
NotSignatureValid
UntrustedRoot

$sudo dotnet run --project ./Repro50/Repro50.csproj
Chain status:
False
NotSignatureValid
UntrustedRoot

$ sudo dotnet clean
```


Steps to install .NET on Ubuntu (https://docs.microsoft.com/sv-se/dotnet/core/install/linux):
```
$ lsb_release -a
No LSB modules are available.
Distributor ID: Ubuntu
Description:    Ubuntu 18.04.2 LTS
Release:        18.04
Codename:       bionic

$ wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
$ sudo dpkg -i packages-microsoft-prod.deb
$ sudo apt-get update
$ sudo apt-get install -y apt-transport-https
$ sudo apt-get update
$ sudo apt-get install -y dotnet-sdk-2.1
$ sudo apt-get install -y dotnet-sdk-3.1
$ sudo apt-get install -y dotnet-sdk-5.0
$ dotnet --list-sdks
2.1.812 [/usr/share/dotnet/sdk]
3.1.405 [/usr/share/dotnet/sdk]
5.0.102 [/usr/share/dotnet/sdk]
```
