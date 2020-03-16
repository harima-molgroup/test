[[_TOC_]]

```
誰でも、コンピューターが理解できるコードを書くことができます。 
優れたプログラマーは、人々が理解できるコードを書きます。
　　　　　　　　　　　マーティン・ファウラー 『リファクタリング』

“Any fool can write code that a computer can understand.
Good programmers write code that humans can understand.”  
  -- Martin Fowler, "Refactoring: Improving the Design of Existing Code"
```

# 可読性
## 概要
可読性は高品質なコードの条件といえる。
- 可読性の低いコードが
  - 保守しやすいことはない。
  - 拡張しやすいことはない。
  - テストしやすいことはない。
  - 開発を楽しくすることはない。
- コード全体の可読性が高く保たれたシステムは、
  - 上記とは逆に、自然に一定の保守性、拡張性、テスト可能性を備える。
    - バグが混入しにくい。
    - 経年劣化 (秘伝のたれ化) しにくい。
    - ドキュメントが最小限で済む (コードが自己ドキュメント化されている)。
  - 新規参入者にとってなじみやすい。
  - 経験の浅いメンバーがコードから多くを学ぶことができる。
  - 関わっていて嬉しい。
    - チームの士気を保ちやすい。
    - 優秀な新規参入者に逃げられにくい。
  - :arrow_right: 短期的、長期的にあらゆる面で開発コスト低減に寄与する。

## 可読性の高いコードとは
### 単独のコードとして
- パッと見た瞬間、すっきりしている。
  - 直観的に「読みたくない」と感じさせない。
  - ネストが深くない。
  - メソッドがコンパクト。
  - 適切な改行や空行挿入など、レイアウトの工夫により見た目にもメリハリがある。
    - 1行が長すぎたりしない。

- 実際に読んだとき、理解しやすい。
  - ロジックが整理されている。
    - コードが短い。
    - シンプルに書かれている。
      - 余計なことをしていない。
        - 冗長な処理
        - コードを短くするための無理な書き方  
        など...
      - 慣用的な書き方を優先している。
      - 適切なガード節の使用により、考えなくてよいことが明確になっている。
  - コードの意図が見える。
    - クラス、メソッド、変数などに適切な名前がつけられている。
      - 「名は体を表して」いる。
        - 「それが何なのか」に関するコメントが必要ない。
      - 名前がコードの説明にもなっている。
      - おかしな英語を使っていない。
    - 必要かつ十分なコメントが書かれている。
      - なぜそのような処理をしているかが説明されている。
        - 特殊なケースの考慮
        - 利用ライブラリの仕様による事情
        - 自身の仕様による事情  
        など...
      - 見ればわかるような自明な情報がコメントされていない。
        - 意味のある値は適切な名前の変数に格納して、コメントを回避。
        - 要所要所のログ出力でさりげなくコードの説明も行い、コメントを回避。

### 全体として
- 一貫性がある
  - 共通のルールに従っており、バラつきが少ない。
    - レイアウトの仕方
    - 名前の付け方
      - 記法
      - 単語の選択
    - クラスや処理の分割方針
      - フレームワーク
      - アーキテクチャ
    - コードの書き方
      - 構文や言語機能の選択
      - イディオムの使用
      - パターンの使用
  - 仕様とコードの対応が明らかである。
    - 各々の要素の役割がはっきりしている。

# テストしやすさ
## 概要
CI/CDを実現して安全かつ効率的に開発を行うためにはテストコードの存在が不可欠であり、  
そのためには当然、 テストしやすいコードを書かなければならない。
- テストの存在により、本体コード修正時の単体レベルの動作確認を自動化することができる。
  - 単体テスト実施工数削減
    - 何度でも実施可能
    - 特定のタイミングで自動的に実行 (やり忘れない)
    - 人手と違いミスがない (再現性)
      - 正しくないテストも例外なく再現されるため注意が必要。
  - デグレード発生の防止
- テストコードは仕様をコードで表現するドキュメントとしても機能しうる。
  - ドキュメントの削減
- テストコードは、システム本体と同じく資産である。  
  テストしやすいコードは、低コストで高品質な資産を生み出すことを可能にする。  
  (テスト困難なコードはそれ自体が負債であり、その負債は時間とともに増大する)

### 可読性との関係
- テストしやすいコードには可読性の高さが要求される。
  - 読めないコードのテストは誰も書けない!
- 逆に、コードをテストしやすいよう改善すると、通常は可読性も向上する。  
:arrow_right: テストしやすいコードは、可読性の高いコードのサブセットである。
- テストしやすいコードに対するテストは、通常シンプルである。  
  つまり、テストしやすいコードは、テストの可読性が高くなる。

## テストしやすいコードとは
- [各クラスの凝集度が高い。](https://ja.wikipedia.org/wiki/%E5%87%9D%E9%9B%86%E5%BA%A6)
  - クラスの役割がはっきりしている
    - テストすべき処理が明確である。
- [クラス同士の結合度が低い。](https://ja.wikipedia.org/wiki/%E7%B5%90%E5%90%88%E5%BA%A6)
  - クラス同士の依存が弱いため、テスト対象のクラスを準備するために他の複雑なクラスを  
  いろいろ調整しなくてよい。
  - 処理と直接関係のあるクラスのみがコードに現れる。  
    (なんでもできる巨大なクラスがあちこちに不自然に混ざりこんだりしていない)
  - 依存性注入 (DI: Dependancy Injection) が適切に行われている。
    - テストにおいてはスタブを注入し、純粋に目的のメソッドのコードのみを対象とした  
    テストを実施できる。
- クラスもメソッドもコンパクトである。
  - 高凝集かつ低結合なコードを書くことによりコードは通常、全体にコンパクトになる。
  - コードがシンプルで分岐、ループ、ネストが最小限である。
    - テストすべきパターンの網羅 (カバレッジ) が楽である。  
      (ネストするごとにパターンは掛け算で増加する!)
    - 具体的には、using ブロックや try～catch の分を除いて三段以上のネストがない。
  - privateメソッドが少ない
    - テストが複雑にならない。  
      (publicメソッドを通したprivateメソッドのテストは、否が応にも複雑になる)
    

# 保守性と拡張性
## 概要
保守性と拡張性は、コードの品質を保ちつつ不具合修正や仕様変更への対応を  
長期間続けていくために重要である。

- 実績のあるフレームワークやアーキテクチャを採用することが非常に効果的である。
  - フレームワークやアーキテクチャはそもそも保守性、拡張性を主要な課題として  
    設計されている。
  - そのフレームワークやアーキテクチャの経験者であればスムーズに新規参入できる。
- コードに一定以上の保守性、拡張性がある場合には、それらを向上させるための改修を  
  行うことが可能となる。  
  :arrow_right: 水準を下回ってしまわないよう、品質向上を目的とした保守を定期的に実施することが重要。
  - 技術的負債の返済 (リファクタリング)
  - 最新技術の採用

### 可読性との関係
- 保守性、拡張性の高いコードには可読性の高さが要求される。
  - 読めないコードには誰も手を入れることができない!
- 逆に、コードの保守性、拡張性が高くなると、通常は可読性も向上する。  
:arrow_right: 保守性、拡張性の高いコードは、可読性の高いコードのサブセットである。

### テストしやすさとの関係
- 保守性、拡張性の高いコードにはテストしやすいことが要求される。
  - テストの存在が保守、拡張作業の安全性と効率を担保する。
  - テストがないコードの修正にはデグレードのリスクがつきまとう。
  - テストがない場合、コード修正のたびに手動と目視による動作確認のコストが発生する。  
    当然、ヒューマンエラーも発生しうる。
- 逆に、コードの保守性、拡張性が高くなると、通常はテストのしやすさも向上する。  
:arrow_right: 保守性、拡張性の高いコードは、テストしやすいコードのサブセットである。

## 保守性と拡張性の高いコードとは
:warning: 以下はテストしやすいコードと一部重複している。
- クラスのモジュール性が高い。
  - 個々のクラスやメソッドの役割が明確である。
    - それぞれがコンパクトにできている。
      - 可読性が高い。
      - テストしやすい。
    - モジュール同士の独立性が高い。
      - 改修時にやるべきことが明確である。
        - どこを変更すべきか。
        - 変更がどこに影響するか。
      - テストしやすい。
  - コードが再利用できる。
    - 同じような修正を何か所も行わなくてよい。
      - 修正漏れのリスクが低い。
      - テスト側の修正対応が最小限で済む。
    - 特定の機能を丸ごと差し替えるといった対応が可能。
      - 機能拡張も実現できる。
    - 設定ファイルなどを利用してノンコーディングでシステムの挙動を変更できる。

# 参考 : ダメなコードについて
ダメなコードについて知ることも大変重要です :spaghetti:
- [本当にあった怖いプログラム（クソコード事例集）](https://axia.co.jp/2018-04-27)  
- [ウンコード・マニア 「なんだこの糞コードは!(怒)」「書いた奴出てこい!(怒)」](http://unkode-mania.net/legend)
- [ダメなコード" での検索結果](https://www.google.com/search?q=%E3%83%80%E3%83%A1%E3%81%AA%E3%82%B3%E3%83%BC%E3%83%89&rlz=1C1GCEU_jaJP860JP860&oq=%E3%83%80%E3%83%A1%E3%81%AA%E3%82%B3%E3%83%BC%E3%83%89&aqs=chrome..69i57j0l7.7017j1j8&sourceid=chrome&ie=UTF-8)