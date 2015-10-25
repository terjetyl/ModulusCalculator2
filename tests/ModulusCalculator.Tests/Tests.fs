module ModulusCalculator.Tests

open ModulusCalculator
open NUnit.Framework

[<Test>]
let ``get control number 1`` () =
  let result = Mod10.GetControlNumber("234567")
  printfn "%i" result
  Assert.AreEqual(6,result)

[<Test>]
let ``get control number 2`` () =
  let result = Mod10.GetControlNumber("020130096")
  printfn "%i" result
  Assert.AreEqual(9,result)

[<Test>]
let ``get control number 3`` () =
  let result = Mod10.Calculate("234567")
  printfn "%s" result
  Assert.AreEqual("2345676",result)

[<Test>]
let ``get control number 4`` () =
  let result = Mod10.Calculate("020130096")
  printfn "%s" result
  Assert.AreEqual("0201300969",result)