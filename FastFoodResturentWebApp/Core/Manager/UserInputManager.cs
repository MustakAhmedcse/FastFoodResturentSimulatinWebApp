using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FastFoodResturentWebApp.Core.Gateway;
using FastFoodResturentWebApp.Models;
using Microsoft.Ajax.Utilities;

namespace FastFoodResturentWebApp.Core.Manager
{
    public class UserInputManager
    {
        private int clock = 0;
        UserInputGateway userInputGateway = new UserInputGateway();
        InterArrivalTimeMatchGateway interArrivalTimeMatchGateway = new InterArrivalTimeMatchGateway();
        ServiceTiemMatchGateway serviceTiemMatchGateway = new ServiceTiemMatchGateway();

        public string Insert(UserInput userInput)
        {
            if (userInputGateway.Insert(userInput) > 0)
            {
                return "Save Successfull.";
            }
            else
            {
                return "Sory! Save Fail.";
            }
        }

        public UserInput InputInfo()
        {
            return userInputGateway.InputInfo();
        }

        public List<InterArrivalTimeMatch> GetAllInterArrivalTimes()
        {
            return interArrivalTimeMatchGateway.GetAllInterArrivalTimes();
        }

        public List<ServiceTiemMatch> GetAllServiceTimes()
        {
            return serviceTiemMatchGateway.GetAllServiceTimes();
        }

        public List<FinalResult> GetAllFinalInfo()
        {
            return userInputGateway.GetAllFinalInfo();
        }

        //static Random serviceRandom=new Random();
        //int ranNumberForService = serviceRandom.Next(1000);

        public int FindInterArrivalTimeFromRandomDegit()
        {
            int interArrivalTiem = 0;
            if (clock != InputInfo().CalculateTime)
            {
                Random randomDegit = new Random();
                int randomInterArrivalTime = randomDegit.Next(1000);

                foreach (var interArrivalTimeMatch in GetAllInterArrivalTimes())
                {
                    if (randomInterArrivalTime >= interArrivalTimeMatch.MinRange && randomInterArrivalTime <= interArrivalTimeMatch.MaxRange)
                    {
                        if (clock == 0)
                        {
                            interArrivalTiem = 0;
                        }
                        else
                        {
                            interArrivalTiem = (int)interArrivalTimeMatch.InterArrivalTime;
                        }
                    }
                }
            }
            return interArrivalTiem;
        }

        public int FindServiceTimeFromRandomDegit()
        {
            int serviceTime = 0;
            if (clock != InputInfo().CalculateTime)
            {
                Random randomDegit = new Random();
                int randomServTime = randomDegit.Next(100);

                foreach (var serviceTimeMatch in GetAllServiceTimes())
                {
                    if (randomServTime >= serviceTimeMatch.MinRange && randomServTime <= serviceTimeMatch.MaxRange)
                    {
                        serviceTime = (int)serviceTimeMatch.ServiceTiem;
                    }
                }
            }
            return serviceTime;
        }

        public void CalculateFinalResult(int calculateTime)
        {
            //if ((clock) == 0)
            //{
            //    userInputGateway.DedeteFinalResultTable();
            //}
            for (int i = clock; i < calculateTime; i++)
            {
                FinalResult finalResult = new FinalResult();
                // //Final.....Inter Arrival Time...........
                finalResult.InterArrivalTime = FindInterArrivalTimeFromRandomDegit();

                //Final.....Arrival Time...........
                foreach (var item in GetAllFinalInfo())
                {
                    finalResult.ArrivalTime = item.ArrivalTime + finalResult.InterArrivalTime;
                }

                //Final.....Service Time...........
                finalResult.ServiceTime = FindServiceTimeFromRandomDegit();

                //Final.....Service Start Time...........
                int previousServiceEndTime = 0;
                foreach (var item in GetAllFinalInfo())
                {
                    previousServiceEndTime = item.ServiceEndTime;
                }
                if (previousServiceEndTime<=finalResult.ArrivalTime)
                {
                    finalResult.ServiceStartTime = finalResult.ArrivalTime;
                }
                else
                {
                    finalResult.ServiceStartTime = previousServiceEndTime;
                }
                //for (int j = previousServiceEndTime; j == finalResult.ArrivalTime; j++)
                //{
                //    previousServiceEndTime++;
                //}
                //finalResult.ServiceStartTime = previousServiceEndTime;

                //Final.....Service End Time...........
                finalResult.ServiceEndTime = finalResult.ServiceStartTime + finalResult.ServiceTime;
                
                clock = finalResult.ServiceEndTime;

                //FinalRelult Save Part.....................
                userInputGateway.FinalResultSave(finalResult);
            }
            

        }


    }
}