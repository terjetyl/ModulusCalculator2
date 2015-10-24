namespace ModulusCalculator

module private Helper = 
    
    open System
    open System.Globalization

    let isNumeric str = 
        let success, _ = Double.TryParse str
        success

    let charToInt (x:char) =
        Int32.Parse(x.ToString())

    let convertToCharArray (str:String) = 
        str.ToCharArray()

    let revertArray arr = 
        Array.rev arr

    let convertToNumArray (charArray:char[]) = 
        charArray |> Array.map charToInt

    let doubleEverySecondNumber arr =
        arr |> Seq.mapi (fun i x -> 
                            match i%2 with
                            | 0 -> x*2
                            | _ -> x)

    let splitNumber x = 
        match x with 
        | a when a > 9 -> 1 + (a-10)
        | _ -> x

    let splitNumbersOver10 arr = 
        arr |> Seq.map splitNumber
    
module Mod10 =
    
    open System
    open Helper

    let GetControlNumber (modbase:String) : Int32 = 
        if(String.IsNullOrWhiteSpace(modbase)) then
            failwith "modbase was null or empty"
        if(isNumeric modbase = false) then
            failwith "modbase is not numeric"

        let modnum = modbase
                        |> convertToCharArray
                        |> revertArray 
                        |> convertToNumArray
                        |> doubleEverySecondNumber
                        |> splitNumbersOver10
                        |> Seq.sum

        let controlnumber = 10 - (modnum%10)
        controlnumber

    let Calculate modbase = 
        let controlnumber = GetControlNumber modbase

        match controlnumber with
        | 10 -> modbase + "0"
        | _ -> modbase + controlnumber.ToString()

module Mod11 =

    open System
    open Helper

    let GetControlNumber (modbase:String) : Int32 = 
        if(String.IsNullOrWhiteSpace(modbase)) then
            failwith "modbase was null or empty"
        if(isNumeric modbase = false) then
            failwith "modbase is not numeric"

        let weightNumbers = [ 2; 3; 4; 5; 6; 7 ]

        let modnum num weightNumber = 
            num*weightNumber

        let sum = modbase
                    |> convertToCharArray
                    |> revertArray 
                    |> convertToNumArray
                    |> Seq.mapi (fun i x -> modnum x weightNumbers.[i%6])
                    |> Seq.sum

        let controlnumber = 11 - (sum % 11)
        controlnumber

    let Calculate modbase = 
    
        let controlnumber = GetControlNumber modbase

        match controlnumber with
        | 11 -> modbase + "0"
        | _ -> modbase + controlnumber.ToString()