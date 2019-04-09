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
        /// Web service resource URL of mp3 sample
        /// </summary>
        public string SampleMp3Url { get; set; }

    }
}