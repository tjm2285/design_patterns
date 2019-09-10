using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetDesignPatternDemos.Creational.BuilderFacets
{
    class Field
    {
        public string _name;
        public string _type;

        public override string ToString()
        {
            return $"public {_type} {_name}";
        }
    }
    class Class
    {
        public string _name;
        public List<Field> Fields = new List<Field>();
        public Class()
        {

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {_name}").AppendLine("{");
            foreach (var f in Fields)
                sb.AppendLine($"  {f};");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    public class CodeBuilder
    {      
        public  CodeBuilder(string rootName)
        {
            theClass._name = rootName;
        }
        public CodeBuilder AddField(string name, string type)
        {
            theClass.Fields.Add(new Field { _name = name, _type = type });
            return this;
        }
        public override string ToString()
        {
            return theClass.ToString();
        }
        private Class theClass = new Class();
    }    


    public class Demo
    {
        static void Main2(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name","string").AddField("Age","int");
            Console.WriteLine(cb);
        }
    }
}
