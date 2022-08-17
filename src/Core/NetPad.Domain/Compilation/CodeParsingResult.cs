using System.Collections.Generic;
using System.Linq;

namespace NetPad.Compilation
{
    public class CodeParsingResult
    {
        public CodeParsingResult(
            HashSet<string> namespaces,
            string userProgram,
            string bootstrapperProgram,
            string? additionalCodeProgram,
            ParsedCodeInformation parsedCodeInformation)
        {
            Namespaces = namespaces;
            UserProgram = userProgram;
            BootstrapperProgram = bootstrapperProgram;
            AdditionalCodeProgram = additionalCodeProgram;
            ParsedCodeInformation = parsedCodeInformation;
        }

        public HashSet<string> Namespaces { get; }
        public string UserProgram { get; }
        public string BootstrapperProgram { get; }
        public string? AdditionalCodeProgram { get; }
        public ParsedCodeInformation ParsedCodeInformation { get; }

        public string GetFullProgram()
        {
            return $@"{string.Join("\n", Namespaces.Select(ns => $"using {ns};"))}

{UserProgram}

{AdditionalCodeProgram}

{BootstrapperProgram}";
        }
    }
}
