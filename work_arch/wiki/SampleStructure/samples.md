```
WebApi_Pattern1
│  WebApi_Pattern1.sln
│  
├─src
│  ├─XxxxApi
│  │  │  XxxxApi.csproj
│  │  │  
│  │  ├─Domain
│  │  └─etc
│  ├─XxxxHttpService
│  │      XxxxHttpService.csproj
│  │      
│  ├─YyyyApi
│  │  │  YyyyApi.csproj
│  │  │  
│  │  ├─Domain
│  │  └─etc
│  └─YyyyHttpService
│          YyyyHttpService.csproj
│          
└─test
```

```
WebApi_Pattern2
│  WebApi_Pattern1.sln
│  
├─src
│  ├─Xxxx
│  │  ├─XxxxApi
│  │  │  │  XxxxApi.csproj
│  │  │  │  
│  │  │  ├─Domain
│  │  │  └─etc
│  │  └─XxxxHttpService
│  │          XxxxHttpService.csproj
│  │          
│  └─Yyyy
│      ├─YyyyApi
│      │  │  YyyyApi.csproj
│      │  │  
│      │  ├─Domain
│      │  └─etc
│      └─YyyyHttpService
│              YyyyHttpService.csproj
│              
└─test
```

```
WebApi_Pattern3
│  WebApi_Pattern3.sln
│  
├─src
│  ├─HttpServices
│  │  ├─XxxxHttpService
│  │  │      XxxxHttpService.csproj
│  │  │      
│  │  └─YyyyHttpService
│  │          YyyyHttpService.csproj
│  │          
│  └─WebApis
│      ├─XxxxApi
│      │  │  XxxxApi.csproj
│      │  │  
│      │  ├─Domain
│      │  └─etc
│      └─YyyyApi
│          │  YyyyApi.csproj
│          │  
│          ├─Domain
│          └─etc
└─test
```