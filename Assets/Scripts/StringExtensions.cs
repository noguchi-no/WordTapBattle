using System;
using System.Linq;

public static class StringExtensions
{
    public static bool IncludeAny( 
        this string self, 
        params string[] list 
    )
    {
        return list.Any( c => self.Contains( c ) );
    }
}