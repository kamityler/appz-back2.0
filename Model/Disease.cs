using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;

namespace Lab5LKPZ.Model
{
    public class Disease
    {
       
            [Key]
            public int DiseaseID { get; set; }

            
            public int PatientID { get; set; }

            
            public string DiseaseStatus { get; set; }

            
            public string DiseaseName { get; set; }

           
            public string AdmissionDate { get; set; }

            public string DischargeDate { get; set; }

            public string Result { get; set; }
        [JsonIgnore]

        public MedicalRecordModel Patient { get; set; }
        
    }
}
