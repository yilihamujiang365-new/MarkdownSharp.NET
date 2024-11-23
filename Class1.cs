using System.Text.RegularExpressions;
using System;
namespace MarkdownSharp.NET
{
    public class MarkdownConverter
    {
        public string Md2Html(string markdown)
        {
            // 替换标题
            markdown = Regex.Replace(markdown, @"^(#{1,6})\s+(.*?)(?:\r?\n|$)", match =>
            {
                int level = match.Groups[1].Value.Length;
                string content = match.Groups[2].Value;
                return $"<h{level}>{content}</h{level}>\n";
            }, RegexOptions.Multiline);

            //替换无序列表
            markdown = Regex.Replace(markdown, @"(?<=^|\n)[*-] (.*)", "<ul><li>$1</li></ul>", RegexOptions.Multiline);
            markdown = Regex.Replace(markdown, @"<\/ul>\s*<ul>", "", RegexOptions.Singleline);
            // 替换有序列表
            markdown = Regex.Replace(markdown, @"(?<=^|\n)\d+\. (.*)", "<ol><li>$1</li></ol>", RegexOptions.Multiline);
            markdown = Regex.Replace(markdown, @"<\/ol>\s*<ol>", "", RegexOptions.Singleline);

            // 替换加粗文本
            markdown = Regex.Replace(markdown, @"(\*\*|__)(.*?)\1", "<strong>$2</strong>");
            // 替换斜体文本
            markdown = Regex.Replace(markdown, @"(\*|_)(.*?)\1", "<em>$2</em>");
            // 替换删除线文本
            markdown = Regex.Replace(markdown, @"~~(.*?)~~", "<del>$1</del>");

            // 替换表格
            markdown = Regex.Replace(markdown, @"((?<=\n)|^)\|(.+?)\|\s*\n\|([-:| ]+)\|\n((\s*\|.+?\|\s*\n)+)", match =>
            {
                string header = match.Groups[2].Value;
                string alignments = match.Groups[3].Value;
                string rows = match.Groups[4].Value;

                string[] headers = header.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string[] alignmentsArray = alignments.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string[] rowLines = rows.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                string table = "<table style=\"border-collapse: collapse; width: 100%; border: 1px solid #000;\">";

                table += "<thead><tr>";
                string[] styles = new string[headers.Length];
                for (int i = 0; i < headers.Length; i++)
                {
                    string alignment = alignmentsArray[i].Trim();
                    string style = "text-align: left;"; // 默认左对齐
                    if (alignment.StartsWith(":") && alignment.EndsWith(":"))
                    {
                        style = "text-align: center;";
                    }
                    else if (alignment.EndsWith(":"))
                    {
                        style = "text-align: right;";
                    }
                    styles[i] = style;
                    table += $"<th style=\"border: 1px solid #000; padding: 8px; {style}\">{headers[i].Trim()}</th>";
                }
                table += "</tr></thead><tbody>";

                foreach (var row in rowLines)
                {
                    if (string.IsNullOrWhiteSpace(row)) continue;
                    string[] cells = row.Split('|', StringSplitOptions.RemoveEmptyEntries);
                    table += "<tr>";
                    for (int i = 0; i < cells.Length; i++)
                    {
                        table += $"<td style=\"border: 1px solid #000; padding: 8px; {styles[i]}\">{cells[i].Trim()}</td>";
                    }
                    table += "</tr>";
                }
                table += "</tbody></table>";
                return table;
            }, RegexOptions.Singleline);

            // 处理图片
            string imgPattern = @"!\[(.*?)\]\((\S+)(?:\s+""(.*?)""|\s+'(.*?)')?\)";
            string imgReplacement = "<img src=\"$2\" alt=\"$1\" title=\"$3$4\">";
            markdown = Regex.Replace(markdown, imgPattern, imgReplacement);

            // 处理链接
            string linkPattern = @"\[(.*?)\]\((\S+)(?:\s+[""'](.*?)[""'])?\)";
            string linkReplacement = "<a href=\"$2\" title=\"$3\">$1</a>";
            markdown = Regex.Replace(markdown, linkPattern, linkReplacement);

            // 处理代码块前面```和后面```都有的
            string codeBlockPattern = @"```(\w*)\n([\s\S]*?)\n```";
            string codeBlockReplacement = @"
<div>
    <div class=""code-header"">
        <span class=""code-language"">$1</span>
   </div>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        pre {
            position: relative;
            background-color: #f8f8f8;
            border: 1px solid #ddd;
            padding: 10px;
            margin: 20px 0;
            overflow-x: auto;
        }
        .code-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            background-color: #eaeaea;
            padding: 5px 10px;
            border-bottom: 1px solid #ddd;
        }
        .code-language {
            font-weight: bold;
        }       
    </style>    
    <pre><code class=""language-$1"">$2</code></pre>
</div>";
            markdown = Regex.Replace(markdown, codeBlockPattern, codeBlockReplacement, RegexOptions.Singleline);

            // 处理代码块前面有```和后面没有
            string codeBlockPattern2 = @"```(\w*)\n([\s\S]*?)(```|$)";  // 匹配到三反引号或文件结尾
            string codeBlockReplacement2 = @"
<div class=""code-container"">
    <div class=""code-header"">
        <span class=""code-language"">$1</span>
    </div>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .code-container {
            position: relative;
            margin: 20px 0;
        }
        pre {
            background-color: #f8f8f8;
            border: 1px solid #ddd;
            padding: 10px;
            overflow-x: auto;
        }
        .code-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            background-color: #eaeaea;
            padding: 5px 10px;
            border-bottom: 1px solid #ddd;
        }
        .code-language {
            font-weight: bold;
        }
    </style>
    <pre><code class=""language-$1"">$2</code></pre>
</div>";
            markdown = Regex.Replace(markdown, codeBlockPattern2, codeBlockReplacement2, RegexOptions.Singleline);

            // 处理行内代码
            string inlineCodePattern = @"`([^`]+)`";
            string inlineCodeReplacement = @"<code>$1</code>";
            markdown = Regex.Replace(markdown, inlineCodePattern, inlineCodeReplacement);

            return markdown;
        }
    }
}