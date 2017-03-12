using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsScript
{
    [Guid("81cf6f0d-90dc-4541-96e2-1e84c4c5f312")]
    public class FooGenerator : IVsSingleFileGenerator
    {
        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".vbs";
            return 0;
        }

        public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            string output = bstrInputFileContents.Replace("a", "A");
            byte[] bytes = Encoding.UTF8.GetBytes(output);

            rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(bytes.Length);
            Marshal.Copy(bytes, 0, rgbOutputFileContents[0], bytes.Length);

            pcbOutput = (uint)bytes.Length;
            return 0;
        }
    }
}
