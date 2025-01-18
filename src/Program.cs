using System;
using System.Numerics;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;


namespace fhir_application_consoleapp
{
    class Program
    {

        private const string _fhirServer = "https://server.fire.ly/";

        static void Main(string[] args)
        {
            FhirClient fhirClient = new FhirClient(_fhirServer){
                PreferredFormat = ResourceFormat.Json,
                PreferredReturn = Prefer.ReturnRepresentation
            };

            Bundle patientBundle = fhirClient.Search<Patient>(new string[] { "name=test" });

            System.Console.WriteLine($"Total: {patientBundle.Total} Entry Count: {patientBundle.Entry.Count}");

            // int total = patientBundle.Total ?? 0;
            // for(int i = 0; i < patientBundle.Total; i++){
            //     patientBundle.
            // }


            int patientNumber = 0;
            foreach (Bundle.EntryComponent entry in patientBundle.Entry){
                System.Console.WriteLine($"- Entry: {patientNumber, 3}: {entry.FullUrl}");
                
                if(entry.Resource != null){
                    Patient patient = (Patient)entry.Resource;
                    System.Console.WriteLine($"     - {patient.Id,20} {patient.Name[0]}");   
                }

                patientNumber++;
            }

        }
    }
}