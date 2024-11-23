# MarkdownSharp
## ����
**MarkdownSharp**��һ���ǿ��Ĵ���⣬���ܹ��� Markdown �ı�ת��Ϊ HTML���ÿ���� C# �� .NET SDK ������Ŀǰ�Ļ������������������С���ӭ��λ�����߹����Լ�����������ͬ���������Ŀ��  ![Logo](https://via.placeholder.com/150)
## ��Դ����
����������MIT��ԴЭ��<br>
����E-mail:[yilihamujiang365@outlook.com](mailto:yilihamujiang365@outlook.com)
## ʹ�÷���
���߿���������<br>
- ϵͳ������Microsoft Windows 11 רҵ�� 10.0.26120
- NET SDK�汾:9.0.100
- Visual Studio�汾��2022
## ������Nuget
### �ֶ�����
- ��Ŀ���������.dll(��̬���ӿ�)��Ȼ�����ڴ�����using
```Csharp
using MarkdownSharp;
```
### ��Nuget����
[nuget](https://www.nuget.org/packages/MarkdownSharp/)

### ʵ��
```Csharp
using System;
using MarkdownSharp;
class Program
{
    static void Main()
    {
        // Markdown �ı�
        string markdownText = @"
## Hello World
This is an example of **bold text**, *italic text*, and a [link](https://www.example.com).
Here is a list:
- Item 1
- Item 2
- Item 3

And here is a code block:

";
// ���� Markdown ת����ʵ��
        Markdown markdownConverter = new Markdown();

        // �� Markdown �ı�ת��Ϊ HTML
        string htmlOutput = markdownConverter.Transform(markdownText);

        // ���ת����� HTML
        Console.WriteLine(htmlOutput);
    }
}

```
## Ŀǰ��ʵ�ֵĹ��ܼ�ʹ�÷���
��ʵ�ֱ��⣬���壬�»��ߣ�ɾ���ߣ�ͼƬ�����ӣ����������������<br>
����������ϸ��[markdown.com](https://markdown.com.cn/cheat-sheet.html)
```Markdown
# һ������
## ��������
### ��������
#### �ļ�����
##### �弶����
###### ��������

**����**

_�»���_

~~ɾ����~~

[����](https://markdown.com.cn/cheat-sheet.html)

| ��ͷ1 | ��ͷ2 |
|-------|-------|
| ��Ԫ�� | ��Ԫ�� |

1. ��������
2. ��������

- ������
- ������
```
## ���ص�ַ
![NuGet](https://img.shields.io/MarkdownSharp/v/MarkdownSharp.svg)(https://www.nuget.org/packages/MarkdownSharp/) 
