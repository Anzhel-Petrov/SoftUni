﻿namespace _01.StreamProgressInfo
{
    public class StreamProgressInfo
    {
        private File file;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(File file)
        {
            this.file = file;
        }

        public int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}
