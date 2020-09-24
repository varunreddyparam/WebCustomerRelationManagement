using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCustomerRelationManagement.Interface
{
    public interface IBlobDataManager
    {
        ProgressRecorder ProgressRecorder { get; set; }
        Task UploadFileToBlobAsync(string sourceFilePath, BlobOptions options);
    }
}
