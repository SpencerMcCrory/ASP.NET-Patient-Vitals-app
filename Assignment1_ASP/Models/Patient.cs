using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1_ASP.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        

        [Range(20, 400, ErrorMessage = "Please enter a stylostic reading between 20 and 400.")]
        public int Stylostic { get; set; }



        [Range(10, 300, ErrorMessage = "Please enter a diastolic reading between 10 and 300.")]

        public int Diastolic { get; set; }
        

        //temp values

        [Required(ErrorMessage = "Please select a date.")]
        public DateTime Date {  get; set; }

        [Required(ErrorMessage = "Please select a position.")]
        public string PositionId { get; set; }

        [ValidateNever]
        public Position Position { get; set; }

        public string Category(string input)
        {
            string colour = "";
            string health = "";
            string[] categories = new string[2];

            switch (this.Diastolic)
            {
                case > 120:
                    health = "Hypertensive Crisis";
                    colour = "darkred";
                    break;
                case >= 90:
                    health = "Hypertension Stage 2";
                    colour = "orangered";
                    break;
                case >= 80:
                    health = "Hypertension Stage 1";
                    colour = "orange";
                    break;
                default:
                    switch (this.Stylostic)
                    {
                        case < 120:
                            health = "Normal";
                            colour = "darkgreen";
                            break;
                        case < 130:
                            health = "Elevated";
                            colour = "blue";
                            break;
                        case < 140:
                            health = "Hypertension Stage 1";
                            colour = "orange";
                            break;
                        case <= 180:
                            health = "Hypertension Stage 2";
                            colour = "orangered";
                            break;
                        default:
                            health = "Hypertensive Crisis";
                            colour = "darkred";
                            break;

                    }
                    break;


            }
            if (input == "colour")
            {
                return colour;
            }
            else
            {
                return health;
            }
 

        }

     



    }
}
