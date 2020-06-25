﻿using System;
using Microsoft.WindowsAzure.Storage.DataMovement;

namespace WebCustomerRelationManagement.Interface
{
    /// <summary>
    /// A helper class to record progress reported by data movement library.
    /// </summary>
    public class ProgressRecorder : IProgress<TransferStatus>
    {
        public long LatestBytesTransferred { get; private set; }
        public long LatestNumberOfFilesTransferred { get; private set; }
        public long LatestNumberOfFilesSkipped { get; private set; }
        public long LatestNumberOfFilesFailed { get; private set; }

        public void Report(TransferStatus progress)
        {
            LatestBytesTransferred = progress.BytesTransferred;
            LatestNumberOfFilesTransferred = progress.NumberOfFilesTransferred;
            LatestNumberOfFilesSkipped = progress.NumberOfFilesSkipped;
            LatestNumberOfFilesFailed = progress.NumberOfFilesFailed;
        }

        public override string ToString()
        {
            return $"Transferred bytes: {LatestBytesTransferred}; Transfered: {LatestNumberOfFilesTransferred}; Skipped: {LatestNumberOfFilesSkipped}, Failed: {LatestNumberOfFilesFailed}";
        }
    }
}
