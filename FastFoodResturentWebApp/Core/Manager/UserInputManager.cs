using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
                return "Calculation Successfull.";
            }
            else
            {
                return "Sory! Calculation Fail.";
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
            if ((clock) == 0)
            {
                userInputGateway.DedeteFinalResultTable();
            }
            while ( clock< calculateTime)
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
               
                //Final.....Service End Time...........
                finalResult.ServiceEndTime = finalResult.ServiceStartTime + finalResult.ServiceTime;

                //Final.....Waiting Time..............
                finalResult.WaitingTime = 0;
                if (finalResult.ServiceStartTime > finalResult.ArrivalTime)
                {
                    finalResult.WaitingTime =finalResult.ServiceStartTime-finalResult.ArrivalTime;
                }
                //Final....Server Idel Time..........
                finalResult.ServerIdelTime = 0;

                if (finalResult.ArrivalTime > previousServiceEndTime)
                {
                    finalResult.ServerIdelTime = finalResult.ArrivalTime - previousServiceEndTime;
                }

                //Final.....Costomer Total Time Spend in queue........
                //finalResult.CustomerTotalSpendTime =finalResult.ServiceTime+finalResult.WaitingTime;
                
                clock = finalResult.ServiceEndTime;
                if (finalResult.ServiceEndTime>calculateTime)
                {
                    int count=0;
                    count++;
                    return;
                }

                //FinalRelult Save Part.....................
                userInputGateway.FinalResultSave(finalResult);

            }
            

        }


    }
}