[[_TOC_]]

# 概要
## 基本ルール
### フォルダ
- [必須]　:red_circle: ( 推奨??? )
  原則として下記のフォルダ構成に従ってソリューション内のフォルダとファイルを  
  配置すること。独自フォルダの作成は開発者の独断で行わず、レビュアーはじめ  
  チームメンバーと相談すること。
- [推奨] :red_circle: ( 任意??? )
  ソリューション内にプロジェクトが多数ある場合、ソリューションフォルダを作成して
  プロジェクトをグループに分割することが望ましい。
- [必須]
  ソリューションフォルダを作成する際には、対応するパスに同名の物理フォルダを作成し、
  論理的なフォルダ構成と物理的なフォルダ構成に矛盾がないようにしなければならない。
  - ソリューションフォルダはソリューション内における論理フォルダであるため、ソリューションフォルダを
    生成しても実際のフォルダは生成されない。
  - 論理的なフォルダ構成と物理的なフォルダ構成を常に一致させることにより、「ソリューション構成」という
    言葉の意味が曖昧になるのを防ぐ。

### ファイル
:red_circle: 書く


# WEBアプリケーションのフォルダ構成

```
WebApplication
│  (ソリューションのルートフォルダ)
│
│  .gitignore                             [git] 無視ファイル設定
│  WebApplication.sln                     ソリューションファイル
│  README.md                              [Azure] リポジトリの概要説明ファイル
│
├─src
│   │  (ソースコードフォルダ)
│   │
│   WebApplication
│       │  (プロジェクトのルートフォルダ)
│       │
│       │  WebApplication.csproj          プロジェクトファイル
│       │  appsettings.Development.json   設定ファイル (開発用)
│       │  appsettings.json               設定ファイル (デフォルト)
│       │  Program.cs                     プログラムのエントリポイント定義用クラス
│       │  Startup.cs                     アプリケーション起動時の設定用クラス
│       │
│       ├─Abstractions
│       │  │  (抽象化定義)
│       │  │
│       │  └─AppLayer
│       │     (インターフェース定義 - アプリケーション層)
│       │
│       ├─AppLayer
│       │  │  (アプリケーション層の実装)
│       │  │
│       │  ├─Filters
│       │  |  (フィルタ)
│       │  |
│       │  :  (随時、アプリケーション層にて必要な要素を追加、フォルダに分類)
│       │
│       ├─Controllers
│       │  (Webアプリケーション用のMVCコントローラ)
│       │
│       ├─Properties
│       │  │  (VisualStudioのためのプロジェクト設定)
│       │  │
│       │  └─PublishProfiles
│       │     (デプロイ設定)
│       │
│       ├─Resources
│       │  (ローカライズ設定)
│       │
│       ├─ViewModels
│       │  │  (UI表示用データ)
│       │  │
│       │  ├─機能別ビューモデルフォルダ
│       │  :
│       │
│       ├─Views
│       │  │  (Razorテンプレート)
│       │  │
│       │  │  _ViewImports.cshtml         テンプレート内で利用するクラスの参照を宣言するファイル
│       │  │  _ViewStart.cshtml           すべてのビューに共通の準備用コードを定義するファイル
│       │  │
│       │  ├─Shared
│       │  │  |  (共通テンプレート)
│       │  │  │
│       │  │  │    Error.cshtml           エラー画面テンプレート
│       │  │  │    _Layout.cshtml         共通レイアウトのテンプレート
│       │  |  │
│       │  |  ├─機能別共通テンプレートフォルダ
│       │  |  :
│       │  │
│       │  ├─機能別Razorテンプレートフォルダ
│       │  :
│       │
│       │  (以下はフロントエンド向けの静的コンテンツ)
│       └─wwwroot
│           ├─css
│           ├─js
│           └─lib
│               ├─font-awesome
│               ├─vue
│               :
│
└─test
    │  (テストコードフォルダ)
    │
    └─Testing
        │  (テストプロジェクトのルートフォルダ)
        │
        │  Testing.csproj                 テストプロジェクトファイル
        │
        ├─IntegrationTest
        │  (統合テストフォルダ)
        │
        └─UnitTest
           (単体テストフォルダ)
```



# WEB APIのフォルダ構成

```
WebApi
│  (ソリューションのルートフォルダ)
│
│  .gitignore                             [git] 無視ファイル設定
│  WebApi.sln                             ソリューションファイル
│  README.md                              [Azure] リポジトリの概要説明ファイル
│
├─src
│   │  (ソースコードフォルダ)
│   │
│   WebApi
│       │  (プロジェクトのルートフォルダ)
│       │
│       │  WebApi.csproj                  プロジェクトファイル
│       │  appsettings.Development.json   設定ファイル (開発用)
│       │  appsettings.json               設定ファイル (デフォルト)
│       │  Program.cs                     プログラムのエントリポイント定義用クラス
│       │  Startup.cs                     アプリケーション起動時の設定用クラス
│       │
│       ├─Abstractions
│       │  │  (抽象化定義)
│       │  │
│       │  ├─Domain
│       │  │  (インターフェース定義 - ドメイン層)
│       │  │
│       │  └─Infrastructure
│       │     (インターフェース定義 - インフラストラクチャ層)
│       │
│       ├─Controllers
│       │  (Web API用のMVCコントローラ)
│       │
│       ├─Domain
│       │  │  (ドメイン層の実装)
│       │  │
│       │  ├─Dto
│       │  │  (層境界横断のためのデータ定義)
│       │  │
│       │  ├─Entities
│       │  │  (エンティティ)
│       │  │
│       │  └─Services
│       │     |  (ドメインサービス)
│       │     │
│       │     └─Stubs
│       │        (ドメインサービスのスタブ実装)
│       │
│       ├─Infrastructure
│       │  │  (インフラストラクチャ層の実装)
│       │  │
│       │  └─Repositories
│       │     (リポジトリ)
│       │
│       ├─Models
│       │  (リポジトリ向けのPOCOデータ)
│       │
│       └─Properties
│          │  (VisualStudioのためのプロジェクト設定)
│          │
│          └─PublishProfiles
│             (デプロイ設定)
│
└─test
    │  (テストコードフォルダ)
    │
    └─Testing
        │  (テストプロジェクトのルートフォルダ)
        │
        │  Testing.csproj                 テストプロジェクトファイル
        │
        ├─IntegrationTest
        │  (統合テストフォルダ)
        │
        └─UnitTest
           (単体テストフォルダ)
```