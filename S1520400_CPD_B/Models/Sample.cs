using System;
using System.ComponentModel.DataAnnotations;

namespace S1520400_CPD_B.Models
{

    //This is the data transfer object class that is sent in the Rest requests/responses.
    public class Sample
    {
        ///<summary>
        /// Sample ID
        /// </summary>
        [Key]
        public string SampleID { get; set; }

        ///<summary>
        /// Title of the sample
        /// </summary>
        public string Title { get; set; }

        ///<summary>
        /// Name of the Artist
        /// </summary>
        public string Artist { get; set; }

        ///<summary>
        /// creation date/time of entity
        /// </summary>
        public DateTime CreatedDate { get; set; }

        ///<summary>
        /// Name of uploaded blob in blob storage
        /// </summary>
        public string Mp3Blob { get; set; }

        ///<summary>
        /// Name of sample blob in blob storage
        /// </summary>
        public string SampleMp3Blob { get; set; }

        ///<summary>
        /// Web service resource URL of mp3 sample
        /// </summary>
        public string SampleMp3Url { get; set; }

        ///<summary>
        /// creation date/time of sample blob
        /// </summary>
        public DateTime SampleDate { get; set; }

    }
}