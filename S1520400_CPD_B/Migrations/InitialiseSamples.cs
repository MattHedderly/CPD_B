using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using S1520400_CPD_B.Models;
using System;
using System.Configuration;

namespace S1520400_CPD_B.Migrations
{
    public class InitialiseSamples
    {
        public static void go()
        {
            const String partitionName = "Samples_Partition_1";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureStorage"].ToString());

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("Samples");

            //check if the table exists; if it doesn't create it and populate it with some data, else do nothing
            if (!table.Exists())
            {
                //if it doesn't exist create it
                table.CreateIfNotExists();

                //create the batch operation as lab 4
                TableBatchOperation batchOperation = new TableBatchOperation();

                //create entities and add to table
                SampleEntity sample1 = new SampleEntity(partitionName, "1");
                sample1.Title = "Aqualung";
                sample1.Artist = "Jethro Tull";
                sample1.CreatedDate = DateTime.Now;
                sample1.Mp3Blob = null;
                sample1.SampleMp3Blob = null;
                sample1.SampleMp3Url = null;
                sample1.SampleDate = null;

                SampleEntity sample2 = new SampleEntity(partitionName, "2");
                sample2.Title = "Songs from the Wood";
                sample2.Artist = "Jethro Tull";
                sample2.CreatedDate = DateTime.Now;
                sample2.Mp3Blob = null;
                sample2.SampleMp3Blob = null;
                sample2.SampleMp3Url = null;
                sample2.SampleDate = null;

                SampleEntity sample3 = new SampleEntity(partitionName, "3");
                sample3.Title = "Wish You Were Here";
                sample3.Artist = "Pink Floyd";
                sample3.CreatedDate = DateTime.Now;
                sample3.Mp3Blob = null;
                sample3.SampleMp3Blob = null;
                sample3.SampleMp3Url = null;
                sample3.SampleDate = null;

                SampleEntity sample4 = new SampleEntity(partitionName, "4");
                sample4.Title = "Still Life";
                sample4.Artist = "Van der Graaf Generator";
                sample4.CreatedDate = DateTime.Now;
                sample4.Mp3Blob = null;
                sample4.SampleMp3Blob = null;
                sample4.SampleMp3Url = null;
                sample4.SampleDate = null;

                SampleEntity sample5 = new SampleEntity(partitionName, "5");
                sample5.Title = "Musical Box";
                sample5.Artist = "Genesis";
                sample5.CreatedDate = DateTime.Now;
                sample5.Mp3Blob = null;
                sample5.SampleMp3Blob = null;
                sample5.SampleMp3Url = null;
                sample5.SampleDate = null;

                SampleEntity sample6 = new SampleEntity(partitionName, "6");
                sample6.Title = "Supper's Ready";
                sample6.Artist = "Genesis";
                sample6.CreatedDate = DateTime.Now;
                sample6.Mp3Blob = null;
                sample6.SampleMp3Blob = null;
                sample6.SampleMp3Url = null;
                sample6.SampleDate = null;

                //add the samples to the batch insert as per lab 4
                batchOperation.Insert(sample1);
                batchOperation.Insert(sample2);
                batchOperation.Insert(sample3);
                batchOperation.Insert(sample4);
                batchOperation.Insert(sample5);
                batchOperation.Insert(sample6);

                //execute batch operation
                table.ExecuteBatch(batchOperation);


            }

        }
    }
}