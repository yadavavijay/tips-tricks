using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WhiteSpaceRemoval.Extension
{
    public class WhitespaceModule : Stream
    {
        private Stream Base;

        public WhitespaceModule(Stream ResponseStream)
        {
            if (ResponseStream == null)
                throw new ArgumentNullException("ResponseStream");
            this.Base = ResponseStream;
        }

        StringBuilder s = new StringBuilder();

        public override void Write(byte[] buffer, int offset, int count)
        {
            string HTML = Encoding.UTF8.GetString(buffer, offset, count);

            Regex reg = new Regex(@"(?<=\s)\s+(?![^<>]*</pre>)");
            HTML = reg.Replace(HTML, string.Empty);

            buffer = Encoding.UTF8.GetBytes(HTML);
            this.Base.Write(buffer, 0, buffer.Length);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override bool CanRead { get { return false; } }

        public override bool CanSeek { get { return false; } }

        public override bool CanWrite { get { return true; } }

        public override long Length { get { throw new NotSupportedException(); } }

        public override long Position
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public override void Flush()
        {
            Base.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }
    }
}