[[_TOC_]]

# 概要

利用するパッケージの管理は、NuGetにて行う。  
NuGetはMicrosoftが提供する.NET用パッケージマネージャであり、次のような特徴がある。
- VisualStudioから利用可能。
- パッケージのバージョン管理をサポート。
  - バージョンを指定して更新やダウングレード可能。
- 依存パッケージの管理をサポート。
  - パッケージ取得時に必要な依存パッケージも同時に取得。
- 内製したライブラリを公開可能
  - クラウドやオンプレミスのサーバ上にNuGetパッケージとして配置可能。
  - 公開したライブラリは通常のNuGetパッケージと同様にVisualStudio上で取得可能。

NuGetについての詳細は以下を参照。
- [公式サイト](https://www.nuget.org/)
- [NuGet のドキュメント (Microsoft)](https://docs.microsoft.com/ja-jp/nuget/)

# MVCアプリケーション

| NuGetパッケージ | バージョン |
|-------------------------------------------------------------------------------------------------------------------------|-----------:|
| [Microsoft.AspNetCore.Authentication.JwtBearer](https://github.com/dotnet/aspnetcore/tree/master/src/Security/Authentication/JwtBearer) | 3.1.0 |
| [Microsoft.AspNetCore.Localization](https://github.com/dotnet/aspnetcore/tree/master/src/Localization/Localization) | 2.2.0 |
| [Microsoft.AspNetCore.Mvc.Localization](https://github.com/dotnet/aspnetcore/tree/master/src/Mvc/Mvc.Localization) | 2.2.0 |
| [Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation](https://github.com/dotnet/aspnetcore/tree/master/src/Mvc/Mvc.Razor.RuntimeCompilation) | 3.1.1 |
| [Microsoft.Data.OData](https://github.com/OData/odata.net) | 5.8.4 |
| [Microsoft.Extensions.Logging.Debug](https://github.com/dotnet/extensions/tree/master/src/Logging/Logging.Debug) | 3.1.0 |
| [Microsoft.IdentityModel.Tokens](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/tree/dev/src/Microsoft.IdentityModel.Tokens) | 5.6.0 |
| [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://github.com/aspnet/Scaffolding/tree/master/src/VS.Web.CG.Design) | 3.1.1 |
| [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) | 12.0.3 |
| [NLog](https://github.com/NLog/NLog) | 4.6.8 |
| [NLog.Extensions.AzureTableStorage](https://github.com/abkonsta/NLog.Extensions.AzureTableStorage) | 1.1.4 |
| [NLog.Web.AspNetCore](https://github.com/NLog/NLog.Web/tree/dev/src/NLog.Web.AspNetCore) | 4.9.0 |
| [Portable.BouncyCastle](https://github.com/novotnyllc/bc-csharp) | 1.8.5.2 |
| [ SDKパッケージ ] ||
| [Molis.SDK.Configuration](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FConfiguration) | 1.0.1 |
| [Molis.SDK.EnvironmentVariables](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FEnvironmentVariables) | 1.0.0 |
| [Molis.SDK.Exceptions](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FExceptions) | 1.0.0 |
| [Molis.SDK.Filters](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FFilters) | 1.0.0 |
| [Molis.SDK.Logging](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FLogging) | 1.0.0 |
| [Molis.SDK.Mvc](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FMvc) | 1.0.4 |
| [Molis.SDK.Security](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FSecurity) | 1.0.0 |


# WEB API

| NuGetパッケージ | バージョン |
|-------------------------------------------------------------------------------------------------------------------------|-----------:|
| [Microsoft.AspNetCore.Authentication.JwtBearer](https://github.com/dotnet/aspnetcore/tree/master/src/Security/Authentication/JwtBearer) | 3.1.0 |
| [Microsoft.AspNetCore.Mvc.NewtonsoftJson](https://github.com/dotnet/aspnetcore/tree/master/src/Mvc/Mvc.NewtonsoftJson) | 3.1.0 |
| [Microsoft.Data.OData](https://github.com/OData/odata.net) | 5.8.4 |
| [Microsoft.EntityFrameworkCore](https://github.com/dotnet/efcore/tree/master/src/EFCore) | 3.1.1 |
| [Microsoft.EntityFrameworkCore.Design](https://github.com/dotnet/efcore/tree/master/src/EFCore.Design) | 3.1.1 |
| [Microsoft.EntityFrameworkCore.SqlServer](https://github.com/dotnet/efcore/tree/master/src/EFCore.SqlServer) | 3.1.1 |
| [Microsoft.EntityFrameworkCore.Tools](https://github.com/dotnet/efcore/tree/master/src/EFCore.Tools) | 3.1.1 |
| [Microsoft.Extensions.Logging.Debug](https://github.com/dotnet/extensions/tree/master/src/Logging/Logging.Debug) | 3.1.0 |
| [Microsoft.IdentityModel.Tokens](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/tree/dev/src/Microsoft.IdentityModel.Tokens) | 5.6.0 |
| [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://github.com/aspnet/Scaffolding/tree/master/src/VS.Web.CG.Design) | 3.1.1 |
| [NLog](https://github.com/NLog/NLog) | 4.6.8 |
| [NLog.Extensions.AzureTableStorage](https://github.com/abkonsta/NLog.Extensions.AzureTableStorage) | 1.1.4 |
| [NLog.Web.AspNetCore](https://github.com/NLog/NLog.Web/tree/dev/src/NLog.Web.AspNetCore) | 4.9.0 |
| [NSwag.AspNetCore](https://github.com/RicoSuter/NSwag/tree/master/src/NSwag.AspNetCore) | 13.2.0 |
| [Portable.BouncyCastle](https://github.com/novotnyllc/bc-csharp) | 1.8.5.2 |
| [System.IdentityModel.Tokens.Jwt](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet) | 5.6.0 |
| [:red_circle: Microsoft.AspNetCore.Localization](https://github.com/dotnet/aspnetcore/tree/master/src/Localization/Localization) | 2.2.0 |
| [:red_circle: Microsoft.AspNetCore.Mvc.Localization](https://github.com/dotnet/aspnetcore/tree/master/src/Mvc/Mvc.Localization) | 2.2.0 |
| [ SDKパッケージ ] ||
| [Molis.SDK.Configuration](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FConfiguration) | 1.0.1 |
| [Molis.SDK.EnvironmentVariables](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FEnvironmentVariables) | 1.0.0 |
| [Molis.SDK.Exceptions](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FExceptions) | 1.0.0 |
| [:red_circle: Molis.SDK.Filters](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FFilters) | 1.0.0 |
| [Molis.SDK.Logging](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FLogging) | 1.0.0 |
| [Molis.SDK.Mvc](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FMvc) | 1.0.4 |
| [Molis.SDK.Security](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FSecurity) | 1.0.0 |


# WEB APIクライアント

| NuGetパッケージ | バージョン |
|-------------------------------------------------------------------------------------------------------------------------|-----------:|
| [Microsoft.Extensions.Options](https://github.com/dotnet/extensions/tree/master/src/Options/Options) | 3.1.0 |
| [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) | 12.0.3 |
| [NSwag.MSBuild](https://github.com/RicoSuter/NSwag/tree/master/src/NSwag.MSBuild) | 13.2.0 |
| [ SDKパッケージ ] ||
| [Molis.SDK.Http](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_git/Molis.SDK?path=%2Fsrc%2FHttp) | 1.0.0 |


# Molis.SDK

![SDKコンポーネント図.uml.png](/.attachments/SDKコンポーネント図.uml-e15021a7-11f9-4b46-a5de-50dc61d9944a.png)

## Molis.SDK.Acount

| NuGetパッケージ | バージョン |
|-------------------------------------------------------------------------------------------------------------------------|-----------:|
| [System.IdentityModel.Tokens.Jwt](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet) | 5.6.0 |

## Molis.SDK.Configuration

| NuGetパッケージ | バージョン |
|------------------------------------------------------|-----------:|
| [Microsoft.AspNetCore.Authentication](https://github.com/dotnet/aspnetcore/tree/master/src/Security/Authentication/Core) | 2.2.0 |
| [Microsoft.AspNetCore.Authentication.JwtBearer](https://github.com/dotnet/aspnetcore/tree/master/src/Security/Authentication/JwtBearer) | 3.1.0 |
| [Microsoft.Extensions.DependencyInjection](https://github.com/dotnet/extensions/tree/master/src/DependencyInjection) | 3.1.0 |
| [Microsoft.Extensions.Options.ConfigurationExtensions](https://github.com/dotnet/extensions/tree/master/src/Options/ConfigurationExtensions) | 3.1.0 |
| [NLog](https://github.com/NLog/NLog) | 4.6.8 |
| [NLog.Web.AspNetCore](https://github.com/NLog/NLog.Web/tree/dev/src/NLog.Web.AspNetCore) | 4.9.0 |

## Molis.SDK.EnvironmentVariables

| NuGetパッケージ | バージョン |
|------------------------------------------------------|-----------:|
| [Microsoft.Extensions.Configuration](https://github.com/dotnet/extensions/tree/master/src/Configuration) | 3.1.0 |
| [Microsoft.Extensions.Configuration.Abstractions](https://github.com/dotnet/extensions/tree/master/src/Configuration/Config.Abstractions) | 3.1.0 |
| [Microsoft.Extensions.Configuration.FileExtensions](https://github.com/dotnet/extensions/tree/master/src/Configuration/Config.FileExtensions) | 3.1.0 |
| [Microsoft.Extensions.Configuration.Json](https://github.com/dotnet/extensions/tree/master/src/Configuration/Config.Json) | 3.1.0 |

## Molis.SDK.Exceptions

| NuGetパッケージ | バージョン |
|-----------|-----------:|
| なし | なし |

## Molis.SDK.Filters

| NuGetパッケージ | バージョン |
|------------------------------------------------------|-----------:|
| [Microsoft.AspNetCore.Mvc.Abstractions](https://github.com/dotnet/aspnetcore/tree/master/src/Mvc/Mvc.Abstractions) | 2.2.0 |
| [Microsoft.Extensions.Logging.Abstractions](https://github.com/dotnet/extensions/tree/master/src/Logging/Logging.Abstractions) | 3.1.0 |

## Molis.SDK.Http

| NuGetパッケージ | バージョン |
|------------------------------------------------------|-----------:|
| [Microsoft.AspNetCore.Http.Abstractions](https://github.com/dotnet/aspnetcore/tree/master/src/Http/Authentication.Abstractions) | 2.2.0 |
| [Microsoft.Extensions.Options](https://github.com/dotnet/extensions/tree/master/src/Options/Options) | 3.1.0 |

## Molis.SDK.Logging

| NuGetパッケージ | バージョン |
|------------------------------------------------------|-----------:|
| [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) | 12.0.3 |
| [NLog](https://github.com/NLog/NLog) | 4.6.8 |
| [NLog.Web.AspNetCore](https://github.com/NLog/NLog.Web/tree/dev/src/NLog.Web.AspNetCore) | 4.9.0 |

## Molis.SDK.Mvc

| NuGetパッケージ | バージョン |
|------------------------------------------------------|-----------:|
| [Microsoft.AspNetCore.Authentication.Cookies](https://github.com/dotnet/aspnetcore/tree/master/src/Security/Authentication/Cookies) | 2.2.0 |
| [Microsoft.AspNetCore.Mvc.Abstractions](https://github.com/dotnet/aspnetcore/tree/master/src/Mvc/Mvc.Abstractions) | 2.2.0 |
| [Microsoft.AspNetCore.Mvc.ViewFeatures](https://github.com/dotnet/aspnetcore/tree/master/src/Mvc/Mvc.ViewFeatures) | 2.2.0 |
| [System.IdentityModel.Tokens.Jwt](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet) | 5.6.0 |

## Molis.SDK.Security

| NuGetパッケージ | バージョン |
|------------------------------------------------------|-----------:|
| [Microsoft.IdentityModel.Tokens](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/tree/dev/src/Microsoft.IdentityModel.Tokens) | 5.6.0 |
| [Portable.BouncyCastle](https://github.com/novotnyllc/bc-csharp) | 1.8.5.2 |