using System;

public static class ShuffleWords  //※名前は任意
{
    /// <summary>
    /// 文字列をシャッフルしたものを返す
    /// 2021/04/04 Fantom
    /// http://fantom1x.blog130.fc2.com/blog-entry-395.html
    /// </summary>
    /// <param name="text">元の文字列</param>
    /// <returns></returns>
    public static string Shuffle(this string text)
    {
        var array = text.ToCharArray();
        array.Shuffle();  
        return new string(array);
    }
}

