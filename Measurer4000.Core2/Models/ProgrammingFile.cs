namespace Measurer4000.Core.Models
{
    public class ProgrammingFile
    {
        public string Name { get; set; }

        public long Loc { get; set; }

        public bool IsUserInterface { get; set; }

        public EnumTypeFile TypeFile { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            return $@"Name: {Name} 
                    LOC: {Loc} 
                    UI: {IsUserInterface} 
                    TypeFile: {TypeFile} 
                    Path: {Path}";                
        }
    }
}
