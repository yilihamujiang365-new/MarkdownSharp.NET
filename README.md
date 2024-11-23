# MarkdownSharp
## 介绍
**MarkdownSharp**是一款功能强大的处理库，它能够将 Markdown 文本转换为 HTML。该库基于 C# 和 .NET SDK 开发，目前的基本功能正在逐步完善中。欢迎各位开发者贡献自己的力量，共同完善这个项目。  ![tupian](https://via.placeholder.com/150)
## 开源介绍
本处理库基于MIT开源协议<br>
作者E-mail:[yilihamujiang365@outlook.com](mailto:yilihamujiang365@outlook.com)
## 使用方法
作者开发环境是<br>
- 系统环境：Microsoft Windows 11 专业版 10.0.26120
- NET SDK版本:9.0.100
- Visual Studio版本：2022
## 先引用Nuget
### 手动引用
- 项目中添加引用.dll(动态链接库)，然后再在代码中using
```Csharp
using MarkdownSharp;
```
### 用Nuget下载
[nuget](https://www.nuget.org/packages/MarkdownSharp/)

### 实例
```Csharp
using System;
using MarkdownSharp;
class Program
{
    static void Main()
    {
        // Markdown 文本
        string markdownText = @"
## Hello World
This is an example of **bold text**, *italic text*, and a [link](https://www.example.com).
Here is a list:
- Item 1
- Item 2
- Item 3

And here is a code block:

";
// 创建 Markdown 转换器实例
        Markdown markdownConverter = new Markdown();

        // 将 Markdown 文本转换为 HTML
        string htmlOutput = markdownConverter.Transform(markdownText);

        // 输出转换后的 HTML
        Console.WriteLine(htmlOutput);
    }
}

```
## 目前已实现的功能及使用方法
已实现标题，粗体，下划线，删除线，图片，链接，表格，有序无序序列<br>
其他的请仔细看[markdown.com](https://markdown.com.cn/cheat-sheet.html)
```Markdown
# 一级标题
## 二级标题
### 三级标题
#### 四级标题
##### 五级标题
###### 六级标题

**粗体**

_下划线_

~~删除线~~

[链接](https://markdown.com.cn/cheat-sheet.html)

| 表头1 | 表头2 |
|-------|-------|
| 单元格 | 单元格 |

1. 有序序列
2. 有序序列

- 无序列
- 无序列
```
## 下载地址
![NuGet](https://img.shields.io/MarkdownSharp/v/MarkdownSharp.svg)(https://www.nuget.org/packages/MarkdownSharp/) 
