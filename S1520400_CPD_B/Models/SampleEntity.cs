// Entity class for Azure table
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace S1520400_CPD_B.Models
{
    public class SampleEntity : TableEntity
    {
        // properties available for the entity
        public string SampleID { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Mp3Blob { get; set; }
        public string SampleMp3Blob { get; set; }
        public string SampleMp3Url { get; set; }
        //using ? to allow DateTime to be nullable
        public DateTime? SampleDate { get; set; }

        public SampleEntity(string partitionKey, string sampleID)
        {
            PartitionKey = partitionKey;
            RowKey = sampleID;
        }

        public SampleEntity() { }

    }
}