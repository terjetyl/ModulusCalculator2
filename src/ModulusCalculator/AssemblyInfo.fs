namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("ModulusCalculator")>]
[<assembly: AssemblyProductAttribute("ModulusCalculator")>]
[<assembly: AssemblyDescriptionAttribute("Calculates Mod10 and Mod11")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
