using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public abstract class Stream
    {
        public Stream(int length, int bytesSent)
        {
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; }

        public int BytesSent { get; }
    }
}
