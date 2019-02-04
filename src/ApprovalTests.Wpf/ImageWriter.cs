using System;
using ApprovalTests.Core;

namespace ApprovalTests.Wpf
{
    public class ImageWriter : IApprovalWriter
    {
        Action<string> writer;

        public ImageWriter(Action<string> writer)
        {
            this.writer = writer;
        }

        public virtual string GetApprovalFilename(string basename)
        {
            return $"{basename}.approved.png";
        }

        public virtual string GetReceivedFilename(string basename)
        {
            return $"{basename}.received.png";
        }

        public virtual string WriteReceivedFile(string received)
        {
            writer(received);
            return received;
        }
    }
}