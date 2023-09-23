using System;
using System.Collections.Generic;
using System.Linq;

// 2 ways of filtering base on type: 
//      1. .OfType<>() extension
//      2. LINQ (worse)

var someList = new List<GenericType>() { new DerivedType1("first"), new DerivedType2("second"), new DerivedType1("third"), new DerivedType2("fourth") };
// var onlyType1 = someList.Where(x => x.GetType() == typeof(DerivedType1)).Select(x => x);
var onlyType1 = someList.OfType<DerivedType1>();
onlyType1 = onlyType1.ToList<DerivedType1>();
Console.WriteLine(onlyType1);

foreach(DerivedType1 member in onlyType1){
    Console.WriteLine(member.Name);
}

public class GenericType{
    public GenericType(){

    }
}

public class DerivedType1: GenericType{
    public string Name { get; init; }
    public DerivedType1(string name):base(){
        Name = name;
    }
}
public class DerivedType2: GenericType{
    public string Name { get; init; }
    public DerivedType2(string name):base(){
        Name = name;
    }
}

