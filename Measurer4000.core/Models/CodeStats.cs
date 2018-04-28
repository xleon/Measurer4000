namespace Measurer4000.Core.Models
{
    public class CodeStats
    {
        public double ShareCodeInAndroid { get; set; }

        public double ShareCodeIniOs { get; set; }

		public double ShareCodeInUwp { get; set; }

        public double AndroidSpecificCode { get; set; }

        public double IOsSpecificCode { get; set; }

		public double UwpSpecificCode { get; set; }

        public long AmountOfFiles { get; set; }

        public long CodeFiles { get; set; }

        public long UiFiles { get; set; }

        public long TotalLinesOfCode { get; set; }

        public long TotalLinesOfUi { get; set; }

        public long AndroidFiles { get; set; }

        public long IOsFiles { get; set; }

		public long UwpFiles { get; set; }

        public long TotalLinesCore { get; set; }

        public long TotalLinesInAndroid { get; set; }

        public long TotalLinesIniOs { get; set; }

		public long TotalLinesInUwp { get; set; }

        public override string ToString()
        {
            return $@"Share code Android: {ShareCodeInAndroid} 
                        Share code iOS: {ShareCodeIniOs} 
                        Share code UWP: {ShareCodeInUwp} 
                        Android specific: {AndroidSpecificCode} 
                        iOS specific: {IOsSpecificCode} 
                        UWP specific: {UwpSpecificCode} 
                        Files: {AmountOfFiles} 
                        Code files: {CodeFiles} 
                        UI files: {UiFiles} 
                        Total lines of code {TotalLinesOfCode} 
                        Total lines of UI {TotalLinesOfUi} 
                        Android files {AndroidFiles} 
                        iOS files {IOsFiles} 
                        UWP files {UwpFiles} 
                        Total lines core {TotalLinesCore} 
                        Total lines Android {TotalLinesInAndroid} 
                        Total lines iOS {TotalLinesIniOs} 
                        Total lines in UWP {TotalLinesInUwp} ";                        
        }
    }
}
