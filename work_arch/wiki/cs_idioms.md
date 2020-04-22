[[_TOC_]]

# Web Application
---
# Web API
---
# ファイル粒度
 - partial
---

# ループ処理
## コレクションの変更を伴うループ処理
### 要素の差し替え
:rage: ビルドエラー
``` csharp
foreach(var member in team.members){
  if(!IsGood(member)){
    // ビルドエラー('member' は 'foreach繰り返し変数' であるため、これに割り当てることはできません。)
    member = new Member("Good Person");
  }
  ...
}
```
:confounded: エラーは回避できるが分かりにくい
``` csharp
// using System.Linq; が必要
int index = 0;
foreach(var member in team.members.ToList()){
  if(!IsGood(member)){
    team.members[index] = new Member("Good Person");
  }
  ...

  index++;
}
```
:grin: for文を利用すればもう少しシンプルに書ける
``` csharp
for(int i = 0; i < team.members.Count; i++){
  var member = team.members[i];
  if(!IsGood(member)){
    team.members[i] = new Member("Good Person");
  }
  ...
}
```
:stuck_out_tongue_closed_eyes: Linqが一番すっきり書ける (若干コストが高いため、速度が必要な場合は注意)
``` csharp
// using System.Linq; が必要
team.members = team.members
  .Select(x => IsGood(x) ? x : new Member("Good Person"))   // Goodなメンバー x はそのまま
  .ToList();
...
```
### 要素の追加、削除
:rage: 実行時エラー
``` csharp
foreach(var member in team.members){
  if(member.HasFriend){
    // 実行時エラー(Collection was modified; enumeration operation may not execute.)
    team.members.Add(member.Friend);
  }
  ...
}
```
:rage: 実行時エラー
``` csharp
foreach(var member in team.members){
  if(!IsGood(member)){
    // 実行時エラー(Collection was modified; enumeration operation may not execute.)
    team.members.Remove(member);
  }
  ...
}
```
:grin: コレクションのクローンに対してループを回すことで、コレクションの変更がループに影響を与えるのを回避
``` csharp
// using System.Linq; が必要

// ToListメソッドで同じ要素をもつコレクションが新たに生成される。
foreach(var member in team.members.ToList()){
  if(member.HasFriend){
    team.members.Add(member.Friend);
  }
  ...
}
```
:grin: Linqでも追加可能。慣れればこちらの方が意味が明確
``` csharp
// using System.Linq; が必要
team.members = team.members
  .Concat( // 後ろにコレクションをつなげる
    team.members.Where(x => x.HasFriend).Select(x => x.Friend)  // 各メンバーの友人を抽出
  ).ToList();
...
```
:stuck_out_tongue_closed_eyes: 削除はLinqなら実質的に1行で書ける
``` csharp
// using System.Linq; が必要
team.members = team.members
  .Where(x => IsGood(x))   // Goodなメンバー x のみ残す
  .ToList();
...
```

# データアノテーション
---

# 自動生成コード
---
# static
---
# const / readonly
---
# アクセス修飾子
---
# ヘルパ
---
# 定数管理
---
# 例外
---
# コメント
 - XMLコメント
 - コードコメント
---